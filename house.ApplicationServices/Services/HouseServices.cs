using Data;
using house.Core.Domain;
using house.Core.Dto;
using house.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
            HouseDbContext context

            )
        {
            _context = context;

        }
        public async Task<House> Delete(Guid id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }
        public async Task<House> Add(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.Name = dto.Name;
            house.Address = dto.Address;
            house.Floors = dto.Floors;
            house.Rooms = dto.Rooms;
            house.Restrooms = dto.Restrooms;
            house.Yard = dto.Yard;
            house.Price = dto.Price;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<House> Update(HouseDto dto)
        {
            House house = new House();

            house.Id = dto.Id;
            house.Name = dto.Name;
            house.Address = dto.Address;
            house.Floors = dto.Floors;
            house.Rooms = dto.Rooms;
            house.Restrooms = dto.Restrooms;
            house.Yard = dto.Yard;
            house.Price = dto.Price;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = dto.CreatedAt;

            _context.House.Update(house);
            await _context.SaveChangesAsync();

            return house;
        }

    }
}
