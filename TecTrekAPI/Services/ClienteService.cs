using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TecTrekAPI.Models;
using TecTrekAPI.Interfaces;
using TecTrekAPI.Data;

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

    public async Task<ClienteModel> CreateClienteAsync(ClienteModel cliente)
    {
        _context.client.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task UpdateClienteAsync(ClienteModel cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

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