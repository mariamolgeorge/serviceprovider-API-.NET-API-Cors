using InIT.API.GMMEP.Class;
using InIT.API.GMMEP.Models;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InIT.API.GMMEP.Controllers
{
    public class UserRegisterController : ApiController
    {
        GmmepEntities GE = new GmmepEntities();
        [HttpGet]
        public spUserLoginWithEmailOrMobile_Result UserLoginWithEmailOrMobile(string email, string mobile)
        {
            string password = Utils.CreateOTP(6);
            spUserLoginWithEmailOrMobile_Result cp = GE.spUserLoginWithEmailOrMobile(mobile != null ? mobile : "", email != null ? email : "", password).SingleOrDefault();
            if (cp.Id > 0 && cp.Error == 0)
            {

                if (mobile != null && mobile.Trim().Length > 9)
                {
                   
                }

                if (email != null && email.Trim().Length > 1)
                {
                    string subj = "Welcome to BlueSky Mobile App. Your password " + password + " is OTP/Password to verify BlueSky App account.";
                   // Utils.SendMailotp(email, password);
                }


            }
            return cp;

        }

        [HttpGet]
        public IEnumerable<spLoginCheckWithOTP_Result> LoginCheckWithOTP(int Id, string password)
        {
            return GE.spLoginCheckWithOTP(Id, password);
        }

        [HttpPost]
        public IEnumerable<spUpdateUsers_Result> UpdateUsers(Users uu)
        {
            return GE.spUpdateUsers(uu.Id, uu.Name, uu.Mobile, uu.Email, uu.Address, uu.Pincode, uu.Latitude, uu.Longitude).AsEnumerable();
        }


        [HttpGet]
        public spResendVerificationOtp_Result ResendVerificationOtp(int OtpId)

        {
            try
            {
                spResendVerificationOtp_Result rp = GE.spResendVerificationOtp(OtpId).SingleOrDefault();
                if (rp.Id > 0)
                {
                    string subj = "Welcome to BlueSky Mobile App. Your password " + rp.Password + " is OTP/Password to verify BlueSky App account.";
                    //Utils.SendSmsPassword(rp.Mobile, subj);
                    //Utils.SendMailotp(rp.Email, rp.Password);
                }
                return rp;
            }
            catch (Exception e)
            {
                string err = e.Message;
                return null;
            }
        }

       

    }
}
