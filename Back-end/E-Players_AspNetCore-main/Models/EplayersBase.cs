using System.Collections.Generic;
using System.IO;

namespace E_Players_AspNetCore.Models
{
    public abstract class EplayersBase
    {
        // Metodo para ver se a pasta que ficara armazendo o arquivo csv, e o proprio arquivo csv estão criados
        // Caso não esteja criado ele cria a pasta com seu diretorio
        public void CreateFolderAndFile(string PATH){
            string folder = PATH.Split("/")[0];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(PATH)){
                File.Create(PATH);
            }
        }

        // Metodo para ler todas as linhas do CSV e retornar como uma lista
        public List<string> ReadAllLinesCSV(string PATH){
            List<string> linhas = new List<string>();

            //using - Abrir e fechar arquivos ou conexões
            // StreamReader - Ler as informações do CSV
            using(StreamReader file = new StreamReader(PATH)){
                string linha;
                while((linha = file.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
    
        // Metodo para adicionar uma linha no arquivo CSV
        public void RewriteCSV(string PATH, List<string> linhas){
            
            using(StreamWriter output = new StreamWriter(PATH)){
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }

        }
    }
}