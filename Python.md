# Python help

## Как проверить какие модули Python установлены в системе

```
pydoc modules
```

Для Python на Windows

```
py -m pydoc modules.
```

Или можно использовать функцию справки help(), находясь в интерактивной оболочке Python:

```
help('modules')
```

Чтобы получить список модулей установленных только через pip:

```
pip freeze
```
