using System;
namespace Trabalho._2.Models
{
    public class Viagem
    {
        
         public int IDProduto{get; set;}
         
        public int IDusuario{get; set;}

        public string nomePacote{get; set;}

        public string origemPacote{get; set;}

        public string destinoPacote{get; set;}

        public string atrativosPacote{get; set;}

        public DateTime saidaPacote{get; set;}

        public DateTime retornoPacote{get; set;}
    }
}