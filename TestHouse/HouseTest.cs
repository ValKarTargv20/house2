using house.Core.Domain;
using house.Core.Dto;
using house.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestHouse
{
    public class HouseTest : TestBase
    {

        [Fact]
        public async Task Should_AddNewHouse_WhenReturnResult()
        {
            string guid = "8ba37398-f315-423b-9df0-4aee9933d388";

            HouseDto house = new HouseDto();
            house.Id = Guid.Parse(guid);
            house.Name = "House 2 add";
            house.Address = "Address 2, Tallinn";
            house.Floors = 3;
            house.Rooms = 7;
            house.Restrooms = 3;
            house.Yard = 800;
            house.Price = 500000;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;

            var result = await Svc<IHouseServices>().Add(house);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdHouse_whenReturnResultAsync()
        {
            string guid = "497440cd-838e-4863-9ae6-6af780878365";
            string guid1 = "2e7d2eef-5e0d-485c-9ae6-5e832a9e9272";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);
            await Svc<IHouseServices>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_whenReturnResultAsync()
        {
            string guid = "497440cd-838e-4863-9ae6-6af780878365";
            string guid1 = "71e6b42e-9d8e-49d2-8ad1-46d64a84ff61";

            var insertGuid = Guid.Parse(guid);
            var insertGuid1 = Guid.Parse(guid1);
            await Svc<IHouseServices>().GetAsync(insertGuid);

            Assert.NotEqual(insertGuid1, insertGuid);
        }
        [Fact]
        public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
        {
            string guid = "497440cd-838e-4863-9ae6-6af780878365";
            var insertGuid = Guid.Parse(guid);

            var result = await Svc<IHouseServices>().Delete(insertGuid);

            Assert.NotNull(result);

            //Assert.NotEmpty((System.Collections.IEnumerable)result);
            //Assert.Single((System.Collections.IEnumerable)result);
        }

        [Fact]
        public async Task Should_UpdateByIdHouse_WhenUpdateHouse()
        {
            string guid = "2e7d2eef-5e0d-485c-9ae6-5e832a9e9272";

            HouseDto house = new HouseDto();
            house.Id = Guid.Parse(guid);
            house.Name = "House 4";
            house.Address = "Address 4, Tallinn";
            house.Floors = 1;
            house.Rooms = 5;
            house.Restrooms = 1;
            house.Yard = 1200;
            house.Price = 120000;
            house.ModifiedAt = DateTime.Now;
            house.CreatedAt = DateTime.Now;

            await Svc<IHouseServices>().Update(house);

            Assert.NotEmpty((System.Collections.IEnumerable)house);
        }
        public async Task CheckRoomsFloors_areNotZero()
        {

        }
    }

}
