using Core.Interfaces;
using Core.Model;
using Infraestructura.Datos;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio {
    public class PersonaRepositorio : IPersonaRepositorio {
        private readonly ApplicationDbContext db;

        public PersonaRepositorio(ApplicationDbContext db) {
            this.db = db;
        }

        public async Task<Persona> actualizarPersona(Persona persona) {
            db.Update(persona);
            await db.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona> crearPersona(Persona persona) {
            await db.AddAsync(persona);
            await db.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> eliminarPersona(int id) {
            try {
                Persona persona = await db.Persona.FindAsync(id);
                if (persona == null) {
                    return false;
                }
                db.Remove(persona);
                await db.SaveChangesAsync();
                return true;
            } catch (Exception) {
                return false;
            }
        }

        public async Task<Persona> obtenerPersona(int id) {
            return await db.Persona.FindAsync(id);
        }

        public async Task<IReadOnlyList<Persona>> obtenerPersonas() {
            return await db.Persona.ToListAsync();
        }
    }
}
