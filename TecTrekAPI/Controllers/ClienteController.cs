using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;


[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.GetAllClientesAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteService.GetClienteByIdAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }
        return Ok(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClienteModel cliente)
    {
        var createdCliente = await _clienteService.CreateClienteAsync(cliente);
        return CreatedAtAction(nameof(GetById), new { id = createdCliente.id_client}, createdCliente);
    }

    [HttpPost("login")]
    public async Task<IActionResult> logIn([FromBody] Dictionary<string, string> credentials)
    {
        string username = credentials["username"];
        string password = credentials["password"];

        var client = await _clienteService.logIn(username, password);

        if (client != null) {
            return Ok(client);
        } 
        else {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ClienteModel cliente)
    {
        if (id != cliente.id_client)
        {
            return BadRequest();
        }
        await _clienteService.UpdateClienteAsync(cliente);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clienteService.DeleteClienteAsync(id);
        return NoContent();
    }
}