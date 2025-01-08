
function range(inicial, final, passo){

        if(passo == undefined){
            passo = 1
        }
       
        if(final == undefined){
            let vetor = []
            let acumulador = 0
            for(let n = 0; n < inicial; n++){
                acumulador = acumulador + passo 
                vetor [n] =  acumulador
            }
            return vetor
        }
        
        if(inicial < final){
            let vetor = []
            let acumulador = inicial
            for(let n = 0; n <= ((final - inicial)/passo); n++){
               if(acumulador <= final){
                vetor [n] =  acumulador
               }
                acumulador = acumulador + passo 
            }
            return vetor
        }
        else{
            let vetor = []
            let acumulador = inicial
            for(let n = 0; n <= ((inicial - final)/passo); n++){
                if(acumulador => final){
                    vetor [n] =  acumulador
                   }
                acumulador = acumulador - passo 
            }
            return vetor
        }
        
        
}

console.log(range(5))
console.log(range(6,11))
console.log(range(10,19,2))
console.log(range(6,2))
console.log(range(8,-3,4))
/* // o vetor no JS começa pelo "0" não pelo "1"
a = range(3)
console.log(a)
*/
