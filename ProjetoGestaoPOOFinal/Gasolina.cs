using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGestaoDeFrota
{
    class Gasolina : IAbastecimento
    {
        #region Atributos
        private static double _valorLitro;
        private double _consumo;

        public double Consumo { get => _consumo; set => _consumo = value; }
        public double ValorLitro { get => _valorLitro; set => _valorLitro = value; }
        #endregion

        #region Construtores
        public Gasolina(double consumo)
        {
            Consumo = consumo;
            ValorLitro = 4.199;
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
