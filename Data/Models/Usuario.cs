using System;
using System.Collections.Generic;

namespace Backrest.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime? Fecha { get; set; }

    public int? Dni { get; set; }

    public string? Domicilio { get; set; }

    public string Email { get; set; } = null!;

    public string Passwrd { get; set; } = null!;

    public string Permiso { get; set; } = null!;
}
