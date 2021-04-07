using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    // DataContext (ou Contexto de Dados): é a representação do banco de dados em memória
    // Serve, de começo, para dizer quais tabelas referenciam as entidades e vice-versa
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Definir qual estrutura de tabelas/objetos
        // DbSet: conjunto de dados de TodoItem
        // Pegue uma tabela do SQLServer, chamada 'Todos', e mapeie para um 'TodoItem'
        public DbSet<TodoItem> Todos { get; set; }

        // 'Construção do modelo'
        // Com mais classes, poderiam ser classes separadas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}
