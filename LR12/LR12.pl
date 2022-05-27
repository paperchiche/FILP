%task11
prost(X):-X1 is X-1, prost(X,X1).
prost(_,1):- !.
prost(X,D) :- 0 is X mod D,!, fail.
prost(X,D):- D1 is D-1, prost(X,D1).

%11 сумма простых делителей
%11.1 рекурсия вверх
sumDelUp(X,Sum):-sumDelUp(X,X,Sum),!.
sumDelUp(_,0,0):-!.
sumDelUp(X,Del,Sum):-D1 is Del-1, sumDelUp(X,D1,NewSum),
    (0 is X mod Del,prost(Del), Sum is NewSum+Del; Sum is NewSum).

%11.2 рекурсия вниз
sumDelDown(X,Sum):-sumDelDown(X,X,Sum,0),!.
sumDelDown(_,0,Sum,Sum):-!.
sumDelDown(X,Del,Sum,CurSum):-
    (0 is X mod Del,prost(Del), NewSum is CurSum+Del; NewSum is CurSum),
    D1 is Del-1, sumDelDown(X,D1,Sum,NewSum).

%task12
%сумма цифр
sumCifr(X,Sum):- sumCifrDown(X,Sum,0).
sumCifrDown(0,Res,Res):-!.
sumCifrDown(X,Sum,CurSum):- X1 is X mod 10, NowSum is CurSum+X1,
    X2 is X div 10, sumCifrDown(X2,Sum,NowSum).

multDel(X,Res):- multDel(X,X,Res,1),!.
multDel(_,0,Res,Res):-!.
multDel(X,Del,Res,CurMult):-
    (0 is X mod Del,sumCifr(Del,Y),sumCifr(X,Z),Y<Z,
    NewMult is CurMult*Del; NewMult is CurMult),D1 is Del-1,
    multDel(X,D1,Res,NewMult).

%task13.
zad13(N,M,K):-NewN is N+1,NewM is M+1,zad13(2,NewN,2,NewM,0,K),!.
zad13(N,N,_,_,Count,Count):-!.
zad13(A,N,M,M,Count,K):-NewA is A+1,zad13(NewA,N,2,M,Count,K).
zad13(A,N,B,M,Count,K):-X is A**B,NewB is B+1,(srav(X,A,NewB,N,M) -> NewCount is Count+1,zad13(A,N,NewB,M,NewCount,K);zad13(A,N,NewB,M,Count,K)).
srav(_,N,_,N,_):-!.
srav(X,A,M,N,M):-NewA is A+1,srav(X,NewA,2,N,M).
srav(X,A,B,N,M):-(A<N,B<M -> (X2 is A**B,X =:= X2 -> fail,!;NewB is B+1,srav(X,A,NewB,N,M))).

%task14.
lenght_list([],0).
lenght_list([_|T],X):-lenght_list(T,X1),X is X1+1.

append([],X,X).
append([H|T],X,[H|T1]):-append(T,X,T1).

read_list(A,N):-read_list([],A,0,N).
read_list(A,A,N,N):-!.
read_list(List,A,I,N):- I1 is I+1,read(X),append(List,[X],List1),read_list(List1,A,I1,N).

write_list([]):-!.
write_list([H|T]):-write(H),write(' '),write_list(T).

%task15.
getLast([], _, _):-!, fail.
getLast([H], H, []):-!.
getLast([H|T], R, [H|RL]):-getLast(T, R, RL).

shift(L,[E|RL]):-getLast(L,E,RL),!.
shift_2(L,[E|RL]):-shift(L,R),shift(R,[E|RL]).

zad15(N):-read_list(List,N),shift_2(List,List2),write_list(List2).

%task16.
solo_digit(List,X):-count_list(List,List_counts),solo_digit(X,List,List_counts),!.
solo_digit(X,[X|_],[1|_]):-!.
solo_digit(X,[H|T],[HC|TC]):-solo_digit(X,T,TC).

zad16(N):-read_list(List,N),solo_digit(List,X),write(X).
test(List):-count_list(List,List_counts),write_list(List_counts).

count_list(List,List_counts):-count_list(List,List,List_counts,[]),!.
count_list([],_,L,L):-!.
count_list([H|T],List,List_counts,TList):-count_el(H,List,Count),append(TList,[Count],NewTList),count_list(T,List,List_counts,NewTList).

count_el(N,List,Count):-count_el(N,List,Count,0),!.
count_el(_,[],Count,Count).
count_el(N,[H|T],Count,TCount):-(N =:= H -> NewTCount is TCount+1,count_el(N,T,Count,NewTCount);count_el(N,T,Count,TCount)).


%task17.
min([H|T],X):-min(T,X,H),!.
min([],X,X):-!.
min([H|T],X,TMin):-H < TMin -> min(T,X,H);min(T,X,TMin).

max([H|T],X):-max(T,X,H),!.
max([],X,X):-!.
max([H|T],X,TMax):-H > TMax -> max(T,X,H);max(T,X,TMax).

swap(N,M,List,X):-swap(N,M,List,[],X),!.
swap(_,_,[],X,X):-!.
swap(N,M,[H|T],NewList,X):-(H =:= N -> append(NewList,[M],NewNewList),swap(N,M,T,NewNewList,X);(H =:= M -> append(NewList,[N],NewNewList),swap(N,M,T,NewNewList,X);append(NewList,[H],NewNewList),swap(N,M,T,NewNewList,X))),!.

zad17(N):-read_list(List,N),min(List,X),max(List,Y),swap(X,Y,List,NewList),write_list(NewList).

%task18.
zad18(N):-read_list(List,N),shift(List, NewList),write_list(NewList).

%task19.
count_chet(List,X):-count_chet(List,X,0).
count_chet([],X,X):-!.
count_chet([H|T],X,TCount):-(H mod 2 =:= 0 -> NewTCount is TCount+1,count_chet(T,X,NewTCount);count_chet(T,X,TCount)),!.
zad19(N):-read_list(List,N),count_chet(List,X),write(X).

%task20.
list_el_belong(List,A,B,NewList):-list_el_belong(List,A,B,NewList,[]),!.
list_el_belong([],_,_,NewList,NewList):-!.
list_el_belong([H|T],A,B,NewList,TList):-(A =< H,B >= H -> append(TList,[H],NewTList),list_el_belong(T,A,B,NewList,NewTList);list_el_belong(T,A,B,NewList,TList)),!.

zad20(N):-read_list(List,N),read(A),read(B),list_el_belong(List,A,B,NewList),write_list(NewList).
