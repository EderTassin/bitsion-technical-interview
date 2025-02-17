using Microsoft.AspNetCore.Mvc;
using FicticiaSA.API.Services;
using FicticiaSA.API.Models;

namespace FicticiaSA.API.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            var clients = _clientService.GetAllClients();
            return View(clients);
        }

        public IActionResult Details(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();
                
            return View(client);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _clientService.AddClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public IActionResult Edit(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();
                
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Client client)
        {
            if (id != client.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _clientService.UpdateClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        public IActionResult Delete(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clientService.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
