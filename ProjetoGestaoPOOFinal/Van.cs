﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ProjetoGestaoDeFrota
{
    class Van : Veiculo
    {
        #region Construtor
        public Van(string placa) : base(placa, 60, new Gasolina(7))
        {

        }
        #endregion

        #region Métodos
        public override void addRota(DateTime data, int Kmrota)
        {
            if (Kmrota > (CapacidadeTanque * Tanque.consumo()))
            {
                // Retorno para informar impossibilidade de percurso
            }
            else
            {
                if (Kmrota < (QuantidadeLitrosAtual * Tanque.consumo()))
                {
                    double quantGasto = Kmrota / Tanque.consumo();
                    QuantidadeLitrosAtual -= quantGasto;
                    rota.Data = data;
                    rota.KmRota = Kmrota;
                }
                else
                {
                    double _litrosParaAbastecer = (Kmrota / Tanque.consumo()) - QuantidadeLitrosAtual;
                    reabastecer(_litrosParaAbastecer);
                    rota.Data = data;
                    rota.KmRota = Kmrota;
                    AbastecimentosDoDia.Add(" Dia: " + rota.Data.ToShortDateString() + ", Litros: " + _litrosParaAbastecer.ToString("F2", CultureInfo.InvariantCulture));
                    QuantidadeLitrosAtual -= (Kmrota / Tanque.consumo());
                }
            }
        }
        #endregion
    }
}
