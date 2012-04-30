using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetSharp.Model;
using TweetSharp;
using System.Text;
using MvcApplication1.Models;
using System.Diagnostics;

namespace MvcApplication1.Controllers
{
    public class PostagemTwitterController : Controller
    {
        //
        // GET: /Postagem/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Postagem()
        {
            Integracao integracao = new Integracao();

            //TwitterService service = new TwitterService("Sergiohff", "xsxkm7xs");
            //IEnumerable<TwitterStatus> tweets = service.ListTweetsOnPublicTimeline();

            //OAuthRequestToken requestToken = service.GetRequestToken();

            //Uri uri = service.GetAuthorizationUri(requestToken);
            //Process.Start(uri.ToString());

            //string verifier = "123456";
            //OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);

            //service.AuthenticateWith(access.Token, access.TokenSecret);
            //IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe();

            //StringBuilder postagens = new StringBuilder();
            //foreach (var tweet in tweets)
            //{
            //    postagens.AppendLine(tweet.User.ScreenName + " says " + tweet.Text);
            //    tweet.User.ProfileImageUrl = "";
            //}

            return View();
        }

    }
}
