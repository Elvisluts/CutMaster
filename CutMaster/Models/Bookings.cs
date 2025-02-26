namespace CutMaster.Models
{
    public class Booking
    {
        public int Id { get; set; }  // Unique booking ID
        public string CustomerName { get; set; } = string.Empty; // Name of the customer
        public string BarberName { get; set; } = string.Empty; // Name of the barber
        public DateTime BookingDate { get; set; } // Date and time of booking
        public string ServiceType { get; set; } = string.Empty; // Type of service (e.g., haircut, shave)
        public string Status { get; set; } = "Pending"; // Default status: Pending, Confirmed, or Completed
    }
}
