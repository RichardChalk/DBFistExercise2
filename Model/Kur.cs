using System;
using System.Collections.Generic;

#nullable disable

namespace DBFistExercise2.Model
{
    public partial class Kur
    {
        public Kur()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Namn { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
