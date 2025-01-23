//aula do vídeo: https://www.youtube.com/watch?v=PyrMT0GA3sE
// instalado express
import { PrismaClient } from '@prisma/client'
import express from 'express'

const app = express()
const users = []
const prisma = new PrismaClient()
app.use(express.json())

/* 
    Criar usuario
    listar usuarios
    editar um usuario
    editar mais de um usuario
    deletar um usuario
    
*/

// 1- verbo http (get, post, put, patch, delete) 2- endereços
// Sempre que acessamos um endereço no navegador, por padrão, acessamos com o mpetodo GET
// Só pode um res e por metodo...(meio óbvio até)
app.post('/usuarios', async (req, res) => {
    //console.log(req) // mostra um monte de informação
    //console.log(req.body) // mostra só o conteudo do body
    //users.push(req.body) // funciona, porém, sempre que o servidor é resetado, os dados se perdem. POR ISSO PRECISAMOS DE UM BANCO
    //res.send('Ok. postei/mandei/perguntei')
    await prisma.user.create({ // "await" requisição assincrona, nao tem como saber quanto tempo vai levar
        data:{
            "name": req.body.name,
            "email": req.body.email,
            "age": req.body.age
        }
    })
    res.status(201).send('Ok. postei/mandei/perguntei') //201 = ok e fiz o que voce pediu
})

app.get('/usuarios', async (req, res) => {
    let users = []

    if(req.query){
        users = await prisma.user.findMany({
            where:{
                name: req.query.name,
                email: req.query.email,
                age: req.query.age,

            }
        })
    }
    else{
        users = await prisma.user.findMany()
    }
    
    console.log(users)
    res.status(200).json(users) //200 = ok
})

// app.get('/usuarios', async (req, res) => {
//     console.log(req)
//     const users = await prisma.user.findMany()
//     res.status(200).json(users) //200 = ok
// })


// app.post('/usuarios') // imagino que esta linha pode ser deletada

// Defino uma porta/servidor - No caso, a porta virtual 3000 do meu pc
app.listen(3000) // http://localhost:3000/usuarios

app.put('/usuarios/:variavelDeIdentificacao', async (req, res) => {
    await prisma.user.update({ // "await" requisição assincrona, nao tem como saber quanto tempo vai levar
        where:{
            email: req.params.variavelDeIdentificacao
        },
        data:{
            "name": req.body.name,
            "email": req.body.email,
            "age": req.body.age
        }
    })
    res.status(202).json(users) 
}) 

app.delete('/usuarios/:id', async (req, res) => {
    await prisma.user.delete({ // "await" requisição assincrona, nao tem como saber quanto tempo vai levar
        where:{
            id: req.params.id
        }
    })
    res.status(203).json({message: "Usuário Deletado"}) 
}) 




/* 
    Sobre as REQUISIÇÕES:
    São 3 tipos de formas de fazer as requisições de dados
    * Query - funciona com o GET --> usa interrogação "?" na URL --> servidor.com/usuarios?estado=bahia&cidade=salvador
    * Route - funciona com GET/PUT/DELETE --> é algo mais especifico, um elemento/objeto apenas, geralmente usam o "id", tambem aparece na URL
            -- get servidor.com/usuarios/22
            -- put servidor.com/usuarios/22
            -- delete servidor.com/usuarios/22
    Body - funciona com POST e PUT --> Quando o volume de informações é muito grande, ou quando são informações mais sensíveis pois NÃO APARECE NA URL 
        (informações do usuario, por exemplo)
            -- {
                "id": "64b9",    
                "nome": "Rodolfo',
                "idade": 27,
                "email": "rodolfo@gmail.com" 
            }

*/

/*
    Sobre RESPOSTAS:
    2xx --> Sucesso
    4xx --> Erro CLIENTE (front)
    5xx --> Erro SERVIDOR (back)
*/

/*
    usuario banco: bancoapinodeexpress
    senha banco: bernardobcmb
*/

// para fazer a conexão com o mongo, usaremos a extensão prisma "npm install prisma" "--save-dev"
// schema é a PADRONIZAÇÃO dos dados e do formato dos dados que serão enviados para o banco
// comando para quando as configurações do banco estiverem certas tanto nos arquivos prisma quanto no banco em si: npx prisma db push

// RODANDO: precisamos rodar o arquivo e a conexão com o banco
// 1- node server.js
// 2- npx prisma db push
// 3 - node --watch server.js (serve para quando alterar o codiugo e salvar, o server reiniciar sozinho)