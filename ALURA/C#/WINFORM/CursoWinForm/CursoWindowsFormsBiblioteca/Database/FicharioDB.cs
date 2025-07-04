﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Database
{
    public class FicharioDB
    {
        //string diretorio { get; set; } // agora, o diretorio é a TABELA
        public string tabela;
        public string mensagem;
        public bool status;
        public LocalBDClass db;


        public FicharioDB(string Tabela)
        {
            status = true;
            try
            {
                db = new LocalBDClass();
                tabela = Tabela;
                mensagem = "Conexão com a tabela criada com sucesso";
            }
            catch (Exception ex)
            {
                {
                    status = false;
                    mensagem = "Erro ao conectar à tabela: " + ex.Message;
                }



            }

        }


        public void Incluir(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                // INSERT INTO CLIENTE (ID,JSON) VALUES ( ''000001 , '{...}')
                var SQL = "INSERT INTO " + tabela + " (Id, JSON) VALUES ('" + Id + "', '" + jsonUnit + "')"; // faço as string de comando
                db.SQLComando(SQL);   // dou a ordem
                status = true;
                mensagem = "Inclusão Deu Bom";

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "ERRO NO INCLUIR Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public string Buscar(string Id)
        {
            status = true;
            try
            {
                // SELECT ID, JSON FROM CLIENTE WHERE ID = '000001'
                var SQL = " SELECT Id, JSON FROM " + tabela + " WHERE ID = '"+Id+"' "; // faço as string de comando
                var dt = db.SQLQuery(SQL);   // dou a ordem que volta em formato TABELA!
                if (dt.Rows.Count >0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    mensagem = "Inclusão deu bom !";
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Erro de busca!!! ID: " + Id + " Não encontrado!!! ";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
            return "";

        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {
                // SELECT ID, JSON FROM CLIENTE WHERE ID = '000001'
                var SQL = " SELECT Id, JSON FROM " + tabela; // faço as string de comando
                var dt = db.SQLQuery(SQL);   // dou a ordem que volta em formato TABELA!
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        List.Add(conteudo);
                    }
                    mensagem = "Busca de todos concluída !";
                    return List;
                }
                else
                {
                    status = false;
                    mensagem = "Esta tabela não está populada ";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
            return List;

        }

        public void Apagar(string Id)
        {
            status = true;
            try
            {
                // SELECT ID, JSON FROM CLIENTE WHERE ID = '000001'
                var SQL = " SELECT Id, JSON FROM " + tabela + " WHERE ID = '" + Id + "' "; // faço as string de comando
                var dt = db.SQLQuery(SQL);   // dou a ordem que volta em formato TABELA!
                if (dt.Rows.Count > 0)
                {
                    // DELETE FROM CLIENTE WHERE ID = '000001'
                    SQL = " DELETE FROM " + tabela + " WHERE ID = '" + Id + "' "; // faço as string de comando
                    dt = db.SQLQuery(SQL);
                    mensagem = "Item APAGADO !!! ";
                }
                else
                {
                    status = false;
                    mensagem = "Erro de busca!!! ID: " + Id + " Não encontrado!!! ";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public void Alterar(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                // SELECT ID, JSON FROM CLIENTE WHERE ID = '000001'
                var SQL = " SELECT Id, JSON FROM " + tabela + " WHERE ID = '" + Id + "' "; // faço as string de comando
                var dt = db.SQLQuery(SQL);   // dou a ordem que volta em formato TABELA!
                if (dt.Rows.Count > 0)
                {
                    // UPDATE CLIENTE SET JSON = '{...}' WHERE ID = '000001'
                    SQL = " UPDATE " + tabela + " SET JSON = '"+jsonUnit+"' WHERE ID = '" + Id + "' "; // faço as string de comando
                    dt = db.SQLQuery(SQL);
                    mensagem = "Item ATUALIZADO !!! ";
                }
                else
                {
                    status = false;
                    mensagem = "Erro de busca!!! ID: " + Id + " Não encontrado!!! ";
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }
    }
}
