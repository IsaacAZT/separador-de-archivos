using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Separador_de_archivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //crear un programa que separe los archivos de una carpeta en subcarpetas segun su extension , world, excel, pdf, imagenes, otros
            Console.WriteLine("Ingrese la ruta de la carpeta a separar:");
            string ruta = Console.ReadLine();
            if (!System.IO.Directory.Exists(ruta))
            {
                Console.WriteLine("La ruta no existe.");
                return;
            }
            string[] archivos = System.IO.Directory.GetFiles(ruta);
            string carpetaWord = System.IO.Path.Combine(ruta, "Word");
            string carpetaExcel = System.IO.Path.Combine(ruta, "Excel");
            string carpetaPDF = System.IO.Path.Combine(ruta, "PDF");
            string carpetaImagenes = System.IO.Path.Combine(ruta, "Imagenes");
            string carpetapowerpoint = System.IO.Path.Combine(ruta, "PowerPoint");
            string carpetaOtros = System.IO.Path.Combine(ruta, "Otros");
            Directory.CreateDirectory(carpetaWord);
            Directory.CreateDirectory(carpetaExcel);
            Directory.CreateDirectory(carpetaPDF);
            Directory.CreateDirectory(carpetaImagenes);
            Directory.CreateDirectory(carpetapowerpoint);
            Directory.CreateDirectory(carpetaOtros);

            int countWord = 0, countExcel = 0, countPDF = 0, countImagenes = 0, countPPT = 0, countOtros = 0;

            foreach (string archivo in archivos)
            {
                string extension = System.IO.Path.GetExtension(archivo).ToLower();
                string nombreArchivo = System.IO.Path.GetFileName(archivo);
                string carpetaDestino = carpetaOtros;

                switch (extension)
                {
                    case ".doc":
                    case ".docx":
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetaWord, nombreArchivo));
                        break;
                    case ".xls":
                    case ".xlsx":
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetaExcel, nombreArchivo));
                        break;
                    case ".pdf":
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetaPDF, nombreArchivo));
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetaImagenes, nombreArchivo));
                        break;
                    case ".ppt":
                    case ".pptx":
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetapowerpoint, nombreArchivo));
                        break;
                    default:
                        System.IO.File.Move(archivo, System.IO.Path.Combine(carpetaOtros, nombreArchivo));
                        break;





                }
                try
                {
                    string destino = Path.Combine(carpetaDestino, nombreArchivo);
                    int contador = 1;

                    while (File.Exists(destino))
                    {
                        string nuevoNombre = Path.GetFileNameWithoutExtension(nombreArchivo) + $"({contador})" + Path.GetExtension(nombreArchivo);
                        destino = Path.Combine(carpetaDestino, nuevoNombre);
                        contador++;
                    }

                    File.Move(archivo, destino);
                    Console.WriteLine($" Movido: {nombreArchivo} → {carpetaDestino}");
                    File.AppendAllText(Path.Combine(ruta, "log.txt"), $"Movido: {nombreArchivo} → {carpetaDestino}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error al mover {nombreArchivo}: {ex.Message}");
                }
            }
            Console.WriteLine("\n Resumen de archivos movidos:");
            Console.WriteLine($"Word: {countWord}");
            Console.WriteLine($"Excel: {countExcel}");
            Console.WriteLine($"PDF: {countPDF}");
            Console.WriteLine($"Imágenes: {countImagenes}");
            Console.WriteLine($"PowerPoint: {countPPT}");
            Console.WriteLine($"Otros: {countOtros}");
            Console.WriteLine("\n Organización completada.");







        }





    }



    
}
