using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nokta.Models;
using Facebook;

namespace Nokta.Controllers
{
    public class NoktaController : Controller
    {
        //
        // GET: /Nokta/
        public ActionResult Index()
        {
            NoktaModel NM = new NoktaModel();

            ViewBag.AllNokats = NM.SelectNokats();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection C)
        {
            string Code = "";
            if (Session["accesstoken"] == null)
            {
                Code = C["HiddenToken"].Split('#')[1].Split('=')[1].Split('&')[0];
            }
            else
            {
                 Code = Session["accesstoken"].ToString();
            }
            
            FacebookClient x = new FacebookClient(Code);
            x.AppId = "222975161160358";
            x.AppSecret = "dacfb5f232b27fdabf83d5f8e6c73d10";
           
            WebResponse response = null;


            dynamic FBUser = x.Get("me");
            UserModel U=new UserModel();
            
            string pictureUrl = string.Empty;

            WebRequest request2 = WebRequest.Create(string.Format("https://graph.facebook.com/{0}/picture", FBUser.id));
            response = request2.GetResponse();
            pictureUrl = response.ResponseUri.ToString();
            Session["accesstoken"] = Code;
            Session["UserID"] = FBUser.id;

            if (U.SelectUser(int.Parse(FBUser.id)) == null)
            {
                U.AddUser(int.Parse(FBUser.id), FBUser.name, pictureUrl, FBUser.link);
            }
            NoktaModel NM=new NoktaModel();
            
            ViewBag.AllNokats = NM.SelectNokats();
            return View();
            
        }

        public ActionResult AddNokta()
        {
                return View();


        }

        [HttpPost]
        public ActionResult AddNokta(FormCollection collection)
        {
            if (collection["NoktaText"] == "")

                return View();

            else
            {
                NoktaModel nm=new NoktaModel();
                nm.AddNokta(collection["NoktaText"], int.Parse(Session["UserID"].ToString()));
                return RedirectToAction("Index");
            }


        }

        public ActionResult OneNokta(int NoktaID)
        {
            NoktaModel N=new NoktaModel();
            CommentsModel CM=new CommentsModel();
            ViewBag.ANokta = N.SelectNokta(NoktaID);
            ViewBag.Comments = CM.SelectCommnet(NoktaID);
            return View();
        }

        [HttpPost]
        public ActionResult OneNokta(FormCollection aCollection)
        {
            CommentsModel CM = new CommentsModel();
            CM.AddCommnet(aCollection["Text_Comments"], int.Parse(Session["UserID"].ToString()), int.Parse(aCollection["NoktaID_Hidden"].ToString()));
            return RedirectToAction("OneNokta", new { @NoktaID = aCollection["NoktaID_Hidden"] });
        }

        public ActionResult GetUser(FormCollection aCollection)
        {
             FacebookClient x = new FacebookClient(aCollection["HiddenToken"]);
            dynamic FBUser = x.Get("me");
            UserModel UM = new UserModel();
            NoktaModel NM = new NoktaModel();
            ViewBag.User = UM.SelectUser(FBUser.ID);
            ViewBag.UsersNokats = NM.SelectUserNokats(FBUser.ID);
            
            return View();

        }

        
    }
}
