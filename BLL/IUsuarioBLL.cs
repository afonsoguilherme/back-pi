using System.Collections.Generic;
using back_pi.DAL.DTO;
using back_pi.DAL.Models;

namespace back_pi.BLL
{
    public interface IUsuarioBll
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
