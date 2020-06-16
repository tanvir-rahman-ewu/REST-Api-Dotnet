using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
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
    }
}