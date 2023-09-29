using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Web.Models;
using Entidades.DataContracts;
using Logica_de_negocios;
using Entidades;

namespace Api_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        ArquitecturaCapasDBContext _context = new ArquitecturaCapasDBContext();
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public Response Post([FromBody]Entidades.User user) {
            Servicios services = new Servicios();
            Response us = services.CreateUser(new Entidades.User(user.Id, user.Username, user.Password));
            return us;
        }
        /*
        [HttpGet]
        public Response Get([FromBody]string username, string password) {
            Servicios services = new Servicios();
            return new Response();
        }*/

        [HttpPut]
        public Response Put([FromBody] Entidades.User user)
        {
            Servicios services = new Servicios();
            Response us = services.EditUser(new Entidades.User(user.Id, user.Username, user.Password));
            return us;
        }
        /*
        [HttpGet]
        public IActionResult ListarUsuarios()
        {
                Servicios services = new Servicios();

                var usuarios = services.ListUsers();
                return Ok(usuarios);
         
        }
       */
        [HttpGet]
        public LoginResponse Login([FromBody]LoginRequest user)
        {
            Servicios services = new Servicios();

            return services.LoginUser(user);
        }
    }
}
