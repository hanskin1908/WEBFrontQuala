using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBFrontQuala.Models;

public partial class Sucursal
{
    //[MaxLength(4, ErrorMessage = "el campo codigo no debe exceder los 4 caracteres. ",ErrorMessageResourceType =Type)]
    [Required(ErrorMessage = "El campo codigo es Requerido")]
    [DisplayName("Código")]
    public int Codigo { get; set; }

    [StringLength(250, ErrorMessage = "el campo descripción no debe exceder los 250 caracteres. ")]
    [Required(ErrorMessage = "El campo descripción es Requerido")]
    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    //[MaxLength(250, ErrorMessage = "el campo Dirección no debe exceder los 250 caracteres. ")]
    [Required(ErrorMessage = "El campo Dirección es Requerido")]
    [DisplayName("Dirección")]
    public string Direccion { get; set; } = null!;

    //[MaxLength(250, ErrorMessage = "el campo Identificación no debe exceder los 250 caracteres. ")]
    [Required(ErrorMessage = "El campo Identificación es Requerido")]
    [DisplayName("Identificación")]
    public string Identificacion { get; set; } = null!;

    [DisplayName("Moneda")]
    public int? IdMonedaSuc { get; set; }

    public virtual MonMonedum? IdMonedaSucNavigation { get; set; }
}
