using DataAccess.Entities;
using System.Collections.Generic;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess
{
    public class PersonasRepository : IPersonasRepository
    {
        public PersonasRepository() { }
        public bool AddPersona(Persona persona)
        {
            try
            {
                string path = Environment.CurrentDirectory;
                string fullPath = path + "/examen/";
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                string filePath = Path.Combine(fullPath, "data.txt");
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(persona.Id + ";" + persona.nombre + ";" + persona.direccion + ";" + persona.telefono + ";" + persona.email);
                    writer.Flush();
                    writer.Close();
                }
                return true;

            }
            catch
            {
                return false;
            }
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                string path = Environment.CurrentDirectory;
                string fullPath = path + "/examen/";
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                string filePath = Path.Combine(fullPath, "data.txt");
                if (File.Exists(filePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        Persona persona = new Persona();
                        string[] lineData = line.Split(';');
                        persona.Id = Convert.ToInt32(lineData[0]);
                        persona.nombre = lineData[1];
                        persona.direccion = lineData[2];
                        persona.telefono = lineData[3];
                        persona.email = lineData[4];
                        personas.Add(persona);
                    }
                }
                return personas;

            }
            catch
            {
                return personas;
            }
        }

        public List<Persona> GetPersonaById(int id)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                string path = Environment.CurrentDirectory;
                string fullPath = path + "/examen/";
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                string filePath = Path.Combine(fullPath, "data.txt");
                if (File.Exists(filePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        Persona persona = new Persona();
                        string[] lineData = line.Split(';');
                        if (Convert.ToInt32(lineData[0]) != id)
                        {
                            persona.Id = Convert.ToInt32(lineData[0]);
                            persona.nombre = lineData[1];
                            persona.direccion = lineData[2];
                            persona.telefono = lineData[3];
                            persona.email = lineData[4];
                            personas.Add(persona);
                        }
                    }
                }
                return personas;

            }
            catch
            {
                return personas;
            }
        }

        public bool DeleteFile()
        {
            string path = Environment.CurrentDirectory;
            string fullPath = path + "/examen/";
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);

            string filePath = Path.Combine(fullPath, "data.txt");

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}