using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Pessoa
    {
          private string telefone;

        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public Pessoa(string cpf, string nome, string endereco, string telefone)
        {
            this.telefone = telefone;
            this.endereco = endereco;
            this.nome = nome;
            this.cpf = cpf;
         

        }

        public Pessoa()
        {

        }
    }
}
