using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TechnicalEmploymentTest.DB;
using TechnicalEmploymentTest.Models;

namespace TechnicalEmploymentTest.Areas.Img.Controllers
{
    public class ImgController : Controller
    {
        private testEntities db = new testEntities();

        string Baseurl = "https://jsonplaceholder.typicode.com/";

        //Hacemos referencia a la lista que consumimos y una tabla donde guardamos los favoritos, la tabla se encuentra en el proyecto se llama test
        public async Task<ActionResult> Index()
        {

            List<ModelImage> imgList = new List<ModelImage>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("photos");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    imgList = JsonConvert.DeserializeObject<List<ModelImage>>(EmpResponse);
                }

                var imgListFavorite = db.ImgFavorite.ToList();
                List<ModelImageFavorite> ImgFavoritelist = new List<ModelImageFavorite>();

                foreach (var element in imgList)
                {
                    var index = imgListFavorite.Find(item => item.IdImg == element.id);
                    if (index != null)
                    {

                        ImgFavoritelist.Add(new ModelImageFavorite() { id = element.id, title = element.title, thumbnailUrl = element.thumbnailUrl, url = element.url, chekedFavorite = index.value });

                    }
                    else                        
                    {

                        ImgFavoritelist.Add(new ModelImageFavorite() { id = element.id, title = element.title, thumbnailUrl = element.thumbnailUrl, url = element.url, chekedFavorite = false});

                    }


                }



                return View(ImgFavoritelist);

            }

        }

        [HttpPost]
        public ActionResult Edit(int? id, bool checkedval)

            //Agregamos o modigicamos en la tabla de favoritos
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgFavorite img_ = db.ImgFavorite.Find(id);
            if (img_ == null)
            {
                if (ModelState.IsValid)
                {
                    ImgFavorite if_ = new ImgFavorite()
                    {
                        IdImg = id,
                        value = checkedval
                    };


                    db.ImgFavorite.Add(if_);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {

                ImgFavorite if_ = new ImgFavorite()
                {
                    IdImg = id,
                    value = checkedval
                };

                using (var context = new testEntities())
                {
                    context.Entry(if_).State = EntityState.Modified;
                    context.SaveChanges();
                }

                //db.Entry(if_).State = EntityState.Modified;
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}