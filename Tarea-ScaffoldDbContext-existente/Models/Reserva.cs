using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public DateOnly FechaReserva { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;
}
