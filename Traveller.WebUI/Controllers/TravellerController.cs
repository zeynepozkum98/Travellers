using Microsoft.AspNetCore.Mvc;
using Travellers.Business.Abstract;
using Travellers.Entities.Concrete.Dtos;

namespace Traveller.WebUI.Controllers
{
    public class TravellerController : Controller
    {
        private readonly IContactService _contactService;
        private readonly ITourService _tourService;
        public TravellerController(IContactService contactService,ITourService tourService)
        {
			_contactService = contactService;
            _tourService = tourService;
		}
        
     
        public async Task<IActionResult> Index(int id)
        {
            List<TourDto> tourDtos = await _tourService.GetAllTourAsync();
            var tourDto= tourDtos.Where(x=>x.Id == id);

            if (tourDto==null)
            {
                return View("TourError");
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
       public IActionResult Contact()
       {
            return View();
       }

       [HttpPost]

        public async Task<IActionResult> Contact(ContactDto contactDto)
        {
            bool isTrue= await _contactService.AddContactAsync(contactDto);
            return isTrue ? RedirectToAction("Index", "Traveller") : View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ContactDto contactDto= await _contactService.GetContactAsync(id);
            return View(contactDto);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ContactDto contactDto)
        {
            bool isTrue= await _contactService.UpdateContactAsync(contactDto);
            return isTrue ? RedirectToAction("Index", "Traveller") : View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool isTrue = await _contactService.DeleteContactAsync((await _contactService.GetContactAsync(id)));
            return isTrue ? RedirectToAction("Index", "Traveller") : View();
        }


    }
}
