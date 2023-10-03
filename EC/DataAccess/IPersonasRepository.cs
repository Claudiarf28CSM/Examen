using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPersonasRepository
    {
        bool AddPersona(Persona persona);
        List<Persona> GetPersonas();
        List<Persona> GetPersonaById(int id);
        bool DeleteFile();

    }
}
