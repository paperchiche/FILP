﻿// 1.34 Дан целочисленный массив и отрезок a..b. Необходимо найти элементы, значение которых принадлежит этому отрезку.

open System

let init_list() = 
    let rec read_list n=
        if n=0 then []
        else
            let Head = Convert.ToInt32(Console.ReadLine())
            let Tail = read_list (n-1)
            Head::Tail
    Console.WriteLine("Введите количество элементов: ")
    let a = read_list (Convert.ToInt32(Console.ReadLine()))
    a

let rec write_list = function
    [] -> let z = Console.ReadKey()
          0
    |   (head:int)::tail -> 
                   Console.WriteLine(head)
                   write_list tail  

let func list a b =
    let rec func_rec list a b newList=
        match list with
        |[]->newList
        |h::t->
            if (h>=a)&&(h<=b) then func_rec t a b newList@[h]
            else func_rec t a b newList
    func_rec list a b []

[<EntryPoint>]
let main argv =
    let list = init_list()
    Console.WriteLine("Введите значения отрезка: ")
    let a = Convert.ToInt32(Console.ReadLine())
    let b = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Элементы, принадлежащие заданному отрезку: ")
    func list a b|>Console.WriteLine
    0 // return an integer exit code