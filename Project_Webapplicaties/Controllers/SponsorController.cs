using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Data.UnitOfWork.Interfaces;
using Project_Webapplicaties.ViewModels;

namespace Project_Webapplicaties.Controllers
{
    public class SponsorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SponsorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            SponsorListViewModel vm = new SponsorListViewModel();
            vm.Sponsors = _unitOfWork.SponsorRepository.GetAll().ToList();
            return View(vm);
        }
    }
}
