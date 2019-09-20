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
