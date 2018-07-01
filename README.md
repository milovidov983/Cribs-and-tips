# docker-help
My crib on the commands of the docker

Режим терминала

``` -it ```

Удалить контейнер после выхода из него

``` --rm ```


Для того чтобы пробросить порты контейнера при запуске необходимо использовать ключ -p:

```docker run -d --name port-export -p <port_on_host_machine>:<port_inside_container> image```
