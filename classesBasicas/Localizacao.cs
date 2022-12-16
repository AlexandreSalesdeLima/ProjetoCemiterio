using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Localizacao
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public Localizacao() { }

        public Localizacao(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
      
    }
}
