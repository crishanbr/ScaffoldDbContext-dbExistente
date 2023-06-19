using System;
using System.Collections.Generic;

namespace Tarea_ScaffoldDbContext_existente.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string NumeroCedula { get; set; } = null!;

    public string NumeroCelular { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public byte[]? Imagen { get; set; }

    public int RolId { get; set; }

    public virtual Role Rol { get; set; } = null!;
}
