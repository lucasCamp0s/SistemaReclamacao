using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reclamacao.Models
{
    public class Usuario
    {
        [Key]
        public int id_user { get; set; }

        [Required(ErrorMessage ="Campo primeiro nome obrigatorio")]
        [Display(Name ="Primeiro nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo último nome obrigatorio")]
        [Display(Name = "Último nome")]
        public string ultimoNome { get; set; }

        [Required(ErrorMessage = "Campo cpf obrigatorio")]
        [Index("Usuario_cpf_Index", IsUnique = true)]
        [MaxLength(30, ErrorMessage = "o campo cpf pode ter até 11 caractres")]
        [Display(Name = "CPF")]
        
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo email obrigatorio")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(250,ErrorMessage ="o campo email pode ter até 250 caractres")]
        [Index("Usuario_email_Index",IsUnique =true)]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo nascimento obrigatorio")]
        [Display(Name = "Nascimento")]
        [DataType(DataType.Date)]
        public DateTime nascimento { get; set; }

        [Required(ErrorMessage = "Campo telefone obrigatorio")]
        [Display(Name = "Telefone")]
        [MaxLength(30, ErrorMessage = "o campo telefone pode ter até 30 caractres")]
        [DataType(DataType.PhoneNumber)]
        [Index("Usuario_telefone_Index", IsUnique = true)]
        public string telefone { get; set; }

        [Required(ErrorMessage = "Campo senha obrigatorio")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [MaxLength(100, ErrorMessage = "o campo senha pode ter até 100 caractres")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Campo endereço obrigatorio")]
        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo  cidade obrigatorio")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Campo estado obrigatorio")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Display(Name = "Usuário")]
        public string nomeCompleto { get {return string.Format("{0}{1}", nome, ultimoNome); } }

        //criando relacionamento
       
    }
}