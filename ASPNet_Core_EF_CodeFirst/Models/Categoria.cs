using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNet_Core_EF_CodeFirst.Models
{
    public class Categoria
    {
        public int idcategoria { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3 caracteres.")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [StringLength(255,  ErrorMessage = "la descripción no debe de tener más de 255 caracteres.")]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        public bool? estado { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
