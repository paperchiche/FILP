open System

[<EntryPoint>]
let main argv =
    let Answer (lang:string) = 
        match lang.Trim() with
        |"F#" | "Prolog" -> "Вы подлиза"
        |"C++" -> "Может быть, подумаете ещё?"
        |"C#" -> "Может быть, подумаете ещё?"
        |"Python" -> "Может быть, подумаете ещё?"
        |"Pascal" -> "Неправильный ответ"
        |_ -> "Бог Вам судья"

    // Суперпозиция
    Console.WriteLine("Какой Ваш любимый язык программирования?")
    (Console.ReadLine >> Answer >> Console.WriteLine)()
    
    // Каррирование
    Console.WriteLine("Какой Ваш любимый язык программирования?")
    let result Answer func out = out(func(Answer()))
    result Console.ReadLine Answer Console.WriteLine
  
    0