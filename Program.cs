using DBFistExercise2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DBFistExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //   .AddJsonFile($"appsettings.json", true, true);

            //var config = builder.Build();
            
            
            //string connectionString = config.GetConnectionString("DefaultConnection");

            //var options = new DbContextOptionsBuilder<StudentContext>();
            //options.UseSqlServer(connectionString);

            Application app = new Application();
            app.Run();
        }
    }
}
