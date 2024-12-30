using System.ComponentModel.DataAnnotations;

namespace PersonalizationServiceAPI.Models
{
    public class PersonalizationSettings
    {
        [Key]
        public int UserId { get; set; }
        public bool EmailNotifications { get; set; } = true;
        public bool NightMode { get; set; } = false;


    }
}
