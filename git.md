## Переключить репозиторий

You can update the port in the SSH URL with git remote set-url CLI command. 
For example, to update the port of the origin remote to port 321 you can run the following:

```
git remote set-url origin ssh://user@site.com:321/home/user/repo
```

If you don't know the rest of the URL you can do

```
git remote -v
```
