using System;
using System.Collections.Generic;

namespace wellness.Service.Database;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string? RefreshToken { get; set; } = string.Empty;

    public DateTime TokenCreated { get; set; }

    public DateTime TokenExpires { get; set; }

    public string UserName { get; set; } = null!;

    public string? Phone { get; set; }

    public bool Status { get; set; }
    public bool? Prisutan { get; set; }

    public byte[]? Picture { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<Membership> Memberships { get; } = new List<Membership>();

    public virtual ICollection<Rating> Ratings { get; } = new List<Rating>();

    public virtual ICollection<Record> Records { get; } = new List<Record>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual Role Role { get; set; } = null!;
}
