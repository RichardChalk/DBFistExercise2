using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.CompilerServices;

#nullable disable

namespace DBFistExercise2.Model
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? KursId { get; set; }

        // Entity Framework och Lazy Loading:
        // Ett vanligt skäl till att använda virtual i detta sammanhang
        // är relaterat till Entity Framework, ett ORM(Object-Relational Mapping) verktyg i.NET.
        
        // När en egenskap är märkt som virtual, kan Entity Framework använda lazy loading.
        // Det innebär att när du hämtar en Student-entitet från databasen,
        // laddas inte Kurs-egenskapen direkt.
        // Istället laddas den först när du faktiskt använder den.
        // Detta kan förbättra prestanda genom att undvika att ladda onödig data.
        public virtual Kur Kurs { get; set; }
    }
}
