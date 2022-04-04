using house.Core.Domain;
using house.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house.Core.ServiceInterface
{
    public interface IHouseServices : IApplicationService
    {
        Task<House> Delete(Guid id);
        Task<House> Add(HouseDto dto);
        Task<House> GetAsync(Guid id);
        Task<House> Update(HouseDto dto);
    }
}
