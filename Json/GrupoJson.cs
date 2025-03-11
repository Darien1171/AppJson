using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppJson.Models;

namespace AppJson.Json
{
    internal class GrupoJson
    {
        public static async Task RegistrarGrupo(List<Grupo> grupos)
        {
            Plataforma oPlataforma = new Plataforma();
            string path = oPlataforma.ObtenerPath("gruposjson.json");
            string json = JsonSerializer.Serialize(grupos, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(path, json);
        }

        public static async Task<List<Grupo>> ListaGrupos()
        {
            Plataforma oPlataforma = new Plataforma();
            string path = oPlataforma.ObtenerPath("gruposjson.json");
            if (!File.Exists(path))
            {
                return new List<Grupo>();
            }
            string json = await File.ReadAllTextAsync(path);
            return JsonSerializer.Deserialize<List<Grupo>>(json)?? new List<Grupo>();
        }
    }
}
