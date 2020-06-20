using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        ///put URL : api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateeDto commandUpdateDto)
        {
            var commandModelFromRepo = _reposiotry.GetCommandById(id);

            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _reposiotry.UpdateCommand(commandModelFromRepo);

            _reposiotry.SaveChanges();

            return NoContent();
        }

        /// patch URL : api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateeDto> pathcDto)
        {
            var commandModelFromRepo = _reposiotry.GetCommandById(id);
            
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateeDto>(commandModelFromRepo);

            pathcDto.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _reposiotry.UpdateCommand(commandModelFromRepo);

            _reposiotry.SaveChanges();

            return NoContent();
        }

        ///Delete URL : api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _reposiotry.GetCommandById(id);
            
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _reposiotry.DeleteCommand(commandModelFromRepo);
            _reposiotry.SaveChanges();

            return NoContent();
        }
    }
}