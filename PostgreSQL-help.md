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

https://www.postgresql.org/docs/9.6/functions-array.html


**Live example**
```sql
select *,  COALESCE( cast("Data" ->> 'EmployeeAccreditation' as boolean), false) as EmployeeAccreditation
from "Table"
limit 100;
```
## Запрос с условиями

[8.14.3. Проверки на вхождение и существование jsonb](https://postgrespro.ru/docs/postgrespro/9.6/datatype-json "8.14. Типы JSON postgrespro 9.6")

```
"Data" @> '{"type":"juridical"}'
```

```sql
Select * from "BuyProjects" where "Data"->>'requestId'='24039'
```

```sql
select *
from "RequestVersions"
where cast("Data"->>'createdAt' as timestamp) between '2018-08-04T10:43' and '2018-08-04T10:45'
```

Проверка на существование свойства

```
not "Data"->'offers'->0->'extraServices'->'autoLoan'->'creditPrograms' is null

или
"Data"->'offers'->0->'extraServices'->'autoLoan' ? 'creditPrograms'

```

Наайти свойство с параметром status = 0

```sql
Select * from "ScheduleOrders"
where exists(select 1 from jsonb_array_elements("Data"->'history') v where v->>'status'='0')
```

Кладезь:

https://www.postgresql.org/docs/9.5/functions-json.html



Searching in Arrays
```sql
SELECT * FROM sal_emp WHERE pay_by_quarter[1] = 10000 OR
                            pay_by_quarter[2] = 10000 OR
                            pay_by_quarter[3] = 10000 OR
                            pay_by_quarter[4] = 10000;
                            
```

```sql
SELECT * FROM sal_emp WHERE 10000 = ANY (pay_by_quarter);
```


```sql
"Id" = ANY(ARRAY['element1', 'element2'])
```

```sql
SELECT *
FROM "Auctions"
WHERE  exists(SELECT 1
              FROM jsonb_array_elements("StatusData"->'statusHistory') AS statusData
              WHERE statusData->>'status' = 'bidsProcessing'
              AND cast(statusData->>'changedAt' AS  timestamp) between date '2019-08-02' AND date '2019-08-05');
```

Создание столбца из jsonb массива

```sql
select "Id", ARRAY(SELECT jsonb_array_elements_text("Data" -> ''scheduleIds''))::int[] 
from "BuyProjects";
```

Запрос с интервалом времени

```sql
"Data"->>'generationId'='1582' AND cast("Data"->>'dateAt' as timestamp) > current_timestamp - interval '60 days';
```

Найти все строке у которых есть json массив и массив больше 1:

```sql
select *
from (
       SELECT *, jsonb_array_length("Data" -> 'sources') AS len
       FROM "Requests"
     ) as a
where len > 1;
```

## Операции обновления столбцов типа JSONB 

Добавить всем у кого нет телефона:
```sql
UPDATE "Customers" 
SET "Data" = jsonb_set("Data", '{physicalInfo,phones}'::text[],
	jsonb_build_array(
		json_build_object(
			'type', 'cell', 
			'number', '70000000000', 
			'primary', true, 
			'lastUsed', true
		)
	)
)
WHERE not "Data"->'physicalInfo' ? 'phones'
```

Обновить имя:

```sql
UPDATE test SET data = jsonb_set(data, '{name}', '"my-other-name"');
```

Replace the tags (as oppose to adding or removing tags):

```sql
UPDATE test SET data = jsonb_set(data, '{tags}', '["tag3", "tag4"]');
```

Replacing the second tag (0-indexed):

```sql
UPDATE test SET data = jsonb_set(data, '{tags,1}', '"tag5"');
```

Append a tag (this will work as long as there are fewer than 999 tags; changing argument 999 to 1000 or above generates an error. This no longer appears to be the case in Postgres 9.5.3; a much larger index can be used):

```sql
UPDATE test SET data = jsonb_set(data, '{tags,999999999}', '"tag6"', true);
```

Remove the last tag:

```sql
UPDATE test SET data = data #- '{tags,-1}'
```

Complex update (delete the last tag, insert a new tag, and change the name):

```sql
UPDATE test SET data = jsonb_set(
    jsonb_set(data #- '{tags,-1}', '{tags,999999999}', '"tag3"', true), 
    '{name}', '"my-other-name"');
```
## Массивы

Замена элеемнта в массиве
```sql

UPDATE users SET topics = array_replace(topics, 'dogs', 'mice');


```

## Кастинг даты
```sql
cast("Offers"."Data" ->> 'FinishAt' as timestamp) at time zone 'utc' at time zone 'Europe/Moscow'
```

# Администрирование базы

Посмотреть активные подключеня

```sql
select * from pg_stat_activity;

select count(*) from pg_stat_activity;
```

```sql
select max_conn,used,res_for_super,max_conn-used-res_for_super res_for_normal 
from 
  (select count(*) used from pg_stat_activity) t1,
  (select setting::int res_for_super from pg_settings where name=$$superuser_reserved_connections$$) t2,
  (select setting::int max_conn from pg_settings where name=$$max_connections$$) t3
```

## Сбросить определенные подключения:

```sql
SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.usename = 'username'
  AND pid <> pg_backend_pid();
 ```

## Закрыть все подключения к конкретной базе:

```
SELECT pg_terminate_backend(pg_stat_activity.pid)
FROM pg_stat_activity
WHERE pg_stat_activity.datname = 'assortmentpolicy' -- ← change this to your DB
  AND pid <> pg_backend_pid();
```
 
 Подробно о VACUUM
 
 http://asurf.ru/db/talk-about-command-vacuum.html
 
 VACUUM — это операция сборки мусора и опционально анализатор базы данных.

# Размер
 
```sql
select pg_size_pretty(pg_database_size('namedb'))
```

 ## Дополнительно
 
 Посмотреть устаночленные расширения:
 ```sql
 select * from pg_available_extensions order by name;
 ```
 
 ## Current Date/Time
 
 
 To insert the current time use current_timestamp as documented in the manual:
 
 https://www.postgresql.org/docs/current/functions-datetime.html#FUNCTIONS-DATETIME-CURRENT
 
 ## Работа с Enum
 
 Посмотерть все енумы:
 
 ```sql
 select n.nspname as enum_schema,
       t.typname as enum_name,
       e.enumlabel as enum_value
from pg_type t
   join pg_enum e on t.oid = e.enumtypid
   join pg_catalog.pg_namespace n ON n.oid = t.typnamespace;
 ```
 
 ## Ссылки
 
 Полезные трюки PostgreSQL https://habr.com/ru/post/280912/
 
 ## Логические операторы
 
 ```sql
 select null = null,
       null <> null,
       null is not distinct from null;
 ```

| col1  | col2  | col3 |
| ----- | ----- | ---- |
| false | false | true |


## Генерация случайных последовательностей

```sql

insert into "Users"
select "UserId" from
          (SELECT generate_series(1,1000) AS id,md5(random()::text) AS "UserId")s;
	  
```

## Разность массивов

```sql
select array(select unnest(:arr1) except select unnest(:arr2));
```
 
 
