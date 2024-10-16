using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMusicCatalog.Models;
using System.IO;
using System.Web.Helpers;
using System.Data.Entity.Validation;

namespace WebAppMusicCatalog.Controllers
{
    [Autorizacion]
    public class ArtistasController : Controller
    {
        private MusicCatalogEntities db = new MusicCatalogEntities();

        // GET: Artistas
        //[Authorize]
        public async Task<ActionResult> Index(string searchString)
        {
            var artistas = db.Artistas.Include(a => a.Paises);

            if (!String.IsNullOrEmpty(searchString))
            {
                artistas = artistas.Where(s => s.nombre.ToUpper().Contains(searchString.ToUpper()));
            }
            return View(await artistas.ToListAsync());
        }       

        // GET: Artistas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = await db.Artistas.FindAsync(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        // GET: Artistas/Create
        public ActionResult Create()
        {
            ViewBag.nacionalidad_pais_id = new SelectList(db.Paises, "pais_id", "nombre");
            return View();
        }

        // POST: Artistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //public async Task<ActionResult> Create([Bind(Include = "artista_id,nombre,nacionalidad_pais_id,fecha_nacimiento,genero_musical,biografia,imagen,ruta_archivo_imagen,url_sitio_web,fecha_creacion,fecha_modificacion")] Artistas artistas)
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "nombre,nacionalidad_pais_id,fecha_nacimiento,genero_musical,biografia,imagen,ruta_archivo_imagen,url_sitio_web")] Artistas artistas, HttpPostedFileBase ruta_archivo_imagen)
        {
            if (ModelState.IsValid)
            {
                artistas.fecha_creacion = DateTime.Now;
                artistas.fecha_modificacion= DateTime.Now;
                if (ruta_archivo_imagen != null)
                {
                    WebImage img = new WebImage(ruta_archivo_imagen.InputStream);
                    FileInfo imginfo = new FileInfo(ruta_archivo_imagen.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(50, 50);
                    img.Save("~/Uploads/Artistas/" + logoname);

                    artistas.ruta_archivo_imagen = "/Uploads/Artistas/" + logoname;
                }
                db.Artistas.Add(artistas);
                
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges
                    await db.SaveChangesAsync();
                    //context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return RedirectToAction("Index");
            }

            ViewBag.nacionalidad_pais_id = new SelectList(db.Paises, "pais_id", "nombre", artistas.nacionalidad_pais_id);
            return View(artistas);
        }
       
        // GET: Artistas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = await db.Artistas.FindAsync(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            ViewBag.nacionalidad_pais_id = new SelectList(db.Paises, "pais_id", "nombre", artistas.nacionalidad_pais_id);
            return View(artistas);
        }
        
        // POST: Artistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "artista_id,nombre,nacionalidad_pais_id,fecha_nacimiento,genero_musical,biografia,imagen,ruta_archivo_imagen,url_sitio_web,fecha_creacion,fecha_modificacion")] Artistas artistas, HttpPostedFileBase ruta_archivo_imagen)
        {
            if (ModelState.IsValid)
            {                
                artistas.fecha_modificacion = DateTime.Now;
                db.Entry(artistas).State = EntityState.Modified;

                if (ruta_archivo_imagen == null)
                {
                    Artistas artistas2 = await db.Artistas.FindAsync(artistas.artista_id);
                    artistas.ruta_archivo_imagen = artistas2.ruta_archivo_imagen;
                }
                
                if (ruta_archivo_imagen != null)
                {                    
                    WebImage img = new WebImage(ruta_archivo_imagen.InputStream);
                    FileInfo imginfo = new FileInfo(ruta_archivo_imagen.FileName);

                    //string logoname = ruta_archivo_imagen.FileName + imginfo.Extension;
                    string logoname = ruta_archivo_imagen.FileName;
                    img.Resize(300, 200);

                    if (System.IO.File.Exists(Server.MapPath("~/Uploads/Artistas/" + logoname)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Uploads/Artistas/" + logoname));
                    }

                    img.Save("~/Uploads/Artistas/" + logoname);

                    artistas.ruta_archivo_imagen = "/Uploads/Artistas/" + logoname;
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.nacionalidad_pais_id = new SelectList(db.Paises, "pais_id", "nombre", artistas.nacionalidad_pais_id);
            return View(artistas);
        }

        // GET: Artistas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artistas artistas = await db.Artistas.FindAsync(id);
            if (artistas == null)
            {
                return HttpNotFound();
            }
            return View(artistas);
        }

        // POST: Artistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Artistas artistas = await db.Artistas.FindAsync(id);
            db.Artistas.Remove(artistas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
