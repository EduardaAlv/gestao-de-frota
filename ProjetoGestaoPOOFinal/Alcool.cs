using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGestaoDeFrota
{
    class Alcool : IAbastecimento
    {
        #region Atributos
        private static double _valorLitro;
        private double _consumo;

        public double Consumo { get => _consumo; set => _consumo = value; }
        public double ValorLitro { get => _valorLitro; set => _valorLitro = value; }
        #endregion

        #region Construtores
        public Alcool(double consumo)
        {
            Consumo = consumo;
            ValorLitro = 2.899;
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
