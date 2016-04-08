using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ApiDogFood.WebClient.ViewModels;
using ODataPOC.Results;
using Thinktecture.IdentityModel.Client;

namespace ODataPOC.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(UsersLogInModel model)
        {
            //var client = new OAuth2Client(new Uri("http://localhost:40687/token"));

            //var response =
            //    await
            //        client.RequestResourceOwnerPasswordAsync(model.Username, model.Password);

            //if (!response.IsError)
            //{
                //var token = response.AccessToken;

            if (model.Password == model.Username)
            {
                var identity = new ClaimsIdentity("AppCookies");
                //identity.AddClaim(new Claim("access_token", token));
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(identity);
                
            }

                //return Redirect("~/Home?token="+token);
           // }
            //throw new Exception();
        }
    }
}