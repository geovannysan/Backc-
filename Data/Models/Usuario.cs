using System;
using System.Collections.Generic;

namespace Backrest.Models;

public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int MZ { get; set; }

    public int? Villas{ get; set; }

    public int? celular { get; set; }

    public string Correo { get; set; } = null!;

}
