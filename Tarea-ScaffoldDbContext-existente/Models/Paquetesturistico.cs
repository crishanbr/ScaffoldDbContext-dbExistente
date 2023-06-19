using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Paquetesturistico
{
    public int PaqueteTuristicoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }
}
