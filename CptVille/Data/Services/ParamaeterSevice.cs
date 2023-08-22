using CptVille.Models;
using System.Reflection.Metadata;

namespace CptVille.Data.Services
{

    public class ParamaeterSevice
    {
        private readonly VilleContext _villeContext;
        public ParamaeterSevice(VilleContext villeContext)
        {
            _villeContext = villeContext;
        }
        public async Task<List<Models.Parameters>> GetAllParametes()
        {
            var paramss = _villeContext.Parameters.ToList();
            return await Task.FromResult(paramss);
        }
        public async Task<Parameters> GetParameterById(int id)
        {
            var param = _villeContext.Parameters.Find(id);
            return await Task.FromResult(param);
        }
        public async Task<Parameters> GetParameterByKey(string key)
        {
            var param = _villeContext.Parameters.Where(p => p.Key == key).FirstOrDefault();
            return await Task.FromResult(param);
        }
        public async Task<Parameters> UpdateParameter(int id, Parameters parameters)
        {
            var paramToUpdate = await GetParameterById(id);
            paramToUpdate.Value = parameters.Value;
            _villeContext.SaveChanges();
            return await Task.FromResult(paramToUpdate);
        }

    }
}
