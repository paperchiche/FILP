open System

let Answer A =
    match A with
    | "F#" | "Prolog" -> System.Console.WriteLine("Вы подлиза") 
    | _ -> System.Console.WriteLine("Проверка пройдена") 


[<EntryPoint>]
let main argv =
    System.Console.WriteLine("Какой Ваш любимый язык программирования?")
    let B = Console.ReadLine()
    Answer B
    0