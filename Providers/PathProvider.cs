using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CRUDHoteles.Providers
{
    public enum Folders
    {
        Fotos = 0
    }

    public class PathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public PathProvider(IWebHostEnvironment hostEnvironment) { 
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if(folder == Folders.Fotos)
            {
                carpeta = "Fotos";
            }

            string patch = Path.Combine(this.hostEnvironment.WebRootPath, carpeta, fileName);

            //if(folder == Folders.Temp)
            //{
            //    patch = Path.Combine(Path.GetFullPath(), fileName);
            //}
            return patch;
        }
    }
}
