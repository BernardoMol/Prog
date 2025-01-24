const conexao = require("mysql")

const conexao = mysql.createConection({
    host: "localhost",
    port:3306,
    user:"root",
    password:"",
    database: "ObjetosEmSQL",
});

module.exports = conexao