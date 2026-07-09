using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disco_app_MVC.Models.Dominio
{
    public class Disco
    {
        public int Id { get; set; }
        [DisplayName("Título")]
        [Required(ErrorMessage = "El título es requerido.")]
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        [DisplayName("Cantidad de Canciones")]
        public int CantidadCanciones { get; set; }
        public string UrlTapa { get; set; }
        public Estilo Estilo { get; set; }
        [DisplayName("Tipo de Edición")]
        public TipoEdicion TipoEdicion { get; set; }
    }
}
