using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAtos_DesafioWF_Estacionamento.Classes
{
    public static class Persistencia
    {
        private const string VeiculosEntradaFile = @"D:\LEANDRO\CURSOS\AcademiaAtosNET2023\Aula24\AcademiaAtos_DesafioWF_Estacionamento\veiculosEntrada.dat";
        private const string VeiculosSaidaFile = @"D:\LEANDRO\CURSOS\AcademiaAtosNET2023\Aula24\AcademiaAtos_DesafioWF_Estacionamento\veiculosSaida.dat";

        public static List<Veiculo> LerArquivoVeiculosEntrada()
        {
            List<Veiculo> veiculosEntrada = new List<Veiculo>();

            if (File.Exists(VeiculosEntradaFile))
            {
                string[] linhas = File.ReadAllLines(VeiculosEntradaFile);

                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(';');

                    if (dados.Length == 4)
                    {
                        string placa = dados[0];
                        string modeloVeiculo = dados[1];
                        DateTime dataEntrada = DateTime.Parse(dados[2]);
                        TimeSpan horaEntrada = TimeSpan.Parse(dados[3]);

                        Veiculo veiculo = new Veiculo(placa, modeloVeiculo, dataEntrada, horaEntrada);
                        veiculosEntrada.Add(veiculo);
                    }
                }
            }

            return veiculosEntrada;
        }

        public static List<Veiculo> LerArquivoVeiculosSaida()
        {
            List<Veiculo> veiculosSaida = new List<Veiculo>();

            if (File.Exists(VeiculosSaidaFile))
            {
                string[] linhas = File.ReadAllLines(VeiculosSaidaFile);

                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(';');

                    if (dados.Length == 6)
                    {
                        string placa = dados[0];
                        string modeloVeiculo = dados[1];
                        DateTime dataEntrada = DateTime.Parse(dados[2]);
                        TimeSpan horaEntrada = TimeSpan.Parse(dados[3]);
                        int tempoPermanencia = int.Parse(dados[4]);
                        decimal valorCobrado = decimal.Parse(dados[5]);

                        Veiculo veiculo = new Veiculo(placa, modeloVeiculo, dataEntrada, horaEntrada)
                        {
                            TempoPermanencia = tempoPermanencia,
                            ValorCobrado = valorCobrado
                        };

                        veiculosSaida.Add(veiculo);
                    }
                }
            }

            return veiculosSaida;
        }

        public static void GravarArquivoVeiculosEntrada(List<Veiculo> veiculosEntrada)
        {
            using (StreamWriter sw = new StreamWriter(VeiculosEntradaFile))
            {
                foreach (Veiculo veiculo in veiculosEntrada)
                {
                    string linha = $"{veiculo.PlacaVeiculo};{veiculo.ModeloVeiculo};{veiculo.DataEntrada:d/MM/yyyy};{veiculo.HoraEntrada:h\\:mm}";
                    sw.WriteLine(linha);
                }
            }
        }

        public static void GravarArquivoVeiculosSaida(List<Veiculo> veiculosSaida)
        {
            using (StreamWriter sw = new StreamWriter(VeiculosSaidaFile))
            {
                foreach (Veiculo veiculo in veiculosSaida)
                {
                    string linha = $"{veiculo.PlacaVeiculo};{veiculo.ModeloVeiculo};{veiculo.DataEntrada:d/MM/yyyy};{veiculo.HoraEntrada:h\\:mm};{veiculo.TempoPermanencia};{veiculo.ValorCobrado}";
                    sw.WriteLine(linha);
                }
            }
        }

        public static void RemoverVeiculoDoArquivo(Veiculo veiculo)
        {
            string linhaRemover = $"{veiculo.PlacaVeiculo};{veiculo.ModeloVeiculo};{veiculo.DataEntrada:d/MM/yyyy};{veiculo.HoraEntrada:h\\:mm}";

            string[] linhas = File.ReadAllLines(VeiculosEntradaFile);

            using (StreamWriter sw = new StreamWriter(VeiculosEntradaFile))
            {
                foreach (string linha in linhas)
                {
                    if (linha != linhaRemover)
                    {
                        sw.WriteLine(linha);
                    }
                }
            }
        }


    }
}
