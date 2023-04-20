﻿namespace BongDa.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Number { get; set; }
        public string Address { get; set; }
        public List<Pitch> Pitch { get; set; }
    }
}
