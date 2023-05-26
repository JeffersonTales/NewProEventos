using Microsoft.EntityFrameworkCore;
using ProEventos.API.Model;

namespace ProEventos.API.Data {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> _options) : base(options: _options) {

        }

        public DbSet<Evento> Eventos { get; set; }
        //testeaaaa
    }
}
