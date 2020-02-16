using PasswordChecker.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PasswordChecker.Controllers
{
    [EnableCors(origins: "http://localhost:59915", headers: "*", methods: "*")]
    public class PasswordController : ApiController
    {

        // GET api/values/5
        public IHttpActionResult GetPassword(string password)
        {
            PasswordScore passwordStrengthScore = PasswordChecker.Application.PasswordChecker.CheckStrength(password);
            return Ok(passwordStrengthScore);
        }
    }
}
