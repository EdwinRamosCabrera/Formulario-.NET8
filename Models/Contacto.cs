using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Formularios.Models
{
    public class Contacto
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El campo Nombres es obligatorio")]
        [StringLength (100, ErrorMessage = "El campo no puede tener mas de 100 caracteres")]
        [Column("Nombres"), ]
        public string Name { get; set; }

        [Required]
        [StringLength (150, ErrorMessage = "El campo Apellidos no puede tener mas de 150 caracteres")]
        [Column("Apellidos")]
        public string LastName { get; set; }

        [Required (ErrorMessage = " El campo Correo es requerido")]
        [EmailAddress (ErrorMessage = "El formato del correo electrónico es inválido")]
        [Column("Correo")]
        public string Email { get; set; }
        
        [StringLength (9, ErrorMessage = "El campo Teléfono no puede exceder los 9 caracteres")]
        [Column("Telefono")]
        public string? Phone { get; set; }

        [Column("Genero")]
        public string? Gender { get; set; }

        [Column("Ocupacion")]
        public string? Ocupation { get; set; }

        [Required (ErrorMessage = " El campo Comentario es requerido")]
        [StringLength (300, ErrorMessage = "El campo Comentario no puede exceder los 300 caracteres")]
        [Column("Comentario")]
        public string Comment { get; set; }

    }
}