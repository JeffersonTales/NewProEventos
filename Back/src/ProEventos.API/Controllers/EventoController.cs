using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Model;

namespace ProEventos.API.Back.src.ProEventos.API.Controllers {

    [ApiController]
    [Route("api/[controller]")]

    public class EventoController : ControllerBase {

        #region atributos
        public IEnumerable<Evento> _evento = new Evento[] {
                new Evento() { EventoId = 1,
                               Tema = "Angular 12 e .NET 5",
                               Local = "Caxias do Sul",
                               Lote = "1º Lote",
                               QtdePessoas = 250,
                               DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                               ImagemURL = "" },
                new Evento() { EventoId = 2,
                               Tema = "Angular 12 e .NET 5",
                               Local = "Curitiba",
                               Lote = "2º Lote",
                               QtdePessoas = 350,
                               DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                               ImagemURL = "" },
            };
        #endregion

        #region construtor
        public EventoController() {

        }
        #endregion

        [HttpGet]
        public IEnumerable<Evento> Get() {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id) {
            return _evento.Where(item => item.EventoId == id);  //teste
        }
    }
}
