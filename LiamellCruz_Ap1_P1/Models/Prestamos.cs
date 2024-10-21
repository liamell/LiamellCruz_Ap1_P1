using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiamellCruz_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    
    public int PrestamoId { get; set; }

    [Required(ErrorMessage =" Campo obligatorio")]
    [RegularExpression(@"[A-Za-z\s]+$", ErrorMessage= "Solo se permiten letras")]
    public string? Concepto { get; set; }
    [Required(ErrorMessage = " Campo obligatorio")]
  
    public double Monto { get; set; }


    [ForeignKey("DeudorId")]
    public int DeudorId { get; set; }
    public Deudor? Deudor { get; set; }


}



