using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectroTransportDepo.Models
{
    public class City
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Отсутствует поле Название")]
        public string Name { get; set; }
    }
}