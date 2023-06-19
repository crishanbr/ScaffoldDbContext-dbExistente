using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Permiso
{
    public int PermisoId { get; set; }

    public int RolId { get; set; }

    public string Modulo { get; set; } = null!;

    public bool PuedeVer { get; set; }

    public bool PuedeEditar { get; set; }

    public virtual Role Rol { get; set; } = null!;
}
