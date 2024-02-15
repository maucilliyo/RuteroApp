using Microsoft.EntityFrameworkCore;
using RuteroApp.Models;

namespace RuteroApp.Utilidades
{
    public class ConexionDb : DbContext
    {
        //RUTA DEL ARCHIVO DE BASES DE DATOS SQL LITE
        public static string directorySqlLite = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //
        public DbSet<Empleado> Empleados { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConexionDb = $"Filename={Path.Combine(directorySqlLite, "RutaApp.db")}";
            optionsBuilder.UseSqlite(ConexionDb);
        }
    }
}
