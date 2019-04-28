using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reclamacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Reclamacao.Classes
{
    public class UserHelper : IDisposable
    {
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static ReclamacaoContext db = new ReclamacaoContext();

        //delatar usuarios
        public static bool deleteUser(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if(userASP == null)
            {
                return false;
            }
            var response = userManager.Delete(userASP);
            return response.Succeeded;
        }
        //funcao para atualizar usuarios
        public static bool updateUser(string currentEmail,string newEmail)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(currentEmail);
            if (userASP == null)
            {
                return false;
            }
            userASP.Email = newEmail;
            userASP.UserName = newEmail;
            var response = userManager.Update(userASP);
            return response.Succeeded;
        }
        public static void checkRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));
            //check to see if role exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email    = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassword"];
            var userAsp = userManager.FindByName(email);
            if(userAsp == null)
            {
                CreateUserAsp(email, "Admin", password);
                return;
            }
            userManager.AddToRole(userAsp.Id, "Admin");
        }
        public static void CreateUserAsp(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userAsp = new ApplicationUser
            {
                Email = email,
                UserName = email,

            };
            userManager.Create(userAsp, email);
            userManager.AddToRole(userAsp.Id, roleName);

        }
        public static void CreateUserAsp(string email, string roleName,string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userAsp = new ApplicationUser
            {
                Email = email,
                UserName = email,

            };
            userManager.Create(userAsp, password);
            userManager.AddToRole(userAsp.Id, roleName);

        }
        public static async Task PasswordRocovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userAsp = userManager.FindByEmail(email);
            if(userAsp == null)
            {
                return;
            }
            var user = db.Usuarios.Where(tp => tp.email == email).FirstOrDefault();
            if(user == null)
            {
                return;
            }
            var random = new Random();
            var newPassword = "Abc123.";
            userManager.RemovePassword(userAsp.Id);
            userManager.AddPassword(userAsp.Id, newPassword);

            var subject = "nova senha";
            var body = string.Format(@"<h2>Sua senha foi alterada! </h2><p>Nova senha: <strong>{0}<strong></p><p>Altere assim que fizer o acesso no site</p> ",newPassword);
            await MailHelper.SendMail(email, subject, body);
        }


        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }
    }
}