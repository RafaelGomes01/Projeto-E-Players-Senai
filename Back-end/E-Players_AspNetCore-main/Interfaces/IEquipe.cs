using System.Collections.Generic;
using E_Players_AspNetCore.Models;

namespace E_Players_AspNetCore.Interfaces
{
    public interface IEquipe
    {
        // Interface que contem os metodos minimos para a classe Equipe Funcionar

        // Metodos de CRUD
        void Create(Equipe e); // Criar        
        List<Equipe> ReadAll(); // Ler
        void Update(Equipe e); // Atualizar
        void Delete(int id); // Deletar
    }
}