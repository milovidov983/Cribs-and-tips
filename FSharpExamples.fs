// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    //---------------------------------------------------------------------------------
    // 1. Кортежи
    // 1.1 Инициализация кортежа
    let nameTuple = ("Vincent","Vega")
    
    // 1.2 Извлечение значений из кортежа содержащего два элемента
    let firstName = fst nameTuple
    let lastName = snd nameTuple
    
    // 1.3 Алтернативный способ извлечения элементов из кортежей любого размера
    let x,y = nameTuple
    
    // 1.4 Передача кортежа функции
    let addTuple(x,y) = x + y
    let x = addTuple (5, 7)

    //---------------------------------------------------------------------------------
    // 2. Списки
    // 2.1 Инициализация
    let volwes = ['a';'e';'i';'o';'u']
    let emptyLiat = []
    
    // 2.2 Добавление в начало списка
    let sometimes = 'y' :: volwes
    
    // 2.3 Объединение списков
    let odds = [1; 3; 5; 7; 9]
    let evens = [2; 4; 6; 8; 10]
    let oddsAndEvens = odds @ evens

    // 2.4 Создание диапазонов списков
    let x = [1 .. 10]
    let tens = [0 .. 10 .. 50] // шаг 10
    let countDown = [5L .. -1L .. 0L] // шаг -1

    // 2.5 Генераторы списков 
    // (Обратите внимание, что список создается в памяти целиком – 
    // элементы списков не вычис- ляются отложенно (lazily), 
    // как в случае использования типа seq<_>)
    let numbersNear x = 
        [
            yield x - 1
            yield x
            yield x + 1
        ]
    let x = numbersNear 3 // [2; 3; 4]
    // Более сложный генератор списка, 
    // который объявляет функцию negate и возвращает числа от 1 до 10, 
    // инвертируя знак четных значений.
    let negateGeneratorList = 
        [ 
            let negate x = -x
            for i in 1 .. 10 do
                if i % 2 = 0 then
                    yield negate i
                else
                    yield i
        ]

    printfn "ok" 
    0 // return an integer exit code
