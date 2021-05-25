using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Application.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int SubjectId { get; set; }
        public Subject Subject {get; set;}
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Поле не должно содержать символов")]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [StringLength(100, MinimumLength = 0, ErrorMessage = "Длина коментария должна быть до 100 символов")]
        public string Description { get; set; }
    }
}