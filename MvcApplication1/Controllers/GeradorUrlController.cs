using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using System.Text;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class GeradorUrlController : Controller
    {
        //
        // GET: /GeradorUrl/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Url(string button, Conexao conexao)
        {

            if (button == "Gerar_Url_Twitter")
                System.Diagnostics.Process.Start(
                    ObterUrlTwitter(
                        conexao.Url,
                        "Teste Twitter",
                        "Sergiohff"));

            else if (button == "Gerar_Url_Facebook")
                System.Diagnostics.Process.Start(
                     ObterUrlFacebook(
                        conexao.Url,
                        "Teste Facebook"));

            return View();
        }


        /// <summary>
        /// Devolve a url resumida
        /// </summary>
        /// <param name="url">url completa</param>
        /// <returns>url resumida</returns>
        protected string ObterUrlCurta(string url)
        {
            try
            {
                if (!url.ToLower().StartsWith("http") && !url.StartsWith("ftp"))
                {
                    url = "http://" + url;
                }

                WebRequest request = WebRequest.Create("http://tinyurl.com/api-create.php?url=" + url);

                WebResponse response = request.GetResponse();

                string urlCurta = string.Empty;

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    urlCurta = reader.ReadToEnd();
                }

                return urlCurta;
            }
            catch (Exception)
            {
                return url;
            }
        }


        /// </summary>
        /// <param name="urlParaCompartilhar">url que será compartilhada</param>
        /// <param name="tituloPagina">título da página</param>
        /// <returns>url resumida do facebook</returns>
        public string ObterUrlFacebook(string urlParaCompartilhar, string tituloPagina)
        {

            StringBuilder url = new StringBuilder(string.Format("http://www.facebook.com/sharer.php?u={0}&t={1}",

            urlParaCompartilhar, tituloPagina));

            return url.ToString();

        }

        /// <summary>
        /// Devolve a url resumida do Twitter
        /// </summary>
        /// <param name="urlParaCompartilhar">url que será compartilhada</param>
        /// <param name="tweet">mensagem/tweet</param>
        /// <param name="usuarioTwitter">por quem ou qual canal</param>
        /// <returns>url resumida do twitter</returns>
        public string ObterUrlTwitter(string urlParaCompartilhar, string tweet, string usuarioTwitter)
        {

            StringBuilder url = new StringBuilder(string.Format("http://twitter.com/home?status={0} {1}",

                ObterUrlCurta(urlParaCompartilhar), tweet));

            if (usuarioTwitter != string.Empty)
                url.Append(string.Format(" - por (@{0})", usuarioTwitter));

            return url.ToString();

        }

    }
}
