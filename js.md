# Javascript help

## Convert default javascript date to UTC date like "2018-12-29T07:27:04.500Z"
```
new Date(Date.now()).toISOString();
```


## Add some minutes to date 
```
var d1 = new Date (),
    d2 = new Date ( d1 );
d2.setMinutes ( d1.getMinutes() + 30 );
alert ( d2 );
```
