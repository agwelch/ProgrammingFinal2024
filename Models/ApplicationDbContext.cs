using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;


namespace ProgrammingFinal2024.Models
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
   
           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderID)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverID)
                .OnDelete(DeleteBehavior.Restrict);
        }
         public DbSet <User> Users {get; set;}
    public DbSet <Project> Projects {get; set;}
    public DbSet <Message> Messages {get; set;}


    }
}
   


