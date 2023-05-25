using AcademiaAtos_DesafioWF_Estacionamento.Classes;

namespace AcademiaAtos_DesafioWF_Estacionamento
{
    public partial class Form1 : Form
    {
        private List<Veiculo> veiculosEntrada;
        private List<Veiculo> veiculosSaida;
        private System.Windows.Forms.Timer timer;

        public Form1()
        {
            InitializeComponent();

            // Inicializar o timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1000 milissegundos = 1 segundo
            timer.Tick += TimerTick;
            timer.Start();

            // Leia os dados dos arquivos e atribua às listas
            veiculosEntrada = Persistencia.LerArquivoVeiculosEntrada();
            veiculosSaida = Persistencia.LerArquivoVeiculosSaida();

            // Atualize as listas de veículos na interface gráfica
            AtualizarListasVeiculos();
        }

        private void AtualizarListasVeiculos()
        {
            // Limpe as caixas de texto das listas de veículos
            textBoxListaVeiculosEntrada.Clear();
            textBoxListaVeiculosSaida.Clear();

            // Preencha as caixas de texto com os veículos de entrada e saída
            foreach (Veiculo veiculo in veiculosEntrada)
            {
                textBoxListaVeiculosEntrada.AppendText($"{veiculo.PlacaVeiculo} - {veiculo.ModeloVeiculo} - {veiculo.DataEntrada:d/MM/yyyy} - {veiculo.HoraEntrada:h\\:mm}" + Environment.NewLine);
            }

            foreach (Veiculo veiculo in veiculosSaida)
            {
                textBoxListaVeiculosSaida.AppendText($"{veiculo.PlacaVeiculo} - {veiculo.ModeloVeiculo} - {veiculo.TempoPermanencia} minutos - {veiculo.ValorCobrado:c}" + Environment.NewLine);
            }
        }

        private void buttonEntrada_Click(object sender, EventArgs e)
        {
            string placa = textBoxPlaca.Text.ToUpper();
            string modeloVeiculo = textBoxModelo.Text.ToUpper();

            // Verificar se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(placa) || string.IsNullOrWhiteSpace(modeloVeiculo))
            {
                // Exibir mensagem para preencher todos os campos
                MessageBox.Show("Preencha todos os campos (placa e modelo do veículo).", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Verificar se a placa já existe na lista de veículos de entrada
                bool placaExistente = veiculosEntrada.Any(v => v.PlacaVeiculo == placa);

                if (placaExistente)
                {
                    // Exibir mensagem de veículo já cadastrado
                    MessageBox.Show("O veículo já consta no estacionamento.", "Veículo Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Obtenha a data e hora atual
                    DateTime dataEntrada = DateTime.Now.Date;
                    TimeSpan horaEntrada = DateTime.Now.TimeOfDay;

                    // Crie um objeto Veiculo com os dados de entrada
                    Veiculo veiculo = new Veiculo(placa, modeloVeiculo, dataEntrada, horaEntrada);
                    veiculosEntrada.Add(veiculo);

                    // Gravar a lista de veículos de entrada no arquivo
                    Persistencia.GravarArquivoVeiculosEntrada(veiculosEntrada);

                    // Atualize a lista de veículos na interface gráfica
                    textBoxListaVeiculosEntrada.AppendText($"{veiculo.PlacaVeiculo} = {veiculo.ModeloVeiculo} - {veiculo.DataEntrada:d/MM/yyyy} - {veiculo.HoraEntrada:h\\:mm}" + Environment.NewLine);

                    // Exibir mensagem de veículo cadastrado com sucesso
                    MessageBox.Show("Veículo cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpe a caixa de texto da placa e modelo do veículo
                    textBoxPlaca.Clear();
                    textBoxModelo.Clear();
                }
            }
        }

        private void buttonSaida_Click(object sender, EventArgs e)
        {
            string placa = textBoxPlaca.Text.ToUpper();
            string modelo = textBoxModelo.Text.ToUpper();
            // Obtenha a data e hora atual
            DateTime dataSaida = DateTime.Now.Date;
            TimeSpan horaSaida = DateTime.Now.TimeOfDay;

            // Localize o veículo de entrada correspondente na lista
            Veiculo veiculo = veiculosEntrada.Find(v => v.PlacaVeiculo == placa);

            if (veiculo != null)
            {
                // Calcule o tempo de permanência e o valor cobrado
                TimeSpan tempoPermanencia = horaSaida - veiculo.HoraEntrada;
                int horasPermanencia = (int)Math.Ceiling(tempoPermanencia.TotalHours);
                decimal valorCobrado = horasPermanencia * 5.00m;

                // Crie um objeto Veiculo com os dados de saída
                Veiculo veiculoSaida = new Veiculo(veiculo.PlacaVeiculo, veiculo.ModeloVeiculo, veiculo.DataEntrada, veiculo.HoraEntrada);
                veiculoSaida.TempoPermanencia = (int)tempoPermanencia.TotalMinutes;
                veiculoSaida.ValorCobrado = valorCobrado;

                // Adicione o veículo à lista de veículos de saída
                veiculosSaida.Add(veiculoSaida);

                // Gravar a lista de veículos de saída no arquivo
                Persistencia.GravarArquivoVeiculosSaida(veiculosSaida);

                // Remova o veículo da lista de veículos de entrada
                veiculosEntrada.Remove(veiculo);

                // Remova o veículo do arquivo de veículos de entrada
                Persistencia.RemoverVeiculoDoArquivo(veiculo);

                // Atualize a lista de veículos de entrada na interface gráfica
                AtualizarListaVeiculosEntrada();

                // Atualize a lista de veículos de saída na interface gráfica
                textBoxListaVeiculosSaida.AppendText($"{veiculoSaida.PlacaVeiculo} - {veiculo.ModeloVeiculo} - {veiculoSaida.TempoPermanencia} minutos - {veiculoSaida.ValorCobrado:c}" + Environment.NewLine);

                // Exiba a quantidade de tempo e o valor a ser pago nas TextBox correspondentes
                textBoxTempoPermanencia.Text = $"{tempoPermanencia.Minutes} minutos";
                textBoxValorCobrado.Text = $"{valorCobrado:c}";

                // Limpe a caixa de texto da placa do veículo
                textBoxPlaca.Clear();
            }
            else
            {
                // Exibir mensagem de veículo não encontrado
                MessageBox.Show("O veículo não foi encontrado no estacionamento.", "Veículo não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void AtualizarListaVeiculosEntrada()
        {
            textBoxListaVeiculosEntrada.Clear();

            foreach (Veiculo veiculo in veiculosEntrada)
            {
                string linha = $"Placa: {veiculo.PlacaVeiculo} || Modelo: {veiculo.ModeloVeiculo} || Entrada: {veiculo.DataEntrada:d/MM/yyyy} - {veiculo.HoraEntrada:h\\:mm}";
                textBoxListaVeiculosEntrada.AppendText(linha + Environment.NewLine);
            }
        }


        private decimal CalcularValorCobrado(int tempoPermanencia)
        {
            const int minutosPorHora = 60;
            const decimal valorHora = 5.00m;

            int horas = tempoPermanencia / minutosPorHora;
            int minutosRestantes = tempoPermanencia % minutosPorHora;

            if (minutosRestantes > 0)
                horas++;

            decimal valorCobrado = horas * valorHora;
            return valorCobrado;
        }
        private void TimerTick(object sender, EventArgs e)
        {
            // Atualizar a label de data e hora
            labelDataHora.Text = DateTime.Now.ToString();
        }
    }
}