using System.Web.Mvc;

namespace PetFriendly.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }

            //kullanıcı admin yazıp direkt olarak girebilmesi için, default olarak dashboard eklendi
            //Added dashboard by default so user can enter admin directly
            
            //admin alanı Controller olarak "context.MapRoute" a eklendi
            //Admin field added to "context.MapRoute" as Controller
            );
        }
    }
}