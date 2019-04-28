using System.ComponentModel.DataAnnotations;

namespace ECommercer.Models
{
    public class City
    {   [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage ="Campo Nome obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo departamento obrigatório!")]
        [Range(1,double.MaxValue,ErrorMessage ="Selecione um departamento")]
        public int DepartamentsId { get; set; }

        //criando o relacionamento com outra classe
        public virtual Departaments Departament { get; set; }
    }
}