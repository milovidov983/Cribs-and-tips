# Golang


## Maps

### Create

```go
x := make(map[string]int)
x["key"] = 10
fmt.Println(x["key"])
```

```go
elements := map[string]string{
    "H": "Hydrogen",
    "He": "Helium",
    "Li": "Lithium",
    "Be": "Beryllium",
    "B": "Boron",
    "C": "Carbon",
    "N": "Nitrogen",
    "O": "Oxygen",
    "F": "Fluorine",
    "Ne": "Neon",
}
```

### Access

```go
name, ok := elements["Un"]
fmt.Println(name, ok)
```

Доступ к элементу карты может вернуть два значения вместо одного. Первое значение это результат запроса, второе говорит, был ли запрос успешен. В Go часто встречается такой код:

```go
if name, ok := elements["Un"]; ok {    
    fmt.Println(name, ok)
}
```

Сперва мы пробуем получить значение из карты, а затем, если это удалось, мы выполняем код внутри блока.
