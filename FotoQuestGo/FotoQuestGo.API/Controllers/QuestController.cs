using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
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
        public IActionResult Post([FromBody] QuestAddViewModel questVM)
        {
            var quest = Mapper.Map<Quest>(questVM);
            quest = _unitOfWork.QuestRepository.Add(quest);

            //foreach (var file in files)
            //{
            //    var stream = file.OpenReadStream();
            //    var name = file.FileName;

            //    //TODO: Save each file and corresponding metadata in DB
            //}

            _unitOfWork.Save();
            return new OkObjectResult(quest);
        }
    }
}