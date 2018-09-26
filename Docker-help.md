# docker-help
My crib on the commands of the docker


## Основыне RUN

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


Изменить точку входа(например на питон3) при создании образа

```docker commit --change='ENTRYPOINT ["python3"]' create-image-from-me```

## Удаление

Удалить все неиспользующиеся контейнеры

```docker system prune```

Удаление контейнера

```docker rm -f 32936ce9d754```

Удаление образа

```docker rmi -f 32936ce9d754```

Удалить все

```docker rm $(docker ps -a -q)```

## Обзор

Посмтореть контейнер по хешу

```
docker ps -a --no-trunc -q | grep df6a2118dfbbdf4a931ba6b7acce485a9c77c5c373c876350b6a5512ee7a611d
```
```
docker ps -a --no-trunc | grep df6a2118dfbbdf4a931ba6b7acce485a9c77c5c373c876350b6a5512ee7a611d
```
