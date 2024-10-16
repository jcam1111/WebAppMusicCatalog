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

namespace WebAppMusicCatalog.Controllers
{
    [Autorizacion]
    public class CancionesController : Controller
    {
        private MusicCatalogEntities db = new MusicCatalogEntities();

        // GET: Canciones
        public async Task<ActionResult> Index(int artistaId=0)
        {
            var canciones = db.Canciones.Include(c => c.Artistas).Include(c => c.Generos);

            if (artistaId >0)
            {
                //canciones = canciones.Where(s => s.artista_id.Equals(artistaId));
                canciones = canciones.Where(s => s.artista_id==artistaId);
            }
            return View(await canciones.ToListAsync());
        }

        // GET: Canciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canciones canciones = await db.Canciones.FindAsync(id);
            if (canciones == null)
            {
                return HttpNotFound();
            }
            return View(canciones);
        }

        // GET: Canciones/Create
        public ActionResult Create()
        {
            ViewBag.artista_id = new SelectList(db.Artistas, "artista_id", "nombre");
            ViewBag.genero_id = new SelectList(db.Generos, "genero_id", "nombre");
            return View();
        }

        // POST: Canciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cancion_id,titulo,duracion,artista_id,genero_id,album,anio_lanzamiento,letra,calificacion,ruta_archivo,subtitulo,numero_pista,fecha_creacion,fecha_modificacion")] Canciones canciones)
        {
            if (ModelState.IsValid)
            {
                canciones.fecha_creacion = DateTime.Now;
                canciones.fecha_modificacion = DateTime.Now;
                db.Canciones.Add(canciones);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.artista_id = new SelectList(db.Artistas, "artista_id", "nombre", canciones.artista_id);
            ViewBag.genero_id = new SelectList(db.Generos, "genero_id", "nombre", canciones.genero_id);
            return View(canciones);
        }

        // GET: Canciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canciones canciones = await db.Canciones.FindAsync(id);
            if (canciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.artista_id = new SelectList(db.Artistas, "artista_id", "nombre", canciones.artista_id);
            ViewBag.genero_id = new SelectList(db.Generos, "genero_id", "nombre", canciones.genero_id);
            return View(canciones);
        }

        // POST: Canciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cancion_id,titulo,duracion,artista_id,genero_id,album,anio_lanzamiento,letra,calificacion,ruta_archivo,subtitulo,numero_pista,fecha_creacion,fecha_modificacion")] Canciones canciones)
        {
            if (ModelState.IsValid)
            {
                canciones.fecha_modificacion = DateTime.Now;
                db.Entry(canciones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.artista_id = new SelectList(db.Artistas, "artista_id", "nombre", canciones.artista_id);
            ViewBag.genero_id = new SelectList(db.Generos, "genero_id", "nombre", canciones.genero_id);
            return View(canciones);
        }

        // GET: Canciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canciones canciones = await db.Canciones.FindAsync(id);
            if (canciones == null)
            {
                return HttpNotFound();
            }
            return View(canciones);
        }

        // POST: Canciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Canciones canciones = await db.Canciones.FindAsync(id);
            db.Canciones.Remove(canciones);
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
