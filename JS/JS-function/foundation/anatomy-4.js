// IIEF Imediately Invoked Function Expression
(function (a,b,c){
    console.log(`Result: ${a+b+c}`)
})(5,6,14);
//Se tiver mais de uma IIFE precisa colocar ";" ao final dela
(function (a,b,c){
    console.log(`Result: ${a+b+c}`)
})(5,6,14);

//Formato arrow
( (a,b,c) => console.log(`Result: ${a*b*c}`))(4,5,3);

//( (a,b,c) => t = a*b*c console.log(`Result: ${t}`))(4,5,3); // não funciona

( (a,b,c) => t = a*b*c)(10,5,3);
console.log(`Result: ${t}`)



