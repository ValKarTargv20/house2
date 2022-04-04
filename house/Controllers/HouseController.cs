using Data;
using house.ApplicationServices.Services;
using house.Core.Dto;
using house.Core.ServiceInterface;
using house.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace house.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseServices _houseService;


        public HouseController
            (
            HouseDbContext context,
            IHouseServices houseService
            )
        {
            _context = context;
            _houseService = houseService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.House
                .Select(x => new HouseListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    Floors = x.Floors,
                    Rooms = x.Rooms,
                    Restrooms = x.Restrooms,
                    Yard = x.Yard,
                    Price = x.Price,
                    ModifiedAt = x.ModifiedAt,
                    CreatedAt=x.CreatedAt

                });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), house);
        }
        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();
            return View("Edit", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Floors = model.Floors,
                Rooms = model.Rooms,
                Restrooms = model.Restrooms,
                Yard = model.Yard,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt

            };
            var result = await _houseService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.Name = house.Name;
            model.Address = house.Address;
            model.Floors = house.Floors;
            model.Rooms = house.Rooms;
            model.Restrooms = house.Restrooms;
            model.Yard = house.Yard;
            model.Price = house.Price;
            model.ModifiedAt = house.ModifiedAt;
            model.CreatedAt = house.CreatedAt;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Floors = model.Floors,
                Rooms = model.Rooms,
                Restrooms = model.Restrooms,
                Yard = model.Yard,
                Price = model.Price,
                ModifiedAt = model.ModifiedAt,
                CreatedAt = model.CreatedAt
            };
            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), model);
        }
    }
}
