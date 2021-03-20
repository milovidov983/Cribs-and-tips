# Below is the answer to the question how
## How to delete ALL node_modules folders on your machine and free up HD space!

```powershell
Get-ChildItem -Path "." -Include "node_modules" -Recurse -Directory | Remove-Item -Recurse -Force
```
