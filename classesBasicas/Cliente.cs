using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Cliente : Pessoa
    {
        public Cliente() { }

        public Cliente(string cpf, string nome, string endereco, string telefone):base(cpf, nome, endereco, telefone)
        {
            
        }

    }
}
