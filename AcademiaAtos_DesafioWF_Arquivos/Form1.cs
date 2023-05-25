using AcademiaAtos_DesafioWF_Arquivos.Classes;

namespace AcademiaAtos_DesafioWF_Arquivos
{
    public partial class Form1 : Form
    {
        private List<Pessoa> pessoas = new List<Pessoa>();
        private int totalAlunos;
        private int totalPessoas;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCarregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos de Texto|*.txt";
            openFileDialog.Title = "Selecione o arquivo de texto";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = openFileDialog.FileName;
                pessoas = LerArquivo(nomeArquivo);
                textBoxArquivo.Text = File.ReadAllText(nomeArquivo);
            }
        }

        private void buttonOrganizar_Click(object sender, EventArgs e)
        {
            ExibirResultados();
        }

        private List<Pessoa> LerArquivo(string nomeArquivo)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            try
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);

                for (int i = 0; i < linhas.Length; i++)
                {
                    string linha = linhas[i];

                    if (linha.StartsWith("Z"))
                    {
                        string[] dadosPessoa = linha.Split('-');
                        string nome = dadosPessoa[1];
                        string telefone = dadosPessoa[2];
                        string cidade = dadosPessoa[3];
                        string rg = dadosPessoa[4];
                        string cpf = dadosPessoa[5];

                        Pessoa pessoa = new Pessoa(nome, telefone, cidade, rg, cpf);
                        pessoas.Add(pessoa);

                        if (i + 1 < linhas.Length && linhas[i + 1].StartsWith("Y"))
                        {
                            string linhaCurso = linhas[i + 1];
                            string[] dadosCurso = linhaCurso.Split('-');
                            string matricula = dadosCurso[1];
                            string codigoCurso = dadosCurso[2];
                            string nomeCurso = dadosCurso[3];

                            Aluno aluno = new Aluno(nome, telefone, cidade, rg, cpf, matricula, codigoCurso, nomeCurso);
                            pessoas.Add(aluno);

                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return pessoas;
        }

        private void ExibirResultados()
        {
            totalAlunos = 0;
            totalPessoas = 0;
            textBoxOrganizado.Clear();

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa is Aluno)
                {
                    totalAlunos++;
                }
                else
                {
                    totalPessoas++;
                }
            }

            foreach (Pessoa pessoa in pessoas)
            {
                if (pessoa is Aluno aluno)
                {
                    textBoxOrganizado.AppendText($"Y - Aluno: {aluno.Nome} - Matricula: {aluno.Matricula} - Cod. do Curso: {aluno.CodigoCurso} - Curso: {aluno.NomeCurso} {Environment.NewLine}");
                }
                else
                {
                    textBoxOrganizado.AppendText($"Z- Pessoa: {pessoa.Nome} - Tel: {pessoa.Telefone} - Cidade: {pessoa.Cidade} - RG: {pessoa.RG} - CPF: {pessoa.CPF} Curso: Não realiza {Environment.NewLine}");
                }
            }

            labelTotalAlunos.Text = "Total de Alunos Criados: " + totalAlunos;
            labelTotalPessoas.Text = "Total de Pessoas Criadas: " + totalPessoas;
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivos de Texto|*.txt";
            saveFileDialog.Title = "Salvar Arquivo";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nomeArquivo = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(nomeArquivo))
                    {
                        writer.Write(textBoxOrganizado.Text);
                    }

                    MessageBox.Show("Arquivo gravado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao gravar o arquivo: " + ex.Message);
                }
            }
        }
    }
}





