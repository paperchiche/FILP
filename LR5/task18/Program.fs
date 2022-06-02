//method 1
let obhod_del n=
    let rec creat_list n j r=
        if n < j then r 
        else 
            if (n % j = 0) && ((let rec prost digit i ans=
                                   if i >= digit then ans 
                                   else if digit % i = 0 then prost digit (i+1) (ans + 1) else prost digit (i + 1) ans
                                prost j 2 0 ) = 0) then  creat_list n (j+1) (j::r)
            else creat_list n (j+1) r
    let list= creat_list n 1 []
    let rec ans list init =
        match list with
        |h::t -> ans t (init + h) 
        |[] -> init
    ans list 0
//method 2
let method2 n =
    let rec obhod n acc=
        if n <= 0 then acc else
        if ((n % 10) > 3) && ((n % 10) % 2 > 0) then obhod (n / 10) (acc + 1)
        else obhod (n / 10) acc
    obhod n 0
//method 3
let sum_c_t n=
    let rec sum_c_t1 acc n=
        if n = 0 then acc
        else sum_c_t1 (acc + (n % 10)) (n / 10)
    sum_c_t1 0 n
let rec method3 n j kol=
    if n < j then kol 
        else 
        if (n % j = 0) && (sum_c_t n > sum_c_t j) then method3 n (j+1) (kol * j) 
        else method3 n (j+1) kol
let input=
    let n = System.Convert.ToInt32(System.Console.ReadLine())
    System.Console.WriteLine(obhod_del n)
    System.Console.WriteLine(method2 n)
    System.Console.WriteLine(method3 n 1 1);;
