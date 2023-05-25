using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAtos_DesafioWF_Arquivos.Classes
{
    public static class Persistencia
    {
        public static List<Pessoa> LerArquivo(string nomeArquivo)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            string[] linhas = File.ReadAllLines(nomeArquivo);

            for (int i = 0; i < linhas.Length; i++)
            {
                string linha = linhas[i];

                if (linha.StartsWith("Z"))
                {
                    // Dados do aluno
                    string[] dadosAluno = linha.Split('-');
                    Aluno aluno = new Aluno(
                        dadosAluno[1], dadosAluno[2], dadosAluno[3], dadosAluno[4], dadosAluno[5],
                        "", "", ""); // Valores iniciais para os atributos do curso

                    // Verificar se há dados de curso
                    if (i + 1 < linhas.Length && linhas[i + 1].StartsWith("Y"))
                    {
                        // Dados do curso
                        string[] dadosCurso = linhas[i + 1].Split('-');
                        aluno.Matricula = dadosCurso[1];
                        aluno.CodigoCurso = dadosCurso[2];
                        aluno.NomeCurso = dadosCurso[3];
                        i++; // Avançar para a próxima linha (curso)
                    }

                    pessoas.Add(aluno);
                }
                else if (linha.StartsWith("Z"))
                {
                    // Dados da pessoa (não aluno)
                    string[] dadosPessoa = linha.Split('-');
                    Pessoa pessoa = new Pessoa(
                        dadosPessoa[1], dadosPessoa[2], dadosPessoa[3], dadosPessoa[4], dadosPessoa[5]);

                    pessoas.Add(pessoa);
                }
            }

            return pessoas;
        }
    }
}
