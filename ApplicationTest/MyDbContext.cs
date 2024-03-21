

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
                .HasOne(d => d.Model) // У каждого измерения (Dimension) есть одна модель (Model)
                .WithMany(m => m.Dimensions) // У каждой модели (Model) может быть много измерений (Dimensions)
                .HasForeignKey(d => d.ModelID); // Внешний ключ в таблице Dimension, указывающий на ID модели

            // Определение связи между таблицей Key и Model:
            modelBuilder.Entity<Key>()
                .HasOne(k => k.Model) // У каждого ключа (Key) есть одна модель (Model)
                .WithMany(m => m.Keys) // У каждой модели (Model) может быть много ключей (Keys)
                .HasForeignKey(k => k.ModelID); // Внешний ключ в таблице Key, указывающий на ID модели

            // Определение связи между таблицей Value и Model:
            modelBuilder.Entity<Value>()
                .HasOne(v => v.Model) // У каждого значения (Value) есть одна модель (Model)
                .WithMany(m => m.Values) // У каждой модели (Model) может быть много значений (Values)
                .HasForeignKey(v => v.ModelID); // Внешний ключ в таблице Value, указывающий на ID модели

            // Определение связи между таблицей Index и Model:
            modelBuilder.Entity<Index>()
                .HasOne(i => i.Model) // У каждого индекса (Index) есть одна модель (Model)
                .WithMany(m => m.Indices) // У каждой модели (Model) может быть много индексов (Indexes)
                .HasForeignKey(i => i.ModelID); // Внешний ключ в таблице Index, указывающий на ID модели

            // Определение связи между таблицей Calculation и Model:
            modelBuilder.Entity<Calculation>()
                .HasOne(c => c.Model) // У каждого вычисления (Calculation) есть одна модель (Model)
                .WithMany(m => m.Calculations) // У каждой модели (Model) может быть много вычислений (Calculations)
                .HasForeignKey(c => c.ModelID); // Внешний ключ в таблице Calculation, указывающий на ID модели

            // Определение связи между таблицей ParametrValues и Task:
            modelBuilder.Entity<ParametrValues>()
                .HasOne(pv => pv.Task) // У каждого значения параметра (ParametrValues) есть одна задача (Task)
                .WithMany(t => t.ParametrValues) // У каждой задачи (Task) может быть много значений параметров (ParametrValues)
                .HasForeignKey(pv => pv.TaskID); // Внешний ключ в таблице ParametrValues, указывающий на ID задачи

            // Определение связи между таблицей ParametrValues и Dimension:
            modelBuilder.Entity<ParametrValues>()
                .HasOne(pv => pv.Dimension) // У каждого значения параметра (ParametrValues) есть одно измерение (Dimension)
                .WithMany(d => d.ParametrValues) // У каждого измерения (Dimension) может быть много значений параметров (ParametrValues)
                .HasForeignKey(pv => pv.DimensionID); // Внешний ключ в таблице ParametrValues, указывающий на ID измерения

            // Определение связи между таблицей Key и Dimension:
            modelBuilder.Entity<Key>()
                .HasOne(k => k.Dimension) // У каждого ключа (Key) есть одно измерение (Dimension)
                .WithMany(d => d.Keys) // У каждого измерения (Dimension) может быть много ключей (Keys)
                .HasForeignKey(k => k.DimensionID); // Внешний ключ в таблице Key, указывающий на ID измерения
        }
    }
}
