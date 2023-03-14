using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Passwordd { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public byte? IdRol { get; set; }
    public string? Nombre_Rol { get; set; }

    public string? Sexo { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Curp { get; set; }

    public string? Imagen { get; set; }

    public bool? Status { get; set; }
    public int IdDireccion { get; set; }  public int IdColonia { get; set; }
    public string? Nombre_Colonia { get; set; }
    public string? CodigoPostal { get; set; }
    public int IdMunicipio { get; set; }
    public string? Nombre_Municipio { get; set; }
    public int IdEstado { get; set; }
    public string? Nombre_Estado { get; set; }
    public int IdPais { get; set; }
    public string? Nombre_Pais { get; set; }
    public string? Calle { get; set; }
    public string? NumeroInterior { get; set; }
    public string? NumeroExterior { get; set; }
  

    public virtual ICollection<Aseguradora> Aseguradoras { get; } = new List<Aseguradora>();

    public virtual ICollection<Direccion> Direccions { get; } = new List<Direccion>();

    public virtual ICollection<EmpresaPoliza> EmpresaPolizas { get; } = new List<EmpresaPoliza>();

    public virtual Rol? IdRolNavigation { get; set; }

    public virtual ICollection<Poliza> Polizas { get; } = new List<Poliza>();

    public virtual ICollection<Vigencium> Vigencia { get; } = new List<Vigencium>();
}
