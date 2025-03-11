using AppJson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppJson.Json
{
    internal class PersonaJson
    {
        public static async Task RegistrarPersona(List<Persona> personas) 
        { 
            Plataforma oPlataforma = new Plataforma();
            string path = oPlataforma.ObtenerPath("persona.json");
            string json = JsonSerializer.Serialize(personas, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        public static async Task<List<Persona>> ListaPersonas()
        {
            Plataforma oPlataforma = new Plataforma();
            string path = oPlataforma.ObtenerPath("personas.json");
            if (!File.Exists(path))
            {
                return new List<Persona>();
            }
            string json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<List<Persona>>(json) ?? new List<Persona>();
        }
    }
}
