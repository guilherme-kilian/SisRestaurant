using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.ReservationSettings
{
    public class CreateReservationSettingsModel : IValidatableObject
    {
        public bool PaymentRequired { get; set; }

        public TimeOnly StartAt { get; set; }

        public TimeOnly FinishAt { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(StartAt.Equals(FinishAt))
                return [new("StartAt and FinishAt cannot be the same")];

            return [];
        }
    }
}
