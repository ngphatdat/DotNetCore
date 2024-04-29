using System;
using Microsoft.EntityFrameworkCore;

namespace NewsWebAppAPI.Models
{
	public class Database:DbContext

	{
	 public	DbSet<User> User { get; set; }
        public Database(DbContextOptions<Database> options) : base(options)
        { 

        }


    }
}

