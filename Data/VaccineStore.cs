using System.Collections.Generic;
using VaccineManagement.Models;

namespace VaccineManagement.Data
{
    public static class VaccineStore
    {
        private static readonly List<Vaccine> _vaccines = new()
        {
            new Vaccine("Pfizer/BioNTech",   2, 21, 10000),
            new Vaccine("Johnson & Johnson", 1,  0,  5000)
        };

        public static IReadOnlyList<Vaccine> Vaccines => _vaccines;

        public static void AddVaccine(Vaccine v) 
            => _vaccines.Add(v);

        public static void AddDoses(int index, int count)
        {
            if (index >= 0 && index < _vaccines.Count)
            {
                _vaccines[index].TotalDosesReceived += count;
                _vaccines[index].TotalDosesLeft     += count;
            }
        }
    }
}
