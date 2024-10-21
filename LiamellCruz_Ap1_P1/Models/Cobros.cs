using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiamellCruz_Ap1_P1.Models;

public class Cobros
{
    [Key]

    
    public int CobroId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Campo obligatorio")]
    public double Monto { get; set; }

    [ForeignKey("DeudorId")]
    public int DeudorId { get; set; }
    public Deudor? Deudor { get; set; }

   [ ForeignKey("CobroId")]
    public ICollection<CobrosDetalle> CobroDetalle { get; set; } = new List<CobrosDetalle>();


}
