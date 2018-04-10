using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectroTransportDepo.Models
{
    public class Depo
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Отсутствует поле Название")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Телефон")]
        [Required(ErrorMessage = "Отсутствует поле Телефон")]
        public string Phone { get; set; }

        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Отсутствует поле Адрес")]
        public string Address { get; set; }

        public int? CityId { get; set; }

        [DisplayName("Город")]
        public virtual City City { get; set; }
    }
}