using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Entities
{
    public class Desenvolvedor:Funcionario
    {
        [ForeignKey("Projeto")]
        public int IdProjeto { get; set; }

        public Projeto Projeto { get; set; }
    }
}
