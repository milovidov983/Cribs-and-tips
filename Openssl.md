# Openssl шапргалка по командам


## Конвертация SSl сертификатов посредством OpenSSL

Конвертировать PEM в DER можно посредством команды:
```
openssl x509 -outform der -in site.crt -out site.der
```

**PEM в P7B**
```
openssl crl2pkcs7 -nocrl -certfile site.crt -out site.p7b -certfile site.ca-bundle
```

**PEM в PFX**
```
openssl pkcs12 -export -out site.pfx -inkey site.key -in site.crt -certfile site.ca-bundle
```
(после выполнения команды, будет запрошена установка пароля ключа.)

**DER в PEM**
```
openssl x509 -inform der -in site.der -out site.crt
```

**P7B в PEM**
```
openssl pkcs7 -print_certs -in site.p7b -out site.cer
```

**P7B в PFX**
```
openssl pkcs7 -print_certs -in site.p7b -out certificate.ceropenssl pkcs12 -export -in site.cer -inkey site.key -out site.pfx -certfile site.ca-bundle
```

**PFX в PEM**
```
openssl pkcs12 -in site.pfx -out site.crt -nodes
```

## PFX в KEY и CRT

Воспользуемся всем знакомой утилитой openssl, чтобы вытащить открытую часть pfx-сертификата

```
openssl pkcs12 -in certificate.pfx -clcerts -nokeys -out certificate.crt
```

Нужно будет ввести пароль, который вы указывали при экспорте .pfx-сертификата. Теперь попробуем извлечь **закрытую часть** сертификата, поместив её в отдельный запароленный файл

```
openssl pkcs12 -in certificate.pfx -nocerts -out key-encrypted.key
```

Закрытый ключ сертификата с парольной защитой не всегда удобно использовать на реальном окружении. Например тот же Apache будет спрашивать пароль при каждом рестарте сервиса, что будет требовать человеческого участия. Обойти проблему можно, сняв пароль с закрытого ключа

```
openssl rsa -in key-encrypted.key -out key-decrypted.key
```

## Создание сертификата с использованием gost2012

```
openssl req -x509 -newkey gost2012_256 -pkeyopt paramset:A -nodes -keyout key.pem -out cert.pem
```

## Ссылки

Основы работы с openssl
http://citforum.ru/security/cryptography/openssl/

https://www.emaro-ssl.ru/support/csr-chto-eto.php

Как добавить поддержку шифрования по ГОСТ Р 34.10-2012 в OpenSSL 1.1.1d на Debian 9 Stretch
https://jakondo.ru/kak-dobavit-podderzhku-shifrovaniya-po-gost-r-34-10-2012-v-openssl-1-1-1d-na-debian-9-stretch/
