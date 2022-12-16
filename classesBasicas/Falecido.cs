using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Falecido
    {
        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }
        private int idade;

        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        /*
        private string localizacao;

        public string Localizacao
        {
            get { return localizacao; }
            set { localizacao = value; }
        }*/
            
        public Falecido() { }

        public Falecido(string cpf, string nome, int idade, DateTime data)//,string localizacao
        {
            this.cpf = cpf;
            this.idade = idade;
            this.data = data;
            this.nome = nome;
            //this.localizacao = localizacao;
        }
    }
}
