using System.Web.Mvc;

namespace ArWeb3.Areas.TestTools
{
    public class TestToolsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestTools";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TestTools_default",
                "TestTools/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}