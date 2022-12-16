using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Funcionario : Pessoa
    {
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        public Funcionario(string cpf, string nome, string endereco, string telefone,string login, string senha)
            : base(telefone, endereco,nome,cpf)
        {
            this.login = login;
            this.senha = senha;
        }

    }
}
