# Шпаргалка по утилите *psql*

Синтаксис:

```psql -U postgres -c 'SELECT now()'```

```-U postgres``` - имя пользователя

```-c 'SELECT now()'``` - команда


Структура базы

```psql -U postgres -c '\dt'```


Список команд psql

```psql -U postgres -c '\?'```

# Работа с Jsonb

https://habr.com/post/254425/

https://www.postgresql.org/docs/9.6/static/functions-json.html

**Live example**
```
select *,  COALESCE( cast("Data" ->> 'EmployeeAccreditation' as boolean), false) as EmployeeAccreditation
from "Table"
limit 100;
```
## Запрос с условиями

``` "Data" @> '{"type":"juridical"}'```

```Select * from "BuyProjects" where "Data"->>'requestId'='24039'```

```
select *
from "RequestVersions"
where cast("Data"->>'createdAt' as timestamp) between '2018-08-04T10:43' and '2018-08-04T10:45'
```
