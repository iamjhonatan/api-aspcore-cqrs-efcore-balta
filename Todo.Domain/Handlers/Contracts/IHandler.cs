using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    // Esse Handler irá gerenciar um ou mais comandos
    // Essa interface sempre pode chamar 'IHandler' de 'T', desde que esse 'T' seja um 'ICommand'
    // Ou seja, qualquer comando 'T' que for manipulado pelo 'Handler' deve, obrigatoriamente, implementar o 'ICommand' (contrato)
    public interface IHandler<T> where T : ICommand
    {
        // O comando que será executado pelo 'Handle' é sempre do tipo 'T', e o retorno sempre será um 'ICommandResult'
        ICommandResult Handle(T command);
    }
}
