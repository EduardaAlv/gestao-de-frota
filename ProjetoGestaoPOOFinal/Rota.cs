using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ProjetoGestaoDeFrota
{
    class Rota
    {
        private double _KmRota;
        private DateTime data;
        private double _odometroTotal;

        public Rota()
        {
          
        }

        public double KmRota { get => _KmRota; set { _KmRota = value; _odometroTotal += KmRota; } }
        public DateTime Data { get => data; set => data = value; }
        public double OdometroTotal { get => _odometroTotal; }

        public override string ToString()
        {
            return data.ToString("dd-MM-yyyy");
        }
    }
}

