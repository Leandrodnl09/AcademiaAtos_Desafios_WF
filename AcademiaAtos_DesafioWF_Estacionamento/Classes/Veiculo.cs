using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAtos_DesafioWF_Estacionamento.Classes
{
    public class Veiculo
    {
        public string PlacaVeiculo { get; set; }
        public string ModeloVeiculo { get; set; }
        public DateTime DataEntrada { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public int TempoPermanencia { get; set; }
        public decimal ValorCobrado { get; set; }

        public Veiculo(string placaVeiculo, string modeloVeiculo, DateTime dataEntrada, TimeSpan horaEntrada)
        {
            PlacaVeiculo = placaVeiculo;
            ModeloVeiculo = modeloVeiculo;
            DataEntrada = dataEntrada;
            HoraEntrada = horaEntrada;
        }
    }
}
