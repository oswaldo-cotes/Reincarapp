using System;
namespace Reincarapp.Models.MyModels
{
    public class RepartoDet
    {
        public RepartoDet()
        {
        }

        public string nombre_clasificacion_adicional { get; set; }
        public double valor_recaudo { get; set; }
        public double valor_compromiso { get; set; }
        public double valor_honorarios { get; set; }
        public string subreparto { get; set; }

    }
}
