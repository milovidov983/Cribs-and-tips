# Node Version Manager
Управление версиями ноды

https://github.com/coreybutler/nvm-windows#usage



## Debug ноды в VS Code

1. Cтартуем приложение с флагом --inspect например:

```
node --inspect ./dist/am.js
```

2. В папке  .vscode создаем файл launch.json с таким содержимым
```json
{
    "version": "0.2.0",
    "configurations": [
        {
            "type": "node",
            "request": "attach",
            "name": "Launch Program",
            "port":9229
        }
    ]
}

```
3. Нажимаем F5
