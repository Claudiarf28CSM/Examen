using Business;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Examen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ILogger<PersonasController> _logger;
        private IPersonaBusiness _personaBusiness;

        public PersonasController(ILogger<PersonasController> logger, IPersonaBusiness personaBusiness)
        {
            _logger = logger;
            _personaBusiness = personaBusiness;
        }

        [HttpGet]
        [Route("obtenerPersona")]
        public List<PersonaR> GetPersonas()
        {
            List<PersonaR> personasR = new List<PersonaR>();
            try
            {
             personasR = _personaBusiness.GetAllPersonas();
               
              return personasR;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
               
            }
            return personasR;
        }

        [HttpPost]
        [Route("agregarPersona")]
        public List<PersonaR> AddPersonas(PersonaR personas)
        {
            List<PersonaR> personasR = new List<PersonaR>();
            try
            {
                personasR = _personaBusiness.AddPersona(personas);
              

                return personasR;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return personasR;
        }

        [HttpPut]
        [Route("actualizarPersona")]
        public List<PersonaR> updatePersonas(PersonaR personas)
        {
            List<PersonaR> personasR = new List<PersonaR>();
            try
            {
                var result = _personaBusiness.UpdatePersona(personas);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return personasR;
        }

        [HttpDelete]
        [Route("eliminarPersona")]
        public List<PersonaR> EliminarPersona(int idPersona)
        {
            List<PersonaR> personasR = new List<PersonaR>();
            try
            {
                List<PersonaR> personas = new List<PersonaR>();
               personas = _personaBusiness.DeletePersona(idPersona);
               
                
                return personas;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
               
            }
            return personasR;
        }
    }
}
