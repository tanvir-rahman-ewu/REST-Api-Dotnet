using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command>()
            {
                new Command { Id = 10, HowTo = "amnei", Line = "sdad", Platform = "C++"},
                new Command { Id = 11, HowTo = "amnei", Line = "sdad", Platform = "C++"},
                new Command { Id = 13, HowTo = "amnei", Line = "sdad", Platform = "C++"}
            };
        }

        public Command GetCommandById(int id)
        {
            return new Command{ Id = 10, HowTo = "amnei", Line = "sdad", Platform = "C++"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}