using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Escala
{
    public int EscalaId { get; set; }

    public int VueloId { get; set; }

    public int DestinoId { get; set; }

    public DateTime FechaLlegada { get; set; }

    public DateTime FechaSalida { get; set; }

    public virtual Destino Destino { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
