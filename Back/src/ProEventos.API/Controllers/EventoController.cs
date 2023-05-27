using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using ProEventos.API.Data;
using ProEventos.API.Model;

namespace ProEventos.API.Back.src.ProEventos.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class EventoController : ControllerBase {

        #region atributos
        private readonly DataContext _context;

        #endregion

        #region construtor
        public EventoController(DataContext context) {
            _context = context;
        }

        #endregion

        [HttpGet]
        public IEnumerable<Evento> Get() {
            return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id) {
            return _context.Eventos.First(item => item.EventoId == id);//teste
        }
    }
}
