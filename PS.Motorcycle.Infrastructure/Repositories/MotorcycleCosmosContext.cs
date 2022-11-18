using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using PS.Motorcycle.Infrastructure.CosmosDB.Interfaces;

namespace PS.Motorcycle.Infrastructure.CosmosDB.Repositories
{
    internal class MotorcycleCosmosContext : IMotorcycleCosmosContext
{
        private readonly IConfiguration _config;
        public Container MotorcycleContainer { get; }

        public MotorcycleCosmosContext(IConfiguration config)
        {
            this._config = config;

            string cosmos_enpoint = this._config["AzureCosmosDBEndpoint"];
            string cosmos_key = this._config["AzureCosmosDBAccessKey"];

            string databaseName = this._config["DatabaseName"];
            string containerName = this._config["ContainerName"];

            CosmosClient client = new CosmosClient(cosmos_enpoint, cosmos_key);

            this.MotorcycleContainer = client.GetContainer(databaseName, containerName);
        }
    }
}
