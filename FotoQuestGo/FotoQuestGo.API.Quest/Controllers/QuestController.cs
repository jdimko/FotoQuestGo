using AutoMapper;
using FotoQuestGo.API.Quest.UnitOfWork;
using FotoQuestGo.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FotoQuestGo.API.Quest.Quest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            var quest = _mapper.Map<Common.Models.Quest>(questVM);
            quest = _unitOfWork.QuestRepository.Add(quest);
            _unitOfWork.Save();
            return new OkObjectResult(quest);
        }
    }
}