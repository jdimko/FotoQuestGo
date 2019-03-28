using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FotoQuestGo.API.Quest.UnitOfWork;
using FotoQuestGo.API.Quest.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FotoQuestGo.API.Quest.Quest.Controllers
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
        [Route("/api/[controller]/GetAll")]
        public IActionResult GetAll()
        {
            var quests = _unitOfWork.QuestRepository.GetAll().ToList();
            return new OkObjectResult(quests);
        }

        [HttpPost]
        [Route("/api/[controller]/Create")]
        public IActionResult Create([FromForm] QuestAddViewModel questVM)
        {
            var quest = Mapper.Map<Common.Models.Quest>(questVM);
            quest = _unitOfWork.QuestRepository.Add(quest);
            _unitOfWork.Save();
            return new OkObjectResult(quest);
        }
    }
}