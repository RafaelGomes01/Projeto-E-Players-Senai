using System.Collections.Generic;
using System.IO;
using E_Players_AspNetCore.Interfaces;

namespace E_Players_AspNetCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        // Atributos da Classe Equipe
        public int IdEquipe { get; set; } //Exemplo - 1
        public string Nome { get; set; } //Exemplo - "TimeRafaelGomes"
        public string Imagem { get; set; } //Exemplo - "../img/time1.jpg"

        // Localização do Arquivo Equipe.csv "Banco de dados" da classe Equipe
        private const string PATH = "Database/Equipe.csv";

        // Metodo Contrutor para criação de Pasta e Arquivo CSV
        public Equipe(){
            CreateFolderAndFile(PATH);
        }

        // Metodo para criar equipes
        public void Create(Equipe e){
            string[] linhas = {PrepareLineCSV(e)};
            File.AppendAllLines(PATH, linhas);
        }

        // Metodo que prepara a linha csv para ser adicionada pelo metodo Create() 
        private string PrepareLineCSV(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        // Metodo para Ler as Equipes
        public List<Equipe> ReadAll(){
            List<Equipe> equipes = new List<Equipe>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach (var item in linhas){
                // 1;vivo;vivo.jpg
                string[] linha = item.Split(";");

                // [0] = 1, [1] = vivo, [2] = vivo.jpg
                
                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }
 
        // Metodo para Atualizar as equipes no arquivo CSV
        public void Update(Equipe e){
             List<string> linhas = ReadAllLinesCSV(PATH);
             linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
             linhas.Add(PrepareLineCSV(e));
             RewriteCSV(PATH, linhas);
        }

        // Metodo para Deletar as Equipes no arquivo CSV
        public void Delete(int id){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}