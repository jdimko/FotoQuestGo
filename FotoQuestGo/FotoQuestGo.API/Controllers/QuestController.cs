using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FotoQuestGo.API.Models;
using FotoQuestGo.API.UnitOfWork;
using FotoQuestGo.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FotoQuestGo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var quests = _unitOfWork.QuestRepository.GetAll().ToList();
            return new OkObjectResult(quests);
        }

        [HttpPost]
        public IActionResult Post([FromBody] QuestAddViewModel quest)
        {
            //quest = _unitOfWork.QuestRepository.Add(quest);
            //return new OkObjectResult(quest);

            return Ok();
        }
    }
}