using src.Domain;

namespace src.Application.Common.Repositories;

public interface ICommandRepository
{
    Task<Command> Create(Command command);
    Task<IEnumerable<Command>> GetAll();
    Task<Command?> GetById(string id);
    Task<Command> Update(Command command);
    Task<bool> Delete(string id);
} 