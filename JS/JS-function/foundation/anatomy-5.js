function logParams(a,b,c){
    console.log(a,b,c)
    total = a+b+c
    console.log(`Total = ${total}`)
}

logParams(1,2,3)
logParams(1,2,3,5,6) // não da problema, a linguagem apenas ignorou os outros parametros adicionais
logParams(1,2) // tambem não da problema, mas o ultimo aprametro é indefinido

/*
// Ele altera o valor padrão anres de eu entrar nesse codigo? DOIDERA
function logParams(a = 1,b = 4,c = 5){
    console.log(a,b,c)
    total = a+b+c
    console.log(`Total = ${total}`)
}

logParams()
logParams()
//==========================================================================
*/

function logParams2(a = 1,b = 4,c = 5){
    console.log(a,b,c)
    total = a+b+c
    console.log(`Total = ${total}`)
}
logParams2()
logParams2(6)
logParams2(6,10)
logParams2(6,9,10)

// Quantidades FLEXIVEL de valores de entrada na função
 function numeros(entrada){
    for(let n of entrada){
        console.log(entrada) // exibe o vetor
    }
 }

numeros([1, 2, 3, 4, 5]) // formato array para entrar

function numeros1(entrada){
    for(let n of entrada){
        console.log(n)      // precisa entrar com formato array 
    }
 }

numeros1([22, 33, 44, 4, 5]) // precisa entrar com formato array 

function numeros2(...entrada){
    for(let n of entrada){
        console.log(entrada)
    }
 }

numeros2(2, 2, 3, 4, 5) // a entrada será tratada como array, independente do que voce esta colocando
numeros2( [1, 4], 2, 2, 3, 4, 5) // a entrada será tratada como array, independente do que voce esta colocando