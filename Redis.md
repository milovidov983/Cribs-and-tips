# Удалить все записи в Redis

```flushall```


# Снайперсикй выстрел

```docker ps --format {{.Names}} | grep redis | awk -F- '{print "docker exec redis-"$2" redis-cli -p "$2" KEYS *7391* | xargs -L 1 redis-cli -p "$2" del"}' | sh```

# redis graph

https://gigi.nullneuron.net/gigilabs/first-steps-with-redisgraph/

```	
GRAPH.QUERY TomLovesJudy "CREATE (tom:Person {name: 'Tom'})-[:loves]->(judy:Person {name: 'Judy'})"

GRAPH.QUERY TomLovesJudy "MATCH (x) RETURN x"
```

https://habr.com/ru/articles/482418/
