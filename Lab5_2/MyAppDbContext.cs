using System;
using System.Data.Entity;



namespace Lab5_2
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<ContactDb> Contacts { get; set; }

        public MyAppDbContext():base("DefaultConnection") {}

    }
}
