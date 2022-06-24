using System.Web.Mvc;

namespace OnlineTesting.Areas.OT
{
    public class OTAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OT_default",
                "OT/{controller}/{action}/{id}",
                new { controller = "Login",action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}