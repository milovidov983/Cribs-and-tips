# Rust шпаргалка

https://doc.rust-lang.ru/book/

https://rurust.github.io/rust_book_ru/syntax-and-semantics.html

https://rurust.github.io/rust_book_ru/getting-started.html

https://crates.io/


Обедающие философы:

https://rurust.github.io/rust_book_ru/dining-philosophers.html


## Простой способ создать новый Cargo проект

`cargo new hello_world --bin`

## Сборка

`cargo build --release`

`Cargo.toml`

```toml
[package]

name = "hello_world"
version = "0.0.1"
authors = [ "Your name <you@example.com>" ]
```
## Зависимости

А что, если мы захотим использовать версию v0.3.9? У Cargo есть другая команда, update


## Типы

### Указатели на функции

Можно объявить имя, связанное с функцией:

```rust
let f: fn(i32) -> i32;
```
f — это имя, связанное с указателем на функцию, которая принимает в качестве аргумента i32 и возвращает i32. Например:


```rust
fn plus_one(i: i32) -> i32 {
    i + 1
}

// без вывода типа
let f: fn(i32) -> i32 = plus_one;

// с выводом типа
let f = plus_one;
```
Теперь мы можем использовать f, чтобы вызвать функцию:


```rust
let six = f(5);
```

### Char

**char в Rust представлен не одним байтом, а четырьмя.**

### Числовые типы

- i8
- i16
- i32
- i64
- u8
- u16
- u32
- u64
- isize
- usize
- f32
- f64

## Метки циклов

```rust

#![allow(unused_variables)]
fn main() {
'outer: for x in 0..10 {
    'inner: for y in 0..10 {
        if x % 2 == 0 { continue 'outer; } // продолжает цикл по x
        if y % 2 == 0 { continue 'inner; } // продолжает цикл по y
        println!("x: {}, y: {}", x, y);
    }
}
}

```


## Утверждение where


```rust

#![allow(unused_variables)]
fn main() {
use std::fmt::Debug;

fn bar<T, K>(x: T, y: K)
        where T: Clone,
              K: Clone + Debug {

        x.clone();
        y.clone();
        println!("{:?}", y);
    }
}


```


```rust
trait ConvertTo<Output> {
    fn convert(&self) -> Output;
}

impl ConvertTo<i64> for i32 {
    fn convert(&self) -> i64 { *self as i64 }
}

// может быть вызван с T == i32
fn normal<T: ConvertTo<i64>>(x: &T) -> i64 {
    x.convert()
}

// может быть вызван с T == i64
fn inverse<T>() -> T
        // использует ConvertTo как если бы это было «ConvertTo<i64>»
        where i32: ConvertTo<T> {
    1i32.convert()
}

```


## Переменные 

```rust
// _ нижнее подчеркивание говорит компилятору что перемнная не будет использована
// Таким образом Rust не будет выводить предупреждение о неиспользуемых именах.
let _left = table.forks[self.left].lock().unwrap();  использоватся
 
```


