using Homework.Models.Enums;
using System;

namespace Homework.Models
{
    public class Tax
    {
        public Guid Id { get; set; }
        public Guid ManicipalityId { get; set; }
        public double Rate { get; set; }
        public TaxPeriod Period { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Manicipality Manicipality { get; set; }
    }
}
