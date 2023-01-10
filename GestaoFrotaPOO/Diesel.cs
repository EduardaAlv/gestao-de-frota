using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGestaoDeFrota
{
    class Diesel : IAbastecimento
    {
        #region Atributos
        private static double _valorLitro;
        private double _consumo;

        public double Consumo { get => _consumo; set => _consumo = value; }
        public double ValorLitro { get => _valorLitro; set => _valorLitro = value; }
        #endregion

        #region Construtores
        public Diesel(double consumo)
        {
            Consumo = consumo;
            ValorLitro = 3.599;
        }
        #endregion

        #region Métodos
        public double consumo()
        {
            return Consumo;
        }
        public double valorLitro()
        {
            return ValorLitro;
        }
        #endregion
    }
}
