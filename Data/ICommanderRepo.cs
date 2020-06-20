using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    ///interface of get put post delete method
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands(); ///for getting all commands
        Command GetCommandById(int id); /// for getting one command selected by Id
        void CreateCommand(Command cmd); /// posting data

        void UpdateCommand(Command cmd);

        void DeleteCommand(Command cmd);


   }
}