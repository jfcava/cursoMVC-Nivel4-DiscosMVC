using disco_app_MVC.Models.Dominio;
using disco_app_MVC.Models.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace disco_app_MVC.Controllers
{
    public class DiscoController : Controller
    {
        // GET: DiscoController
        public ActionResult Index(string filtro)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            var discos = negocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                discos = discos.FindAll(d => d.Titulo.ToUpper().Contains(filtro.ToUpper()));
            }

            ViewBag.Filtro = filtro;

            return View(discos);
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            var disco = discoNegocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");

            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    EstiloNegocio estiloNegocio = new EstiloNegocio();
                    TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

                    ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
                    ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");

                    return View(disco);
                }

                DiscoNegocio negocio = new DiscoNegocio();
                negocio.agregar(disco);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();
            EstiloNegocio estiloNegocio = new EstiloNegocio();

            var disco = discoNegocio.listar().Find(d => d.Id == id);

            ViewBag.Estilos = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TiposEdicion = new SelectList(tipoEdicionNegocio.listar(), "Id", "Descripcion");
            return View(disco);
        }

        // POST: DiscoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                negocio.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();
            var disco = discoNegocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DiscoNegocio negocio = new DiscoNegocio();
                negocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
