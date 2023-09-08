## How to delete ALL node_modules folders on your machine and free up HD space on Windows 10?

```powershell
Get-ChildItem -Path "." -Include "node_modules" -Recurse -Directory | Remove-Item -Recurse -Force
```

## How to enable executing powershell script

```powershell
Set-ExecutionPolicy Unrestricted
```

## Show all enviroment variables

```powershell
gci env:* | sort-object name
```
