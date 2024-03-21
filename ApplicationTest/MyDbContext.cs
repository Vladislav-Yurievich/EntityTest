

using Microsoft.EntityFrameworkCore;

namespace ApplicationTest.Models
{
    class MyDbContext : DbContext
    {
        public MyDbContext()
        {
          /*  Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5432; database=postgres;username=postgres;password=12345;");
        }

        public DbSet<Model> Models { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<Key> Keys { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<Index> Indices { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<ParametrValues> ParametrValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение связи между таблицей Task и Model: 
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Model) // У каждой задачи (Task) есть одна модель (Model)
                .WithMany(m => m.Tasks) // У каждой модели (Model) может быть много задач (Tasks)
                .HasForeignKey(t => t.ModelID); // Внешний ключ в таблице Task, указывающий на ID модели

            // Определение связи между таблицей Dimension и Model:
            modelBuilder.Entity<Dimension>()
                .HasOne(d => d.Model) 
                .WithMany(m => m.Dimensions) 
                .HasForeignKey(d => d.ModelID); 

            // Определение связи между таблицей Key и Model:
            modelBuilder.Entity<Key>()
                .HasOne(k => k.Model)
                .WithMany(m => m.Keys) 
                .HasForeignKey(k => k.ModelID); 

            // Определение связи между таблицей Value и Model:
            modelBuilder.Entity<Value>()
                .HasOne(v => v.Model) 
                .WithMany(m => m.Values) 
                .HasForeignKey(v => v.ModelID); 

            // Определение связи между таблицей Index и Model:
            modelBuilder.Entity<Index>()
                .HasOne(i => i.Model) 
                .WithMany(m => m.Indices) 
                .HasForeignKey(i => i.ModelID);

            // Определение связи между таблицей Calculation и Model:
            modelBuilder.Entity<Calculation>()
                .HasOne(c => c.Model) 
                .WithMany(m => m.Calculations) 
                .HasForeignKey(c => c.ModelID); 

            // Определение связи между таблицей ParametrValues и Task:
            modelBuilder.Entity<ParametrValues>()
                .HasOne(pv => pv.Task) 
                .WithMany(t => t.ParametrValues) 
                .HasForeignKey(pv => pv.TaskID); 

            // Определение связи между таблицей ParametrValues и Dimension:
            modelBuilder.Entity<ParametrValues>()
                .HasOne(pv => pv.Dimension) 
                .WithMany(d => d.ParametrValues)
                .HasForeignKey(pv => pv.DimensionID); 

            // Определение связи между таблицей Key и Dimension:
            modelBuilder.Entity<Key>()
                .HasOne(k => k.Dimension)
                .WithMany(d => d.Keys) 
                .HasForeignKey(k => k.DimensionID); 
        }
    }
}
