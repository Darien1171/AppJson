using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJson.Json
{
    internal class Plataforma
    {
        public string ObtenerPath(string nombreArchivo)
        {
            string ruta = "";
            string directorio = "archivosjson";
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),directorio);
            }
            else if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), directorio);
            }

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            ruta = Path.Combine(ruta, nombreArchivo);
            return ruta;
        }
    }
}
