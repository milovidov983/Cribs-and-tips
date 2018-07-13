### COALESCE

```COALESCE(значение [, ...])```

```SELECT COALESCE(description, short_description, '(none)') ...```

Функция COALESCE возвращает первый попавшийся аргумент, отличный от NULL. Если же все аргументы равны NULL, результатом тоже будет NULL. Это часто используется при отображении данных для подстановки некоторого значения по умолчанию вместо значений NULL

**Live example:**

```
select *,  COALESCE( cast("Data" ->> 'EmployeeAccreditation' as boolean), false) as EmployeeAccreditation, "Data"->> 'LoanPercent' as LoanPrecent
from marketing.public."CreditPrograms"
  where "ArchiveAt" is null
order by COALESCE( cast("Data" ->> 'EmployeeAccreditation' as boolean), false) desc, LoanPrecent
limit 100;
```
https://postgrespro.ru/docs/postgrespro/9.5/functions-conditional
