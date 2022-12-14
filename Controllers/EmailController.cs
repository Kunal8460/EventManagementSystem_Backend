using ems.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
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
                HttpContext.Session.SetString("user", request.ToEmail);
                HttpContext.Session.SetString("otp", otp.ToString());
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpGet]
        public string GetSessionData()
        {
            try
            {
                if (HttpContext.Session != null)
                {
                    return HttpContext.Session.GetString("user");
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
