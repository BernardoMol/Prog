class Tabelas {
    init(conexao){
        this.conexao = conexao;
        this.creiarTabelaObjetos();
    }
    creiarTabelaObjetos(){
        const sql = 
        `
        IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ObjetosEmSQL')
        BEGIN
        CREATE TABLE ObjetosEmSQL (
            id SMALLINT IDENTITY,
            name VARCHAR(50) NOT NULL,
            age INT NOT NULL,
            CONSTRAINT pk_id_objeto PRIMARY KEY (id),
            CONSTRAINT uq_name UNIQUE (name)  -- Garantir que o nome seja único
        );
        END
        `;
        this.conexao.query(sql, (error) => {
            if(error){
                console.log("Erro ao criar tabela");
                console.log(error.message);
                return;
            }
            console.log("Tabela Criada com Sucesso");
        })
    }
}

module.exports = new Tabelas();