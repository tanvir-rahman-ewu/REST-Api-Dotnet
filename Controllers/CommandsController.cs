using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")] ///base route of the api
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _reposiotry;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper ) /// Dependency injection Via constructor
        {
            _reposiotry = repository;
            _mapper = mapper;
        }
        ///get URL: api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllcommands()
        {
            var commandItems = _reposiotry.GetAllCommands();

            return Ok(commandItems);
        }
        
        ///get URL: api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _reposiotry.GetCommandById(id);

            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            else
            {
                return NotFound();
            }
        }
        ///post URL : api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _reposiotry.CreateCommand(commandModel);
            _reposiotry.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id}, commandReadDto);
            //return Ok(commandReadDto);
        }
    }
}