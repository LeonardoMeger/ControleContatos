using SiteControleContatos.Enums;
using SiteControleContatos.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a Senha do usuario")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao  { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novasSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novasSenha.GerarHash();
            return novasSenha;
        }
    }
}
