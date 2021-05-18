# Linux help

### Выкл/Рестарт

**shutdown now** 
Bring down the system immediately.

**shutdown -r now** 
Bring down the system immediately, and automatically reboot it.

**shutdown -P now** 
Bring down the system immediately, and automatically power off the system.



### Virtual address

For Debian or Ubuntu Linux you need to edit `/etc/network/interfaces` file with your favorite text editor and add the following lines:
```
iface eth0:0 inet static
address 123.123.22.22
netmask 255.0.0.0
broadcast 123.255.255.255
```


### Enable root login over SSH

```
nano /etc/ssh/sshd_config
```
```
# Authentication:
#LoginGraceTime 2m
PermitRootLogin yes
#StrictModes yes
#MaxAuthTries 6
#MaxSessions 10
```
```
service sshd restart
```

### Copy file to server
v1
```
$ cat ~/.ssh/id_rsa.pub | ssh root@[your.ip.address.here] "cat >> ~/.ssh/authorized_keys"
```
v2
```
$ scp /opt/file.tar.gz root@11.22.33.44:/home/user
```
To copy all from Local Location to Remote Location (Upload)

scp -r /path/from/destination username@hostname:/path/to/destination
To copy all from Remote Location to Local Location (Download)

scp -r username@hostname:/path/from/destination /path/to/destination
Custom Port where xxxx is custom port number

 scp -r -P xxxx username@hostname:/path/from/destination /path/to/destination
Copy on current directory from Remote to Local

scp -r username@hostname:/path/from/file .


### Download file to localhost
```bash
$ scp root@11.22.33.44:/home/user/file.tar.gz "D:\install"
```


### Узнать размер директорий верхено уровня 

```
find . -maxdepth 1 -type d -exec du -hs {} \;
```


## Определяем версию Ubuntu из командной строки

```
$ lsb_release -a
```

## Генерация пароля

```
openssl rand -base64 32
```

## PID род процесса

pstree -p

## How to create an alias in Ubuntu 16 via the commandline

sudo nano -Bu ~/.bashrc

#Custom Aliases

alias nano='nano -Bu'  # backup original file and undo changes
alias rm='rm -i' # request confirmation before deleting a file

## Про make install

Суть сводится к тому, что эту команду в виде «make install» или «sudo make install» использовать в современных дистрибутивах нельзя.
https://habr.com/ru/post/130868/

## Команды для быстрого доступа

Команда **cd -** выполняет переход в предыдущий рабочий каталог и выводит в терминале его полный путь.
```
cd —
```
использует переменную $OLDPWD оболочки bash, чтобы получить путь предыдущего рабочего каталога. То есть фактически выполняется команда 
```
cd $OLDPWD
```
