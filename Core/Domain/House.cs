using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace house.Core.Domain
{
    public class House
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }
        public int Rooms { get; set; }
        public int Restrooms { get; set; }
        public double Yard { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
