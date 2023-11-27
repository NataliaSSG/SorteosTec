using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Models;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Data;
using System.Text.RegularExpressions;

public class ClienteService : IClienteService
{
    private readonly dbContext _context;

    public ClienteService(dbContext context)
    {
        _context = context;
    }

    public async Task<List<ClienteModel>> GetAllClientesAsync()
    {
        return await _context.client.ToListAsync();
    }

    public async Task<ClienteModel?> GetClienteByIdAsync(int id)
    {
        return await _context.client.FindAsync(id);
    }

    // Post
    public async Task<ClienteModel> CreateClienteAsync(ClienteModel cliente)
    {
        if (Regex.IsMatch(cliente.email, @"^L0\d{7}@tec\.mx$")) {
            cliente.role = "Admin";
        }
        else {
            cliente.role = "Cliente";
        }

        _context.client.Add(cliente);
        await _context.SaveChangesAsync();
        
        return cliente;
    }
    public async Task<ClienteModel?> logIn(string username, string password)
    {
        var client = await _context.client.FirstOrDefaultAsync(cliente => cliente.username == username && cliente.user_password == password || cliente.email == username && cliente.user_password == password);

        if (client != null) {
            return client;
        } 
        else {
            return null;
        }
    }

    // Put
    public async Task UpdateClienteAsync(ClienteModel cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // Delete
    public async Task DeleteClienteAsync(int id)
    {
        var cliente = await _context.client.FindAsync(id);
        if (cliente != null)
        {
            _context.client.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}