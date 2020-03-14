# Links


Nginx в качестве балансировщика нагрузки
https://serveradmin.ru/nginx-v-kachestve-balansirovshhika-nagruzki



example

```
worker_processes 1;

events {
    worker_connections 1024;
    multi_accept on;
    use epoll;
}


http {  
    upstream cache-api {
        server 172.17.0.2:3000 max_fails=1 fail_timeout=10s;
        server 172.17.0.3:3000 max_fails=1 fail_timeout=10s;
    }

    server {
        listen 80;
        listen [::]:80;

        location / {
            proxy_pass http://cache-api/;
            proxy_read_timeout 2;
            proxy_connect_timeout 3;
            proxy_set_header Host $host;
            proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
            proxy_set_header X-Real-IP $remote_addr;
        }
    }
}
```
