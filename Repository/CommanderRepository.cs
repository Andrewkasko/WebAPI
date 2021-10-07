using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Interface;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class CommanderRepository : ICommanderRepository
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg1", Line = "Boil water1", Platform = "Kettle1" },
                new Command { Id = 1, HowTo = "Boil an egg2", Line = "Boil water2", Platform = "Kettle2" },
                new Command { Id = 2, HowTo = "Boil an egg3", Line = "Boil water3", Platform = "Kettle3" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle" };
        }
    }
}
