using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ElectroTransportDepo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        [Required(ErrorMessage = "Отсутствует поле ФИО")]
        public string Name { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }

        public int? DepoId { get; set; }

        [DisplayName("Депо")]
        public virtual Depo Depo { get; set; }

        public int? PositionId { get; set; }

        [DisplayName("Должность")]
        public virtual Position Position { get; set; }
    }
}