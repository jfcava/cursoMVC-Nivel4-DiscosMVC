using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disco_app_MVC.Models.Dominio
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlTapa { get; set; }
        public Estilo Estilo { get; set; }
        public TipoEdicion TipoEdicion { get; set; }
    }
}
