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
    [RoutePrefix("adfs/oauth2/authorize")]
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        [Route]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Route]
        public async Task<ActionResult> LogIn(UsersLogInModel model)
        {
            var client = new OAuth2Client(new Uri("http://localhost:40687/token"));

            var response =
                await
                    client.RequestResourceOwnerPasswordAsync(model.Username, model.Password);

            if (!response.IsError)
            {
                var token = response.AccessToken;


                //var identity = new ClaimsIdentity("AppCookies");
                //identity.AddClaim(new Claim("access_token", token));
                //Request.GetOwinContext().Authentication.SignIn(identity);
                //return Json(new {token});JsonResult
                //return new JSONNetResult(response.Json);// use action result in this case
                //Response.AddHeader("WWW-Authenticate", "Bearer " + token);
                
                return Content(token);
            }
            throw new Exception();
        }
    }
}