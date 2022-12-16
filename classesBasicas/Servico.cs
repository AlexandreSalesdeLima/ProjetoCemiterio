using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjetoCemiterio.classesBasicas
{
    class Servico
    {

        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Servico(string tipo, double valor)
        {
            
            this.valor = valor;
            this.tipo = tipo;
        }
        public Servico()
        {
            
        }

    }
}
