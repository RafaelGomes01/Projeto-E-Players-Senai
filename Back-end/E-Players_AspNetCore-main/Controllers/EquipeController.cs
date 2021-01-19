using System;
using System.IO;
using E_Players_AspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_AspNetCore.Controllers
{
    // Definir a pagina --> https>//localhost:5001/Equipe
    [Route("Equipe")]

    public class EquipeController : Controller
    {
        // Instanciar a classe Equipe
        Equipe equipeModel = new Equipe();
        
        // Definir a pagina --> https>//localhost:5001/Equipe/Listar
        [Route("Listar")]           
        
        // Metodo que defini recursos do controlador
        public IActionResult Index(){
            // ViewBag - Um pacote que armazena informações que passaram para a view
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }

        // Definir a pagina --> https>//localhost:5001/Equipe/Cadastrar
        [Route("Cadastrar")]
        
        // Metodo para Cadastrar uma equipe via Front-End
        public IActionResult Cadastrar(IFormCollection form){
            
            // Nova Instancia de Equipe
            Equipe novaEquipe = new Equipe();

            // Passar os dados dos formularios para os atributos da classe Equipe
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            
            // Conseguir pegar o upload da imagem
            // Verificando se o usuario anexou um arquivo
            if(form.Files.Count > 0){ // Count - Não tem dados = 0 // Se tiver um arquivo = 1
               
                // Armazenar o arquivo na variavel 
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                // Criar a pasta caso não exista
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }
                //                              localhost:5001    +      wwwroot/img/ + Equipes + equipe.jpg  
                var PATH = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                // Pegando o arquivo e salvando em um determinado local (Strem)
                using(var stream = new FileStream(PATH, FileMode.Create)){
                    file.CopyTo(stream);
                }

                // Adicionar o nome da imagem para o objeto da equipe
                novaEquipe.Imagem = file.FileName;

            }else{
                novaEquipe.Imagem = "padrao.png";
            }

            // Adicionando os dados da nova equipe no CSV
            equipeModel.Create(novaEquipe);

            // Atualizando a lista Equipes
            ViewBag.Equipes = equipeModel.ReadAll();

            // Redirecionando para a mesma pagina
            return LocalRedirect("~/Equipe/Listar");
        }

        // Definir a pagina --> https>//localhost:5001/Equipe/1
        [Route("{id}")]

        // Metodo para Deletar 
        public IActionResult Excluir(int id){
            equipeModel.Delete(id);

            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe/Listar");
        }


    }
}