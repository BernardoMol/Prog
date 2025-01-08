//Aula de Expressão de função 00:14 a 00:14
// Função anonima -> não dou nome a ela....preciso coloca-la dentro de parenteses, ou cria-la de outra forma.
(function (a, b, c){
    return a+b+c
})
// Criando a anonima dentro de uma variavel
let soma = function(a, b){
    return a+b
}
 
console.log(soma(3, 4))

let anotherSum = soma   // não funciona porque quando chamamos acima, nao atribuimos o valor 7 a ninguem, então ele nao foi salvo.
console.log(anotherSum) // o valor de retorno não fica guardado na função.
// console.log(a)       // assim como os valores do parametros tambem não ficam guardados na função.
                        // Foi a FUNÇÃO que foi guardada em "anotherSum", não foi o resultado da função.
console.log(anotherSum(10, 11))

anotherSum = soma (2, 8) // agora, foi o VALOR RETORNADO pela função que foi guardado na variável "anotherSum"
console.log(anotherSum)