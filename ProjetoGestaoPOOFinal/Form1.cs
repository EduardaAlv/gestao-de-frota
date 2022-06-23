using ProjetoGestaoDeFrota;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;

namespace ProjetoGestãoPOOFinal
{
    public partial class Form1 : Form
    {
        List<Veiculo> aux = new List<Veiculo>();

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region StreamReader
            string placas;
            string tipo;

            StreamReader dados = new StreamReader(@"C:\repos\dadosCarrosPOO.txt");
      
            String linhas = dados.ReadLine();

            while (linhas != null)
            {
                string[] det = linhas.Split(';');
                placas = det[0];
                tipo = det[1];
                switch (tipo)
                {
                    case "0":
                        Carro carro = new Carro(placas);
                        aux.Add(carro);
                        break;
                    case "1":
                        Van van = new Van(placas);
                        aux.Add(van);
                        break;
                    case "2":
                        Furgao furgao = new Furgao(placas);
                        aux.Add(furgao);
                        break;
                    case "3":
                        Caminhao caminhao = new Caminhao(placas);
                        aux.Add(caminhao);
                        break;
                }
                linhas = dados.ReadLine();
            }
            dados.Close();

            string vPlaca;
            int kmrot = 0;
            DateTime data;
            int contador = 0;

            StreamReader dadosRota = new StreamReader(@"C:\repos\dadosRotaPOO.txt");
            String linha = dadosRota.ReadLine();

            while (linha != null)
            {
                string[] det1 = linha.Split(';');
                data = Convert.ToDateTime(det1[0]);
                vPlaca = det1[1];
                kmrot = Convert.ToInt32(det1[2]);

                while (contador < aux.Count)
                {
                    if (det1[1].CompareTo(aux[contador].Placa) == 0)
                    {
                        aux[contador].addRota(data, kmrot);
                        contador = 100;
                    }
                    else
                    {
                        contador++;
                    }
                }
                contador = 0;
                linha = dadosRota.ReadLine();
            }
            dadosRota.Close();
            #endregion
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            double calc = 0;
            int numero = 0;

            while (numero < aux.Count)
            {
                calc += Convert.ToDouble(aux[numero].GastoComCombustivel);
                Console.WriteLine(aux[numero]);
                numero++;
            }
            MessageBox.Show("\nR$" + calc.ToString("F2", CultureInfo.InvariantCulture), "Gasto total da empresa");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string maiorgasto = "";
            double maior = 0.0;
            int cont = 0;
            foreach (Veiculo obj in aux)
            {
                if (aux[cont].GastoComCombustivel > maior)
                {
                    maior = Convert.ToDouble(aux[cont].GastoComCombustivel);
                    maiorgasto = Convert.ToString(aux[cont].Placa);
                }
                cont++;
            }
            MessageBox.Show("\nVeículo: " + maiorgasto + ", Valor: R$" + maior.ToString("F2", CultureInfo.InvariantCulture), "Maior gasto com combustível");
        }
        
       
        private void button4_Click(object sender, EventArgs e)
        {
           MessageBox.Show(aux[0].Relatorio(),"Relatório");
        }


       
        private void button3_Click(object sender, EventArgs e)
        {           
            MessageBox.Show((aux[0].GastoTotal).ToString(), "GastoTotal");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
