using ApiConsumoTaller.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace ApiConsumoTaller.Controllers
{
    public class MecanicoController : Controller
    {
        // Instancia de la clase APIGateway para interactuar con la lógica de negocios
        private readonly APIGateway apiGateway;

        // Constructor que recibe una instancia de APIGateway como dependencia
        public MecanicoController(APIGateway apiGateway)
        {
            this.apiGateway = apiGateway;
        }
        // Acción para mostrar la lista de mecánicos en la vista Index
        public IActionResult Index()
        {
            // Lista que contendrá los mecánicos recuperados a través de la APIGateway
            List<Mecanico> mecanicos;
            // Llama al método ListMecanicos de la APIGateway para obtener la lista de mecánicos
            mecanicos = apiGateway.ListMecanicos();
            // Devuelve la vista Index con la lista de mecánicos como modelo
            return View(mecanicos);
        }
        // Acción HTTP GET para mostrar el formulario de creación de un nuevo mecánico
        [HttpGet]
        public IActionResult Create()
        {
            // Crea una nueva instancia de la clase Mecanico para usar como modelo en la vista
            Mecanico mecanico = new Mecanico();
            // Devuelve la vista Create con el objeto Mecanico como modelo
            return View(mecanico);
        }

        [HttpPost]
        public IActionResult Create(Mecanico mecanico)
        {
            apiGateway.CreateMecanico(mecanico);
            //realice la acción de creación de API y envíe el control a la acción de índice
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            //obtener el cliente de la API y mostrar los detalles del cliente en la vista de detalles
            Mecanico mecanico = new Mecanico();
            mecanico = apiGateway.GetMecanico(Id);
            return View(mecanico);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Mecanico mecanico;
            // //obtener el cliente de la API y mostrar los detalles del cliente en la vista de editar
            mecanico = apiGateway.GetMecanico(Id);
            return View(mecanico);
        }

        [HttpPost]
        public IActionResult Edit(Mecanico mecanico)
        {
            //realice la acción de edición de la API y envíe el control a la acción de índice
            apiGateway.UpdateMecanico(mecanico);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //obtener el cliente de la API y mostrar los detalles del cliente en la vista Eliminar
            Mecanico mecanico = new Mecanico();
            mecanico = apiGateway.GetMecanico(Id);
            return View(mecanico);
        }

        [HttpPost]
        public IActionResult Delete(Mecanico mecanico)
        {
            //realice la acción de eliminación de API y envíe el control a la acción de índice
            apiGateway.DeleteMecanico(mecanico.idMecanico);
            return RedirectToAction("index");
        }
    }
}
