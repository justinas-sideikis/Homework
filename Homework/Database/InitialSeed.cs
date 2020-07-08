using Homework.Models;
using Homework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Database
{
    public static class InitialSeed
    {
        internal static void Initialize(HomeworkDbContext context)
        {
            context.Database.EnsureCreated();

            var hasManicipalities = context.Manicipalities.Any();
            var hasTaxes = context.Taxes.Any();

            if (!hasManicipalities)
            {
                var manicipalities = new List<Manicipality>
                {
                    new Manicipality
                    {
                        Name = "Vilnius"
                    },
                    new Manicipality
                    {
                        Name = "Kaunas"
                    },
                    new Manicipality
                    {
                        Name = "Klaipėda"
                    }
                };

                context.Manicipalities.AddRange(manicipalities);
                context.SaveChanges();
            }

            if (!hasTaxes)
            {
                var vilniusManicipality = context.Manicipalities.First(m => m.Name == "Vilnius");
                var kaunasManicipality = context.Manicipalities.First(m => m.Name == "Kaunas");
                var klaipedaManicipality = context.Manicipalities.First(m => m.Name == "Klaipėda");

                var taxes = new List<Tax>
                {
                    new Tax
                    {
                        ManicipalityId = vilniusManicipality.Id,
                        Period = TaxPeriod.Yearly,
                        Start = DateTime.Parse("2019-01-01"),
                        End = DateTime.Parse("2020-12-31"),
                        Rate = 0.7
                    },
                    new Tax
                    {
                        ManicipalityId = kaunasManicipality.Id,
                        Period = TaxPeriod.Yearly,
                        Start = DateTime.Parse("2020-01-01"),
                        End = DateTime.Parse("2020-12-31"),
                        Rate = 0.6
                    },
                    new Tax
                    {
                        ManicipalityId = klaipedaManicipality.Id,
                        Period = TaxPeriod.Monthly,
                        Start = DateTime.Parse("2019-01-01"),
                        End = DateTime.Parse("2019-06-30"),
                        Rate = 0.5
                    },
                    new Tax
                    {
                        ManicipalityId = vilniusManicipality.Id,
                        Period = TaxPeriod.Monthly,
                        Start = DateTime.Parse("2019-05-01"),
                        End = DateTime.Parse("2020-05-31"),
                        Rate = 0.4
                    },
                    new Tax
                    {
                        ManicipalityId = vilniusManicipality.Id,
                        Period = TaxPeriod.Weekly,
                        Start = DateTime.Parse("2019-07-07"),
                        End = DateTime.Parse("2020-07-21"),
                        Rate = 0.3
                    },
                    new Tax
                    {
                        ManicipalityId = kaunasManicipality.Id,
                        Period = TaxPeriod.Daily,
                        Start = DateTime.Parse("2020-04-05"),
                        End = DateTime.Parse("2020-06-10"),
                        Rate = 0.2
                    },
                    new Tax
                    {
                        ManicipalityId = klaipedaManicipality.Id,
                        Period = TaxPeriod.Monthly,
                        Start = DateTime.Parse("2020-01-01"),
                        End = DateTime.Parse("2020-01-31"),
                        Rate = 0.1
                    }
                };

                context.Taxes.AddRange(taxes);
                context.SaveChanges();
            }
        }
    }
}
