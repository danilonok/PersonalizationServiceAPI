using System.ComponentModel.DataAnnotations;

namespace PersonalizationServiceAPI.Models
{
    public class PersonalizationSettingsObject
    {

        public bool EmailNotifications { get; set; } = true;
        public bool NightMode { get; set; } = false;


    }
}
