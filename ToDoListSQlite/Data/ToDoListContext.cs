using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data;

public partial class ToDoListContext : DbContext
{
    public ToDoListContext(DbContextOptions<ToDoListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ToDoListModel> ToDoLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDoListModel>(entity =>
        {
            entity.ToTable("ToDoList");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
