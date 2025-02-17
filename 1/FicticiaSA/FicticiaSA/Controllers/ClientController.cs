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


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllClients();
            return View(clients);
        }
         

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetClientById(id);
            return View(client);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                await _clientService.AddClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if (id != client.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _clientService.UpdateClient(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientService.DeleteClient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
