using Homework.Models.Enums;
using System;

namespace Homework.ViewModels
{
    public class TaxAddRequestModel
    {
        public string Manicipality { get; set; }
        public double Rate { get; set; }
        public TaxPeriod Period { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
