open System

let rec multrecup x = // Произведение цифр (рекурсия вверх)
    if x = 0 then 1 
    else (x % 10) * multrecup(x / 10)

let rec maxrecup x = // Максимальная цифра (рекурсия вверх)
    if x < 10 then x 
    else max (x % 10) (maxrecup(x / 10))

let rec minrecup x = // Минимальная цифра (рекурсия вверх)
    if x < 10 then x 
    else min (x % 10) (minrecup(x / 10))

let multrecdown x = // Произведение цифр (хвостовая рекурсия)
    let rec mult1 x init =
        if x = 0 then init
        else
            let m = x % 10
            let ostatok = x / 10
            let mult2 = m* init
            mult1 ostatok mult2
    mult1 x 1

let maxrecdown x = // Максимальная цифра (хвостовая рекурсия)
    let rec max1 x init =
        if x = 0 then init
        else    
            let m = x % 10
            let max2 = if m> init then m else init 
            let ostatok = x / 10
            max1 ostatok max2
    max1 x (x % 10)

let minrecdown x = // Минимальная цифра (хвостовая рекурсия)
    let rec min1 x init =
        if x = 0 then init
        else
            let m = x % 10
            let min2 = if m< init then m else init
            let ostatok = x / 10
            min1 ostatok min2
    min1 x (x % 10)


[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Введите число: ")
    let x = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine("Вычисление с помощью рекурсии вверх: ")
    System.Console.WriteLine("Произведение цифр числа:{0}", multrecup x)
    System.Console.WriteLine("Максимальная цифра числа:{0}", maxrecup x)
    System.Console.WriteLine("Минимальная  цифра числа:{0}", minrecup x)
    System.Console.WriteLine("Вычисление с помощью хвостовой рекурсии: ")
    System.Console.WriteLine("Произведение цифр числа:{0}", multrecdown x)
    System.Console.WriteLine("Максимальная цифра числа:{0}", maxrecdown x)
    System.Console.WriteLine("Минимальная  цифра числа:{0}", minrecdown x)
    
    0