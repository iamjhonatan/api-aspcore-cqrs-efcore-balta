using System;
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoQueries
    {
        // Query que obtém todas as tarefas de um determinado usuário
        public static Expression<Func<TodoItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        // além do usuário, retorna as tarefas completas
        public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done;
        }

        public static Expression<Func<TodoItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        // retornando todas as tarefas desse usuário, concluídas ou não, de um período
        public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x =>
                x.User == user &&
                x.Done == done &&
                x.Date.Date == date.Date;
        }

    }
}
