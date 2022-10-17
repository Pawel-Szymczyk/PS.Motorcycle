using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Interfaces
{
    public interface IMotorcycleCosmosContext
    {
        Container MotorcycleContainer { get; }
    }
}
