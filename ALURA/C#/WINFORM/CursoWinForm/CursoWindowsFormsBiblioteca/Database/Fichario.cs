using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Database
{
    public class Fichario
    {
        public string diretorio;
        public string mensagem;
        public bool status;

        public Fichario(string Diretorio)
        {
            status = true;
            try
            {
                if (!(Directory.Exists(Diretorio)))
                {
                    Directory.CreateDirectory(Diretorio);
                }
                diretorio = Diretorio;
                mensagem = "Conexão com o Fichario criada com sucesso.";
                status = true;
            }
            catch (Exception ex)
            {
                status = false;                
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }    
        }

        public void Incluir(string Id, string jsonUnit)
        {
            try
            {
                status = true;
                if (File.Exists(diretorio + "\\" + Id + ".json"))
                {
                    status = false;
                    mensagem = "Erro de inclusão!!! Identificador " + Id + " já existe!!! ";
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + Id + ".json", jsonUnit);
                    mensagem = "Inclusão EFETUADA!!!";
                    status = true;
                }
            }
            catch(Exception ex) 
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }    

        }

        public string Buscar(string Id) 
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Id + ".json")))
                {
                    status = false;
                    mensagem = "ID não existe:";
                }
                else
                {
                    string conteudo = File.ReadAllText(diretorio + "\\" + Id + ".json");
                    return conteudo;
                }              
                    
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar:" + ex.Message;
            }
            return "";

        }

        public void Apagar(string Id)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Id + ".json")))
                {
                    status = false;
                    mensagem = "ID bnão existe:";
                }
                else
                {
                    File.Delete(diretorio + "\\" + Id + ".json");
                    status = true;
                    mensagem = "Exclusão concluida";
                }

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar:" + ex.Message;
            }
        }

        public void Alterar(string Id, string jsonUnit)
        {
            try
            {
                status = true;
                if ( ! (File.Exists(diretorio + "\\" + Id + ".json") ))
                {
                    status = false;
                    mensagem = "Erro de inclusão!!! Identificador " + Id + " NÃO existe!!! ";
                }
                else
                {
                    // deleto o arquivo antigo e crio um novo
                    File.Delete(diretorio + "\\" + Id + ".json"); 
                    File.WriteAllText(diretorio + "\\" + Id + ".json", jsonUnit);
                    mensagem = "Alteração EFETUADA!!!";
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {
                var arquivos = Directory.GetFiles(diretorio, "*.json");
            
                for (int i = 0; i < arquivos.Length -1; i++)
                {
                    string conteudo = File.ReadAllText(arquivos[i]);
                    List.Add(conteudo);
                }
                return List;

            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar:" + ex.Message;
            }
            return List;

        }

    }
}
