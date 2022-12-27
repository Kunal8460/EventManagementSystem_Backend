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
        string mail;
        int user_otp;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }
        [HttpPost("Send")]
        public async Task<IActionResult> Send(MailRequest request)
        {
            try
            {
                user_otp = await mailService.SendEmailAsync(request);
                if (!_user.ContainsKey(request.ToEmail))
                {
                    this.mail = request.ToEmail;
                    _user.Add(request.ToEmail, user_otp);
                }
                else
                {
                    _user.Clear();
                    _user.Add(request.ToEmail, user_otp);
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

        [HttpPost("GetPass")]
        public async Task GetPass(MailRequest request)
        {
            try
            {
                await mailService.SendPass(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
