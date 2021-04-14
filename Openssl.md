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
После выполнения команды, будет запрошена установка пароля ключа.

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
