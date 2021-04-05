using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    // DataContext (ou Contexto de Dados): é a representação do banco de dados em memória
    // Serve, de começo, para dizer quais tabelas referenciam as entidades e vice-versa
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options)
            : base(options)
        {
        }

        // Definir qual estrutura de tabelas/objetos
        // DbSet: conjunto de dados de TodoItem
        // Pegue uma tabela do SQLServer, chamada 'Todos', e mapeie para um 'TodoItem'
        public DbSet<TodoItem> Todos { get; set; }
    }
}
