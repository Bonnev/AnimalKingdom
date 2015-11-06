﻿namespace PetBook.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class PetBookDbContext : IdentityDbContext<User>
    {
        public PetBookDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static PetBookDbContext Create()
        {
            return new PetBookDbContext();
        }
    }
}
