using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _reposiotry;
        public CommandsController(ICommanderRepo repository)
        {
            _reposiotry = repository;
        }
        ///get URL: api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllcommands()
        {
            var commandItems = _reposiotry.GetAppCommands();

            return Ok(commandItems);
        }
        
        ///get URL: api/commands/5
        [HttpGet("{id}")]
        public ActionResult GetCommandById(int id)
        {
            var commandItem = _reposiotry.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}