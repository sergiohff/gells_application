using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Scripting.Hosting;
using IronRuby;
using System.IO;

namespace MvcApplication1.Models
{
    public static class Execucao
    {
        private static ScriptEngine rubyEngine;

        private static ScriptEngine CriarEngine()
        {
            if (rubyEngine == null)
                rubyEngine = Ruby.CreateEngine();

            return rubyEngine;
        }

        public static dynamic ObterObjeto(string nomeArquivo, string nomeClasse)
        {
            var diretorio = (string)AppDomain.CurrentDomain.GetData("DataDirectory") ?? AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var arquivo = Path.Combine(diretorio, String.Format("Ruby\\{0}.rb", nomeArquivo));

            CriarEngine().ExecuteFile(arquivo);
            dynamic objeto = CriarEngine().Runtime.Globals.GetVariable(nomeClasse);
            return CriarEngine().Operations.CreateInstance(objeto);
        }
    }
}