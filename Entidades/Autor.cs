using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo nombre es requerido")]
        [StringLength(maximumLength : 5,ErrorMessage = "El campo {0} no debe de tener  mas de {1} carácteres")]
        [PrimeraLetraMayuscula]
        public string? Nombre { get; set; }

        //[Range(18, 120)]
        //[NotMapped]
        public int Edad { get; set; }

        //[CreditCard]
        //[NotMapped]
        //public string tarjetaDeCredito { get; set; }

        //[Url]
        //public string URL { get; set; }

        //public string? Direccion { get; set; }

        public List<Libro>? Libros { get; set; }
    }
}
