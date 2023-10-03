using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IPersonaBusiness
    {
        List<PersonaR> AddPersona(PersonaR personas);
        List<PersonaR> DeletePersona(int idPersona);
        List<PersonaR> GetAllPersonas();
        List<PersonaR> UpdatePersona(PersonaR personas);
    }
}
