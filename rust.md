# Rust шпаргалка

https://rurust.github.io/rust_book_ru/getting-started.html

https://crates.io/

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
