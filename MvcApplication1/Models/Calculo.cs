using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Calculo
    {
        private static string NomeClasse = "VelocidadeMedia";
        private static string NomeArquivo = "velocidade_media";

        private static dynamic Objeto
        {
            get
            {
                return Execucao.ObterObjeto(NomeArquivo, NomeClasse);
            }
        }

        public static double Velocidade(double distanciaPercorrida, double tempoDoPercurso)
        {
            return Objeto.Velocidade(distanciaPercorrida,tempoDoPercurso);
        }
    }
}