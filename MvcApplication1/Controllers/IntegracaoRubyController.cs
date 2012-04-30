using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using Microsoft.Web.Optimization;
using System.IO;

namespace MvcApplication1.Controllers
{
    public class IntegracaoRubyController : Controller
    {
        //
        // GET: /Postagem/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ruby(string button, Integracao integracao)
        {
            double resultado = 0;

            if (button == "Calcular")
            {
                resultado = Calculo.Velocidade(double.Parse(integracao.Distancia), double.Parse(integracao.Tempo));
                ViewBag.retorno = resultado.ToString() + "M/s";
            }

            return View();
        }

        public ActionResult EditorRuby(string button, Editor editor)
        {
            if (button == "Alterar")
                SalvarArquivo(editor);
            else
                LerArquivo(editor);

            return View(editor);
        }

        private string ObterArquivo()
        {
            var diretorioDaAplicacao = (string)AppDomain.CurrentDomain.GetData("DataDirectory") ?? AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            return System.IO.Path.Combine(diretorioDaAplicacao, String.Format("Ruby\\{0}.rb", "velocidade_media"));
        }

        private void LerArquivo(Editor editor)
        {
            using (var textReader = new StreamReader(ObterArquivo()))
            {
                editor.CodigoEmRuby = textReader.ReadToEnd();
                textReader.Close();
            }
        }

        private void SalvarArquivo(Editor editor)
        {
            using (var textWriter = new StreamWriter(ObterArquivo()))
            {
                textWriter.Write(editor.CodigoEmRuby);
                textWriter.Close();
            }
        }
    }
}
