using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Interfaces
{
    public interface ICosmosDbContainer
    {
        /// <summary>
        ///     Azure Cosmos DB Container
        /// </summary>
        Container _container { get; }
    }
}
