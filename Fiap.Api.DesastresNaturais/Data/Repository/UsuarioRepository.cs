using Fiap.Api.DesastresNaturais.Data.Contexts;
using Fiap.Api.DesastresNaturais.Repository;
using Fiap.Api.DesastresNaturais.Models;
using Microsoft.EntityFrameworkCore;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseContext _context;

    public UsuarioRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<UsuarioModel> GetAll() => _context.Usuario.AsNoTracking().ToList();

    public UsuarioModel GetById(int id)
    {
        return _context.Usuario.Find(id);
    }

    public void Add(UsuarioModel usuario)
    {
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
    }

    public void Update(UsuarioModel usuario)
    {
        _context.Update(usuario);
        _context.SaveChanges();
    }

    public void Delete(UsuarioModel usuario)
    {
        _context.Usuario.Remove(usuario);
        _context.SaveChanges();
    }
}