using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CraftApp.Models
{
    public class Order
    {
        [BindNever]        
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(10, MinimumLength = 1)]
        [Required(ErrorMessage = "Введите имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20, MinimumLength = 1)]
        [Required(ErrorMessage = "Не более 20 символов")]
        public string Surname { get; set; }

        [Display(Name = "Адресс")]
        [StringLength(100)]        
        public string Adress { get; set; }

        [Display(Name = "Контактный телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, MinimumLength = 8)]
        [Required(ErrorMessage = "Введите контактный телефон")]
        public string Phone { get; set; }

        [Display(Name = "Почта")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30, MinimumLength = 5)]
        [Required(ErrorMessage = "Введите почту")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
