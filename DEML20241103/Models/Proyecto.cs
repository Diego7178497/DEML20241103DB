﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEML20241103.Models
{
    public class Proyecto
    {
        public Proyecto()
        {
            DetProyectos = new List<DetProyecto>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaInicial { get; set; }

        // Relación uno a muchos con DetProyecto
        public virtual IList<DetProyecto> DetProyectos { get; set; }
    }
}
