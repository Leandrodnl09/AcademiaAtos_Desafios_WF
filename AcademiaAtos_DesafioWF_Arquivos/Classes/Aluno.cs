using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademiaAtos_DesafioWF_Arquivos.Classes
{
    public class Aluno : Pessoa
    {
        public string Matricula { get; set; }
        public string CodigoCurso { get; set; }
        public string NomeCurso { get; set; }

        public Aluno(string nome, string telefone, string cidade, string rg, string cpf, string matricula, string codigoCurso, string nomeCurso)
            : base(nome, telefone, cidade, rg, cpf)
        {
            Matricula = matricula;
            CodigoCurso = codigoCurso;
            NomeCurso = nomeCurso;
        }
    }
}
