using CarParkApp.Models;
using Data.Abstract;
using Data.DataModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CarParkApp.Controllers
{
    public class HomeController : Controller
    {
        private ICarRepository _carRepository;
        public HomeController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        //*********************************
        //******** View Methods ***********
        //*********************************
        public IActionResult Index()
        {
            var model = new CarModel()
            {
                Cars = _carRepository.GetCarsWithModels()
            };
            return View(model);
        }

        public IActionResult ViewCarTypes()
        {
            var model = new CarModel()
            {
                CarTypes = _carRepository.GetAllCarTypes()
            };
            return View(model);
        }


        //*********************************
        //******** Car Methods ************
        //*********************************

        [HttpGet]
        public IActionResult CarCreate()
        {
            ViewBag.CarTypes = _carRepository.GetAllCarTypes();
            return View();
        }

        [HttpPost]
        public IActionResult CarCreate(CreateCarDataModel model, int cTypeId)
        {
            _carRepository.CreateCarWithCarType(model, cTypeId);
            return Json(model, cTypeId);
        }

        public IActionResult ViewPrice(int id)
        {
            var entity = _carRepository.GetById(id);
            System.TimeSpan timeSpan;
            DateTime enterTime;
            DateTime exitTime;
            double price = 0;
            enterTime = entity.EnterTime;
            exitTime = DateTime.Now;
            timeSpan = exitTime - enterTime;


            // Case 1 = Otomobil
            // Case 2 = Minibüs
            // Case 3 = Otobüs
            // Case 4 = Kamyon
            switch (entity.CarTypeId)
            {
                case 1:
                    if (timeSpan.TotalMinutes < 60)
                    {
                        price = 0;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 15;
                    }
                    else if (timeSpan.TotalMinutes >= 120 && timeSpan.TotalMinutes < 180)
                    {
                        price = 25;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 35;
                    }
                    else if (timeSpan.TotalMinutes >= 120)
                    {
                        price = 45;
                    }
                    break;
                case 2:
                    if (timeSpan.TotalMinutes < 60)
                    {
                        price = 0;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 15 * 1.25;
                    }
                    else if (timeSpan.TotalMinutes >= 120 && timeSpan.TotalMinutes < 180)
                    {
                        price = 25 * 1.25;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 35 * 1.25;
                    }
                    else if (timeSpan.TotalMinutes >= 120)
                    {
                        price = 45 * 1.25;
                    }
                    break;
                case 3:
                    if (timeSpan.TotalMinutes < 60)
                    {
                        price = 0;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 15 * 1.35;
                    }
                    else if (timeSpan.TotalMinutes >= 120 && timeSpan.TotalMinutes < 180)
                    {
                        price = 25 * 1.35;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 35 * 1.35;
                    }
                    else if (timeSpan.TotalMinutes >= 120)
                    {
                        price = 45 * 1.35;
                    }
                    break;
                case 4:
                    if (timeSpan.TotalMinutes < 60)
                    {
                        price = 0;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 15 * 1.50;
                    }
                    else if (timeSpan.TotalMinutes >= 120 && timeSpan.TotalMinutes < 180)
                    {
                        price = 25 * 1.50;
                    }
                    else if (timeSpan.TotalMinutes >= 60 && timeSpan.TotalMinutes < 120)
                    {
                        price = 35 * 1.50;
                    }
                    else if (timeSpan.TotalMinutes >= 120)
                    {
                        price = 45 * 1.50;
                    }
                    break;
            }

            //String timeStamp = "40:00:00";
            //var segments = timeStamp.Split(':');

            //TimeSpan t = new TimeSpan(0, Convert.ToInt32(segments[0]),
            //               Convert.ToInt32(segments[1]), Convert.ToInt32(segments[2]));
            //string time = string.Format("{0}:{1}:{2}",
            //           ((int)t.TotalHours), t.Minutes, t.Seconds);

            var model = new PriceModel()
            {
                Plate = entity.Plate,
                timeSpan = Math.Ceiling(timeSpan.TotalHours).ToString(),
                Price = price,
            };
            return PartialView("ViewPrice", model);
        }

        public IActionResult CarDelete(int id)
        {
            var entity = _carRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _carRepository.Delete(entity);
            return RedirectToAction("Index");
        }




        //*********************************
        //******** Car Type Methods ******
        //*********************************
        [HttpGet]
        public IActionResult CarTypeCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CarTypeCreate(CreateCarTypeDataModel model)
        {
            _carRepository.CreateCarType(model);
            return Json(model);
        }


        [HttpGet]
        public IActionResult CarTypeUpdate(int id)
        {
            var entity = _carRepository.GetCarTypeById(id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CreateCarTypeDataModel()
            {
                Id = entity.Id,
                CarTypeName = entity.CarTypeName,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CarTypeUpdate(CreateCarTypeDataModel model)
        {
            var entity = _carRepository.GetCarTypeById(model.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.CarTypeName = model.CarTypeName;
            _carRepository.UpdateCartType(model);
            return Json(model);
        }

        public IActionResult CarTypeDelete(int id)
        {
            _carRepository.DeleteCarTypeById(id);
            return RedirectToAction("ViewCarTypes");
        }













        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}