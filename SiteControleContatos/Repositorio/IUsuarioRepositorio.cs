using SiteControleContatos.Models;
using System.Collections.Generic;

namespace SiteControleContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorEmailELogin(string email, string login);
        UsuarioModel BuscarPorLogin(string login);  
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int id);
    }

}
