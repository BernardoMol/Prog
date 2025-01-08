//Declartação de função

//=====================================================================//
sayHello()
function sayHello(){
    console.log('Hello!')
}
sayHello() 

let x = sayHello()
console.log(x)
//=====================================================================//
function sayHelloTo(name){
    console.log('Hello ' + name)
}
sayHelloTo('Mike')

function sayHelloTo2(name){
    console.log(`Hello ${name} !!`)
}
sayHelloTo2('Mike')
//=====================================================================//
function returnHi(){
    return "hi"
}
returnHi() // nada aparece
// let x = returnHi() // --> da erro, porque ja existe um "x", não da pra criar dnv 
x = returnHi()
console.log(x)
let xx = returnHi()
console.log(xx)
 console.log(returnHi() + " 2 ")
 //=====================================================================//
 function returnHiTo(name){
    return `Hi ${name}`
 }
 let nome = 'Marcos 1°'
 console.log(returnHiTo(nome))
 console.log(returnHiTo('Marcos'))