using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Models
{
    public interface IUnit
    {
        public string Symbol { get; set; }
        public string Description { get; set; }
    }
}
