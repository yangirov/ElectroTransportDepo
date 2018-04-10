using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectroTransportDepo.Models
{
    public class RollingStock
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Отсутствует поле Название")]
        public string Name { get; set; }

        public int? TransportTypeId { get; set; }

        [DisplayName("Тип транспорта")]
        public virtual TransportsType TransportType { get; set; }
    }
}