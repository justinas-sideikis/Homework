using System;
using System.Collections.Generic;

namespace Homework.Models
{
    public class Manicipality
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public List<Tax> Taxes { get; set; }
    }
}
