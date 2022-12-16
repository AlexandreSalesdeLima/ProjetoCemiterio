using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoCemiterio.classesBasicas
{
    class Funeral
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime tpFuneral;

        public DateTime TpFuneral
        {
            get { return tpFuneral; }
            set { tpFuneral = value; }
        }

        public Funeral(int id, DateTime tpFuneral)
        {
            this.id = id;
            this.tpFuneral = tpFuneral;
        }
        public Funeral()
        {
 
        }
    }
   
}
