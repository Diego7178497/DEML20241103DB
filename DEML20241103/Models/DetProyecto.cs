using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEML20241103.Models
{
    public class DetProyecto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tarea { get; set; }
        [Required]
        public int Orden { get; set; }

        [Display(Name = "Cliente")]
        public int ProyectoId { get; set; }

        public virtual Proyecto? Proyecto { get; set; }
    }
}
