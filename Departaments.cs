using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommercer.Models
{
    public class Departaments
    {
        public int DepartamentsId { get; set; }
        [Required(ErrorMessage = "O Campo nome é obrigatório!")]
        [Index("Departament_Name_Index",IsUnique =true)]
        [MaxLength(50,ErrorMessage ="o campo nome recebe no maximo 50 caractres")]
        public string Name { get; set; }
          public virtual ICollection<City> Cities  { get; set; }
   
    }
}