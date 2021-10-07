using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommanderRepository _commandRepository = new CommanderRepository();

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands() 
        {
            var commandItems = _commandRepository.GetAppCommands();
            return Ok(commandItems);
        }

        //GET api/command/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id) 
        {
            var commandItem = _commandRepository.GetCommandById(id);
            return Ok(commandItem);
        }


    }
}
