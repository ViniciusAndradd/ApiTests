using ApiTest.Entities;
using ApiTest.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(string name, decimal salary)
        {
            var client = new Client
            {
                Name = name,
                Salary = salary
            };
            try
            {
                await _clientRepository.AddClient(client);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MENSAGEM DE ERRO: {ex}");
                return BadRequest("Ocorreu um erro ao cadastrar o usuário. Tente novamente mais tarde!");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
        {
            try
            {
                var clients = await _clientRepository.GetAllClients();
                if(clients is null)
                {
                    return NotFound("Nenhum usuário encontrado!");
                }
                else
                {
                    return Ok(clients);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MENSAGEM DE ERRO: {ex}");
                return BadRequest("Ocorreu um erro ao buscar os usuários. Tente novamente mais tarde!");
            }
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            try
            {
                var client = await _clientRepository.GetClient(id);
                if (client is null)
                {
                    return NotFound("Usuário não encontrado");
                }
                else
                {
                    return Ok(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MENSAGEM DE ERRO: {ex}");
                return BadRequest("Ocorreu um erro ao buscar o usuário. Tente novamente mais tarde!");
            }
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientByName(string name)
        {
            try
            {
                var clients = await _clientRepository.GetClientByName(name);
                if(clients is null)
                {
                    return NotFound("Nenhum usuário encontrado");
                }
                else
                {
                    return Ok(clients);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MENSAGEM DE ERRO: {ex}");
                return BadRequest("Ocorreu um erro ao buscar o usuário. Tente novamente mais tarde!");
            }
            
        }

    }
}
