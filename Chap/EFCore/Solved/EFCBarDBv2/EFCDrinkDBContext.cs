﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;

public partial class EFCDrinkDBContext : DbContext
{
    public EFCDrinkDBContext()
    {
    }

    public EFCDrinkDBContext(DbContextOptions<EFCDrinkDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drink> Drinks { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFCDrinkDB;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasOne(d => d.AlcoholicPart)
                .WithMany(p => p.DrinkAlcoholicParts)
                .HasForeignKey(d => d.AlcoholicPartId)
                .HasConstraintName("FK_Drink_Ingredient_Alc");

            entity.HasOne(d => d.NonAlcoholicPart)
                .WithMany(p => p.DrinkNonAlcoholicParts)
                .HasForeignKey(d => d.NonAlcoholicPartId)
                .HasConstraintName("FK_Drink_Ingredient_NonAlc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public Ingredient GetIngredientByName(string name)
    {
        return Ingredients.FirstOrDefault(i => i.Name == name);
    }
}