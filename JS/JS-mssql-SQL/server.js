//https://www.youtube.com/watch?v=YuhKhkQqtP8

const sql = require("mssql/msnodesqlv8")

var config = {
    server: 'DESKTOP-DV5DOKH\\SQLEXPRESS',           // Nome ou IP do servidor
    database: 'BancoLocal',        // Nome do banco de dados ajustado para 'BancoLocal'
    driver: "msnodesqlv8",
    options: {
      trustedConnection: true
    }   
}

// var config = {
//     server: 'DESKTOP-DV5DOKH\\SQLEXPRESS',           // Nome ou IP do servidor
//     database: 'BancoLocal',        // Nome do banco de dados ajustado para 'BancoLocal'
//     driver: "msnodesqlv8",
//     user: "sa",
//     password: '1234',
//     options: {
//       trustedConnection: true
//     }   
// }

sql.connect(config, function(error){
    if(error)console.log(error)
    var request = new sql.Request();
    request.query("SELECT * FROM ObjetosEmSQL", function(error,records){
        if(error)console.log(error)
        else console.log(records)
    })
})