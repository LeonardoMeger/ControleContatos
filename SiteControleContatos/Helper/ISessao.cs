using SiteControleContatos.Models;

namespace SiteControleContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuairo();
        UsuarioModel BuscarSessaoUsuario();

    }
}
