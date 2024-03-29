# docker-help
My crib on the commands of the docker

## Installation

```
sudo apt-get update
```


```
sudo apt-get remove docker docker-engine docker.io
```

```
sudo apt install docker.io
```

```
sudo systemctl start docker
```

```
sudo systemctl enable docker
```

## Statistics

```docker stats $(docker ps --format={{.Names}})```

## How to log all the processes running inside a Docker container?

```
docker top <container>
```

```
docker top <container_id> -eo pid,cmd
```

## What to do when all docker commands hang?

Please follow the below steps to solve this issue

Step 1 : Uninstall docker “sudo yum remove docker"
Step 2 : remove all docker folder
"sudo rm -rf /var/lib/docker”
“sudo rm -rf /var/run/docker”
“sudo rm /var/run/docker.*” (remove docker.sock, docker.pid files)

Step 3 : Reinstall docker "sudo yum install docker"
Step 4 : Start docker “sudo service docker start”



## RUN

Режим терминала

```-it ```


Удалить контейнер после выхода из него

```--rm ```


Задать имя контейнеру

```--name <name>```



## Файлы

Подключить директорию/файл к контейнеру из хоста

``` -v <путь к директории хоста>:<путь в контейнере>```

Если надо подключить текущую директорию:

```
-v $pwd/:/temp
```


## Взаимодействие

Для подключения к уже запущенному контейнеру

```docker exec -it <container-name> bash```


Для того чтобы пробросить порты контейнера при запуске необходимо использовать ключ -p:

```docker run -d --name port-export -p <port_on_host_machine>:<port_inside_container> image```


Содать сеть

```docker network create custom ```


Задать кастомную сеть контейнеру

```--network=custom```



## Создание и работа с образами

Содать образ из контейнера

```docker commit <имя контейнера> <имя создаваемого образа>```


Создать образ из докер-файла

```docker build -t <имя образа>```
Параметр -t определяет имя образа.
Совет: в рабочей дериктории в которой происходит сборка образа не рекомендуется держать какие-либо файлы не относящиеся к образу.
Создание докерфайла https://docs.docker.com/develop/develop-images/dockerfile_best-practices/

Посмотреть какие опреации были проделаны при создании образа

```docker history <имя образа> ```

### Все про CMD и ENTRYPOINT

https://habr.com/ru/company/southbridge/blog/329138/

**Краткое резюме:**

Используйте ENTRYPOINT, если вы не хотите, чтобы разработчики изменяли исполняемый файл, который запускается при запуске контейнера. Вы можете представлять, что ваш контейнер – исполняемая оболочка. Хорошей стратегией будет определить стабильную комбинацию параметров и исполняемого файла как ENTRYPOINT. Для нее вы можете (не обязательно) указать аргументы CMD по умолчанию, доступные другим разработчикам для переопределения.

Используйте только CMD (без определения ENTRYPOINT), если требуется, чтобы разработчики могли легко переопределять исполняемый файл. Если точка входа определена, исполняемый файл все равно можно переопределить, используя флаг --entrypoint. Но для разработчиков будет гораздо удобнее добавлять желаемую команду в конце строки docker run.


### ПРИМЕР СОЗДАНИЯ DOCKER ОБРАЗА И ЗАПУСКА ЕГО С ВХОДНОЙ ТОЧКОЙ В PYTHON3

```
docker run -it --name my_template_container ubuntu:14.04

apt-get update
apt-get install python3
exit

docker commit my_template_container my_python3_img 

docker run -it --name my_container my_python3_img /usr/bin/python3
```


Изменить точку входа(например на питон3) при создании образа

```docker commit --change='ENTRYPOINT ["python3"]' create-image-from-me```



## Удаление

Удалить все неиспользующиеся контейнеры

```docker system prune```

Удаление контейнера

```docker rm -f 32936ce9d754```

Удалить все запущенные и остановленные контейнеры

```docker rm $(docker ps -a -q)```

Удаление образа

```docker rmi -f 32936ce9d754```

## Обзор

Посмтореть контейнер по хешу

```
docker ps -a --no-trunc -q | grep df6a2118dfbbdf4a931ba6b7acce485a9c77c5c373c876350b6a5512ee7a611d
```
```
docker ps -a --no-trunc | grep df6a2118dfbbdf4a931ba6b7acce485a9c77c5c373c876350b6a5512ee7a611d
```

## Работа с файлами

Скопировать файл из контейнера

```
docker cp container-name:/foo/. ./foo/
```

## using YAML Anchors and the X prefix to set defaults:

```YAML
version: "3.4"

x-app: &default-app
  build:
    context: "."
    args:
      - "APP_ENV=${APP_ENV:-prod}"
  depends_on:
    - "postgres"
    - "redis"
  env_file:
    - ".env"
  image: "nickjj/myapp"
  restart: "unless-stopped"
  stop_grace_period: "3s"
  volumes:
    - ".:/app"

services:
  web:
    <<: *default-app 
    ports:
      - "8000:8000"

  worker:
    <<: *default-app
```

## Sample Dockerfile for Go project

```
FROM golang:alpine AS builder

LABEL stage=gobuilder

ENV CGO_ENABLED 0

ENV GOOS linux

RUN apk update --no-cache && apk add --no-cache tzdata

WORKDIR /build

ADD go.mod .

ADD go.sum .

RUN go mod download

COPY . .

RUN go build -ldflags="-s -w" -o /app/hello . /hello.go

FROM alpine

RUN apk update --no-cache && apk add --no-cache ca-certificates

COPY --from=builder /usr/share/zoneinfo/America/New_York /usr/share/zoneinfo/America/New_York

ENV TZ America/New_York

WORKDIR /app

COPY --from=builder /app/hello /app/hello

CMD [". /hello"]
```
