using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.DAL.DAO
{
    public interface IUsuarioDAO
    {
        // Create
        void Inserir(Usuario usuario);
        // Read
        List<Usuario> ObterTodos();
        Usuario ObterPorId(string id);
        Usuario ObterPorLogin(string login);
        // Update
        void Atualizar(string id, Usuario novoUsuario);
        // Delete
        void Excluir(string id);
    }
}
