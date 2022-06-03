// 1.37 Дан целочисленный массив. Вывести индексы элементов, которые меньше своего левого соседа, и количество таких чисел.

open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n


let Obrabotka (list1:'int list) = 
  let rec obrabotka list1 leftEl (indEl:int) num=
      match list1 with
      |[] -> num
      |h::tail->
        let newNum = 
            if h<leftEl then num+1
            else num
        let newLeft = h
        if h<leftEl then Console.WriteLine("Индекс = {0}",indEl)
        obrabotka tail newLeft (indEl+1) newNum
  obrabotka list1.Tail list1.Head 1 0


[<EntryPoint>]
let main argv =
    readData |> Obrabotka |> Console.WriteLine
    0 