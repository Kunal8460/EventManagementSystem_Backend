using ems.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using System.Linq;

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        private static Dictionary<string, int> _user = new Dictionary<string, int>();
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequest request)
        {
            try
            {
                int otp = await mailService.SendEmailAsync(request);
                if (!_user.ContainsKey(request.ToEmail))
                {
                    _user.Add(request.ToEmail, otp);
                }
                else
                {
                    _user.Remove(request.ToEmail);
                }
                //HttpContext.Session.SetString("user", request.ToEmail);
                //HttpContext.Session.SetString("otp", otp.ToString());
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpPost("GetData")]
        public bool GetUserData(Otp otp)
        {
            try
            {
                if (_user.ContainsValue(otp.otp))
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
