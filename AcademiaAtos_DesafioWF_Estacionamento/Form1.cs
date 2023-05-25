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

            // Leia os dados dos arquivos e atribua �s listas
            veiculosEntrada = Persistencia.LerArquivoVeiculosEntrada();
            veiculosSaida = Persistencia.LerArquivoVeiculosSaida();

            // Atualize as listas de ve�culos na interface gr�fica
            AtualizarListasVeiculos();
        }

        private void AtualizarListasVeiculos()
        {
            // Limpe as caixas de texto das listas de ve�culos
            textBoxListaVeiculosEntrada.Clear();
            textBoxListaVeiculosSaida.Clear();

            // Preencha as caixas de texto com os ve�culos de entrada e sa�da
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

            // Verificar se os campos est�o preenchidos
            if (string.IsNullOrWhiteSpace(placa) || string.IsNullOrWhiteSpace(modeloVeiculo))
            {
                // Exibir mensagem para preencher todos os campos
                MessageBox.Show("Preencha todos os campos (placa e modelo do ve�culo).", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Verificar se a placa j� existe na lista de ve�culos de entrada
                bool placaExistente = veiculosEntrada.Any(v => v.PlacaVeiculo == placa);

                if (placaExistente)
                {
                    // Exibir mensagem de ve�culo j� cadastrado
                    MessageBox.Show("O ve�culo j� consta no estacionamento.", "Ve�culo Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Obtenha a data e hora atual
                    DateTime dataEntrada = DateTime.Now.Date;
                    TimeSpan horaEntrada = DateTime.Now.TimeOfDay;

                    // Crie um objeto Veiculo com os dados de entrada
                    Veiculo veiculo = new Veiculo(placa, modeloVeiculo, dataEntrada, horaEntrada);
                    veiculosEntrada.Add(veiculo);

                    // Gravar a lista de ve�culos de entrada no arquivo
                    Persistencia.GravarArquivoVeiculosEntrada(veiculosEntrada);

                    // Atualize a lista de ve�culos na interface gr�fica
                    textBoxListaVeiculosEntrada.AppendText($"{veiculo.PlacaVeiculo} = {veiculo.ModeloVeiculo} - {veiculo.DataEntrada:d/MM/yyyy} - {veiculo.HoraEntrada:h\\:mm}" + Environment.NewLine);

                    // Exibir mensagem de ve�culo cadastrado com sucesso
                    MessageBox.Show("Ve�culo cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpe a caixa de texto da placa e modelo do ve�culo
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

            // Localize o ve�culo de entrada correspondente na lista
            Veiculo veiculo = veiculosEntrada.Find(v => v.PlacaVeiculo == placa);

            if (veiculo != null)
            {
                // Calcule o tempo de perman�ncia e o valor cobrado
                TimeSpan tempoPermanencia = horaSaida - veiculo.HoraEntrada;
                int horasPermanencia = (int)Math.Ceiling(tempoPermanencia.TotalHours);
                decimal valorCobrado = horasPermanencia * 5.00m;

                // Crie um objeto Veiculo com os dados de sa�da
                Veiculo veiculoSaida = new Veiculo(veiculo.PlacaVeiculo, veiculo.ModeloVeiculo, veiculo.DataEntrada, veiculo.HoraEntrada);
                veiculoSaida.TempoPermanencia = (int)tempoPermanencia.TotalMinutes;
                veiculoSaida.ValorCobrado = valorCobrado;

                // Adicione o ve�culo � lista de ve�culos de sa�da
                veiculosSaida.Add(veiculoSaida);

                // Gravar a lista de ve�culos de sa�da no arquivo
                Persistencia.GravarArquivoVeiculosSaida(veiculosSaida);

                // Remova o ve�culo da lista de ve�culos de entrada
                veiculosEntrada.Remove(veiculo);

                // Remova o ve�culo do arquivo de ve�culos de entrada
                Persistencia.RemoverVeiculoDoArquivo(veiculo);

                // Atualize a lista de ve�culos de entrada na interface gr�fica
                AtualizarListaVeiculosEntrada();

                // Atualize a lista de ve�culos de sa�da na interface gr�fica
                textBoxListaVeiculosSaida.AppendText($"{veiculoSaida.PlacaVeiculo} - {veiculo.ModeloVeiculo} - {veiculoSaida.TempoPermanencia} minutos - {veiculoSaida.ValorCobrado:c}" + Environment.NewLine);

                // Exiba a quantidade de tempo e o valor a ser pago nas TextBox correspondentes
                textBoxTempoPermanencia.Text = $"{tempoPermanencia.Minutes} minutos";
                textBoxValorCobrado.Text = $"{valorCobrado:c}";

                // Limpe a caixa de texto da placa do ve�culo
                textBoxPlaca.Clear();
            }
            else
            {
                // Exibir mensagem de ve�culo n�o encontrado
                MessageBox.Show("O ve�culo n�o foi encontrado no estacionamento.", "Ve�culo n�o Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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