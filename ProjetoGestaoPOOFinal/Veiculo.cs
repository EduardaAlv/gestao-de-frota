using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ProjetoGestaoDeFrota
{
    abstract class Veiculo
    {
        #region Atributos
        private string _placa;
        private IAbastecimento _tanque;
        private double _capacidadeTanque;
        private double _quantidadeLitrosAtual;
        private double _gastoComCombustivel;
        private static double _gastoTotal;
        private List<String> _abastecimentosDoDia = new List<String>();

        public string Placa { get => _placa; set => _placa = value; }
        public double CapacidadeTanque { get => _capacidadeTanque; set => _capacidadeTanque = value; }
        public double QuantidadeLitrosAtual { get => _quantidadeLitrosAtual; set => _quantidadeLitrosAtual = value; }
        public double GastoComCombustivel { get => _gastoComCombustivel; set => _gastoComCombustivel = value; }
        internal IAbastecimento Tanque { get => _tanque; set => _tanque = value; }
        public double GastoTotal { get => _gastoTotal; set => _gastoTotal = value; }
        public List<string> AbastecimentosDoDia { get => _abastecimentosDoDia; set => _abastecimentosDoDia = value; }
        #endregion

        #region Construtor
        public Rota rota = new Rota();
        public Veiculo(string placa, double capacidadeTanque, IAbastecimento tanque)
        {
            Placa = placa;
            CapacidadeTanque = capacidadeTanque;
            Tanque = tanque;
            QuantidadeLitrosAtual = CapacidadeTanque;
            GastoComCombustivel = CapacidadeTanque * Tanque.valorLitro();
            GastoTotal += GastoComCombustivel;
        }
        #endregion

        public double reabastecer(double _litros)
        {

            QuantidadeLitrosAtual += _litros;
            GastoComCombustivel += (_litros * Tanque.valorLitro());
            GastoTotal += (_litros * Tanque.valorLitro());

            return QuantidadeLitrosAtual;

        }
        public abstract void addRota(DateTime data, int kmRota);

        public string Relatorio()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Placa: " + Placa + "\n \n");
            foreach (string obj in AbastecimentosDoDia) 
            {
                builder.Append(obj).Append("\n"); 
            }
            builder.Append("__________________________");
            string result = builder.ToString();
            return result;
        }
            
          

        #region ToString para retorno
        public override string ToString()
        {
            return "Veículo: " + Placa + ", Total: R$" +
        GastoComCombustivel.ToString("F2", CultureInfo.InvariantCulture) +
        ", Odometro Total: " + rota.OdometroTotal + " Km";
        }


        #endregion
    }
}
