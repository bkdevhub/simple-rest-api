using LiteDB;
using src.Application.Common.Exceptions;
using src.Application.Common.Repositories;
using src.Domain;

namespace src.Infrastructure.LiteDb;

public class CommandLiteDbRepository : ICommandRepository
{
    private readonly string _fileBasePath = AppContext.BaseDirectory;
    private readonly ILiteCollection<Command> _col;
    
    public CommandLiteDbRepository(ILiteDatabase db)
    {
        _col = db.GetCollection<Command>("Commands");
        _col.EnsureIndex(x => x.SystemName);
    }
    
    public Task<Command> Create(Command command)
    {
        _col.Insert(command);
        return Task.FromResult(command);
    }
    
    public Task<IEnumerable<Command>> GetAll()
    {
        IEnumerable<Command> list = _col.FindAll();
        
        return Task.FromResult(list);
    }

    public Task<Command?> GetById(string id)
    {
        var cmd = _col.FindById(id);
        
        return Task.FromResult(cmd);
    }
    
    public Task<Command> Update(Command command)
    {
       var updated = _col.Update(command);

       if (!updated)
       {
           throw new UpdateException($"error while updating id: '{command.Id}'.");    
       }
       
       return Task.FromResult(command);
    }

    public Task<bool> Delete(string id)
    {
        return Task.FromResult(_col.Delete(id));
    }
}