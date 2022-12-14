using ControleDeContatos.Data;
using SiteControleContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteControleContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;   
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.SetSenhaHash();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if(usuarioDB == null)
            {
                throw new Exception("Houve um erro na Atualização do usuario.");
            }
            else
            {
                usuarioDB.Nome = usuario.Nome;
                usuarioDB.Login = usuario.Login;
                usuarioDB.Email = usuario.Email;
                usuarioDB.Perfil = usuario.Perfil;
                usuarioDB.DataAlteracao = DateTime.Now;

                _context.Usuarios.Update(usuarioDB);
                _context.SaveChanges();

                return usuarioDB;
            }
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro ao deletar o usuario");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }

    }
}
