# Удалить все записи в Redis

```flushall```


# Снайперсикй выстрел

```docker ps --format {{.Names}} | grep redis | awk -F- '{print "docker exec redis-"$2" redis-cli -p "$2" KEYS *7391* | xargs -L 1 redis-cli -p "$2" del"}' | sh```
