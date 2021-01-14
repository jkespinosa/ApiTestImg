using System.Web.Mvc;

namespace TechnicalEmploymentTest.Areas.Img
{
    public class ImgAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Img";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Img_default",
                "Img/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}