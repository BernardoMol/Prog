let popup = prompt('Qual sua idade?') // o prompt joga na tela, o valor que entrar é jogado na variavel.
console.log(popup) //

alert('Este é um alerta')


//Continue - pula uma iteração


for(let i=10; i>0; i--){
    if(i%2 == 0){
        console.log('Iteração interrompida por ser PAR');
        continue
    }
    console.log(i)
}


for(let j=20; j>0; j-=3){
    if(j%2 == 0){
        continue
        console.log('Iteração interrompida por ser PAR'); // não vai rodar pq o continue esta antes dele
    }
    console.log(j)
}


let nome = prompt('Digite seu nome')
switch (nome) {
    case 'Mol':
        console.log("Seu nome é Mol")
        break;
    case "Borges":
        console.log('Seu nome é Borges')
    break;

    default: 
        console,localStorage('Vaza')
        break;
}

nome = prompt('Digite seu nome')
switch (nome) {
    case 'Mol':
        console.log("Seu nome é Mol");
    case "Borges":
        console.log('Sem o break ele continua')
    break;

    default: 
        console,localStorage('Mas não passa aqui, pq tem um break no caso anterior')
        break;
}