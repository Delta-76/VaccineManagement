using System.ComponentModel.DataAnnotations;

namespace VaccineManagement.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int DosesRequired { get; set; }

        public int? DaysBetweenDoses { get; set; }

        public int TotalDosesReceived { get; set; } = 0;
        public int TotalDosesLeft     { get; set; } = 0;

        // Parameterless ctor for EF Core
        public Vaccine() { }

        // Constructor used by VaccineStore
        public Vaccine(string name, int dosesRequired, int daysBetweenDoses, int totalDosesReceived)
        {
            Name = name;
            DosesRequired = dosesRequired;
            DaysBetweenDoses = daysBetweenDoses;
            TotalDosesReceived = totalDosesReceived;
            TotalDosesLeft     = totalDosesReceived;
        }
    }
}
