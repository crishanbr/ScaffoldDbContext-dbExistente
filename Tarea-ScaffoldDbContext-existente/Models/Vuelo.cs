using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Vuelo
{
    public int VueloId { get; set; }

    public int AerolineaId { get; set; }

    public int AvionId { get; set; }

    public int PilotoId { get; set; }

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Avione Avion { get; set; } = null!;

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual Piloto Piloto { get; set; } = null!;
}
