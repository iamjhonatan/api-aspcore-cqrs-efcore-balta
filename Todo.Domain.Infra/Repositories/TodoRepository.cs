using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo); // adicionando na memória, mas não salvando
            _context.SaveChanges(); // salvando no banco. as dependencias são gerenciadas pelo asp.netcore, que destrói a memória quando chega ao fim da execução
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            //AsNoTracking: Desabilitando o proxy (versões dos dados em memória). Usar somente quando for retornar algo para tela, sem modificação.
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user)) // query
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context
                .Todos
                .FirstOrDefault(x => x.Id == id && x.User == user); // posso criar uma query no TodoQueries
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified; 
            _context.SaveChanges();
        }
    }
}
