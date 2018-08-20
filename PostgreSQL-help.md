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

```
"Data" @> '{"type":"juridical"}'
```

```
Select * from "BuyProjects" where "Data"->>'requestId'='24039'
```

```
select *
from "RequestVersions"
where cast("Data"->>'createdAt' as timestamp) between '2018-08-04T10:43' and '2018-08-04T10:45'
```

Проверка на существование свойства

```
not "Data"->'offers'->0->'extraServices'->'autoLoan'->'creditPrograms' is null
```

Наайти свойство с параметром status = 0

```
Select * from "ScheduleOrders"
where exists(select 1 from jsonb_array_elements("Data"->'history') v where v->>'status'='0')
```

## Операции обновления столбцов типа JSONB 

Обновить имя:

```
UPDATE test SET data = jsonb_set(data, '{name}', '"my-other-name"');
```

Replace the tags (as oppose to adding or removing tags):

```
UPDATE test SET data = jsonb_set(data, '{tags}', '["tag3", "tag4"]');
```

Replacing the second tag (0-indexed):

```
UPDATE test SET data = jsonb_set(data, '{tags,1}', '"tag5"');
```

Append a tag (this will work as long as there are fewer than 999 tags; changing argument 999 to 1000 or above generates an error. This no longer appears to be the case in Postgres 9.5.3; a much larger index can be used):

```
UPDATE test SET data = jsonb_set(data, '{tags,999999999}', '"tag6"', true);
```

Remove the last tag:

```
UPDATE test SET data = data #- '{tags,-1}'
```

Complex update (delete the last tag, insert a new tag, and change the name):

```
UPDATE test SET data = jsonb_set(
    jsonb_set(data #- '{tags,-1}', '{tags,999999999}', '"tag3"', true), 
    '{name}', '"my-other-name"');
```


# Администрирование базы

Посмотреть активные подключеня

```
select * from pg_stat_activity;

select count(*) from pg_stat_activity;
```

Сбросить определенный подключения:

```
SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.usename = 'username'
  AND pid <> pg_backend_pid();
 ```
