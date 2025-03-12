////////////////////////////////////////////////////////////////////////////////////////
using todolist.Models;
////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.EntityFrameworkCore;
////////////////////////////////////////////////////////////////////////////////////////
namespace todolist.Data;
////////////////////////////////////////////////////////////////////////////////////////
public class TodolistContext: DbContext {
    public DbSet <Operation> Operations { get; set; }
    public DbSet <Mission> Missions { get; set; }
    public DbSet <Assignment> Assignments { get; set; }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder ){
        optionsBuilder.UseSqlite( $"Data source=db/todolist.db" );
    }
    protected override void OnModelCreating( ModelBuilder modelBuilder ){
        modelBuilder.Entity <Operation> ()
            .Property( o => o.Codename )
            .IsRequired();

        modelBuilder.Entity <Mission> ()
            .HasOne( m => m.Operation )
            .WithMany( o => o.Missions )
            .HasForeignKey( m => m.OperationId );

        modelBuilder.Entity <Mission> ()
            .Property( m => m.IntelReport )
            .IsRequired();   

        modelBuilder.Entity <Assignment> ()
            .HasOne( a => a.Mission )
            .WithMany( m => m.Assignments )
            .HasForeignKey( a => a.MissionId );

        modelBuilder.Entity <Assignment> ()
            .Property( a => a.Objectives )
            .IsRequired();
    }
}
////////////////////////////////////////////////////////////////////////////////////////
