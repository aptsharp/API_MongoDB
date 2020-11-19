using Microsoft.Extensions.Configuration;
using MongoDB.API.Data.Collections;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.API.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; }

        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["NomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("It was not possible to connect to MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infectado)))
            {
                BsonClassMap.RegisterClassMap<Infectado>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
