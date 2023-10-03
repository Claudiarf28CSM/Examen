using DataAccess;
using DataAccess.Entities;
using System.Collections.Generic;

namespace Business
{
    public class PersonaBusiness : IPersonaBusiness
    {
        private IPersonasRepository _personasRepository;
        public PersonaBusiness(IPersonasRepository personasRepository) {
            _personasRepository = personasRepository;
        }
        public List<PersonaR> AddPersona(PersonaR personas)
        {
            List<PersonaR> personasResult = new List<PersonaR>();
            int id = personas.Id + 1;
            Persona persona = new Persona();
            persona.Id = id;
            persona.nombre = personas.nombre;
            persona.direccion = personas.direccion;
            persona.telefono = personas.telefono;
            persona.email = personas.email;
            var response = _personasRepository.AddPersona(persona);

            List<Persona> personaEntity = _personasRepository.GetPersonas();
            foreach (var p in personaEntity)
            {
                PersonaR personas1 = new PersonaR();
                personas1.Id = p.Id;
                personas1.nombre = p.nombre;
                personas1.direccion = p.direccion;
                personas1.telefono = p.telefono;
                personas1.email = p.email;
                personasResult.Add(personas1);
            }
            personasResult = personasResult.OrderBy(p => p.Id).ToList();
            return personasResult;
        }

        public List<PersonaR> DeletePersona(int idPersona)
        {
            List<Persona> persona = new List<Persona>();
            List<PersonaR> personas = new List<PersonaR>();
            persona = _personasRepository.GetPersonaById(idPersona);
            var result = _personasRepository.DeleteFile();
            if (result)
            {
                foreach(var p in persona)
                {
                    _personasRepository.AddPersona(p);
                }
                List<Persona> personaEntity = _personasRepository.GetPersonas();
                foreach (var p in personaEntity)
                {
                    PersonaR personas1 = new PersonaR();
                    personas1.Id = p.Id;
                    personas1.nombre = p.nombre;
                    personas1.direccion = p.direccion;
                    personas1.telefono = p.telefono;
                    personas1.email = p.email;
                    personas.Add(personas1);
                }
                personas = personas.OrderBy(p => p.Id).ToList();
                return personas;
            }
            else
            {
                return personas;
            }
            
        }

        public List<PersonaR> GetAllPersonas()
        {
            List <PersonaR> personas = new List<PersonaR>();

            List<Persona> personaEntity = _personasRepository.GetPersonas();
            foreach(var persona in personaEntity)
            {
                PersonaR personas1 = new PersonaR();
                personas1.Id = persona.Id;
                personas1.nombre = persona.nombre;
                personas1.direccion = persona.direccion;
                personas1.telefono = persona.telefono;
                personas1.email = persona.email;
                personas.Add(personas1);
            }
            personas = personas.OrderBy(p => p.Id).ToList();
            return personas;
        }

        public List<PersonaR> UpdatePersona(PersonaR personas)
        {
            List<PersonaR> personasResult = new List<PersonaR>();
            List<Persona> persona = new List<Persona>();
            persona = _personasRepository.GetPersonaById(personas.Id);
            var result = _personasRepository.DeleteFile();
            if (result)
            {
                foreach (var p in persona)
                {
                    _personasRepository.AddPersona(p);
                }
                Persona persona1 = new Persona();
                persona1.Id = personas.Id;
                persona1.nombre = personas.nombre;
                persona1.direccion = personas.direccion;
                persona1.telefono = personas.telefono;
                persona1.email = personas.email;
                 _personasRepository.AddPersona(persona1);


                List<Persona> personaEntity = _personasRepository.GetPersonas();
                foreach (var p in personaEntity)
                {
                    PersonaR personas1 = new PersonaR();
                    personas1.Id = p.Id;
                    personas1.nombre = p.nombre;
                    personas1.direccion = p.direccion;
                    personas1.telefono = p.telefono;
                    personas1.email = p.email;
                    personasResult.Add(personas1);
                }

                personasResult = personasResult.OrderBy(p => p.Id).ToList();
                return personasResult;
            }
            else
            {
                return personasResult;
            }
        }
    }
}