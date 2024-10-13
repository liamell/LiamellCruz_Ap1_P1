using System.ComponentModel.DataAnnotations;

namespace LiamellCruz_Ap1_P1.Models;

public class Deudor
{
    [Key]
    public int DeudorId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Solo se permiten letras")]
    public string? Nombres { get; set; }


}

