# docker-help
My crib on the commands of the docker

## Statistics

```docker stats $(docker ps --format={{.Names}})```


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
