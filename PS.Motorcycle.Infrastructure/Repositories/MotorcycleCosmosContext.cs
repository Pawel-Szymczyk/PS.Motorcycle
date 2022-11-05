using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using PS.Motorcycle.Domain.Models;
using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Repositories
{
    internal class MotorcycleCosmosContext : IMotorcycleCosmosContext
    {

        public Container MotorcycleContainer { get; }

        //private readonly DatabaseConfig _config;

        //public MotorcycleCosmosContext(IOptions<DatabaseConfig> config)
        public MotorcycleCosmosContext()
        {
            //this._config = config.Value;
            ////string cosmos_enpoint = builder.Configuration["environmentVariables:COSMOS_ENDPOINT"];
            ////string cosmos_key = builder.Configuration["environmentVariables:COSMOS_KEY"];

            //string cosmos_enpoint = this._config.COSMOS_ENDPOINT;
            //string cosmos_key = this._config.COSMOS_KEY;

            string cosmos_enpoint = "";
            string cosmos_key = "";


            string databaseName = "PS.MotorcycleDB";
            string containerName = "Motorcycle";

            // New instance of CosmosClient class
            //using CosmosClient client = new(
            //    accountEndpoint: cosmos_enpoint,
            //    authKeyOrResourceToken: cosmos_key
            //);

            CosmosClient client = new CosmosClient(cosmos_enpoint, cosmos_key);

            this.MotorcycleContainer = client.GetContainer(databaseName, containerName);
        }
    }
}
