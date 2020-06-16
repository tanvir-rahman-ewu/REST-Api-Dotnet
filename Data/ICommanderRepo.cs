using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    ///interface of get put post delete method
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands(); ///for getting all commands
        Command GetCommandById(int id); /// for getting one command selected by Id
   }
}