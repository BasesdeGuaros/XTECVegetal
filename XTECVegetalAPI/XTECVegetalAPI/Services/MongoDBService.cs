using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XTECVegetalAPI.Models;

namespace XTECVegetalAPI.Services
{
    public class MongoDBService
    {
        private IMongoCollection<EstudianteModel> EstudianteCollection { get; }
        private IMongoCollection<ProfesorModel> ProfesorCollection { get; }

        //ESTUDIANTES GET
        public MongoDBService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatase = mongoClient.GetDatabase(databaseName);

            EstudianteCollection = mongoDatase.GetCollection<EstudianteModel>(collectionName);
        }

        //ESTUDIANTES POST
        public async Task InsertEstudiante(EstudianteModel estudiante) => await EstudianteCollection.InsertOneAsync(estudiante);

        public async Task<List<EstudianteModel>> GetAllEstudiantes()
        {
            var estudiantes = new List<EstudianteModel>();
            var allDocuments = await EstudianteCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => estudiantes.Add(doc));

            return estudiantes;
        }





        //PROFES GET
        public MongoDBService(string databaseName, string collectionName, string databaseUrl, string p)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatase = mongoClient.GetDatabase(databaseName);

            ProfesorCollection = mongoDatase.GetCollection<ProfesorModel>(collectionName);
        }

        //PROFES POST
        public async Task InsertProfe(ProfesorModel profe) => await ProfesorCollection.InsertOneAsync(profe);

        public async Task<List<ProfesorModel>> GetAllProfes()
        {
            var profes = new List<ProfesorModel>();
            var allDocuments = await ProfesorCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => profes.Add(doc));

            return profes;
        }
    }
}
