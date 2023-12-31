﻿using Common.Persistence.Repositories;

namespace Week3.Domain.Entities;

public class User : BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        PasswordHash = Array.Empty<byte>();
        PasswordSalt = Array.Empty<byte>();
        Pets = new HashSet<Pet>();
    }

    public User(
        string firstName,
        string lastName,
        string email,
        byte[] passwordSalt,
        byte[] passwordHash,
        bool status
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        byte[] passwordSalt,
        byte[] passwordHash,
        bool status
    )
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
    }
}
