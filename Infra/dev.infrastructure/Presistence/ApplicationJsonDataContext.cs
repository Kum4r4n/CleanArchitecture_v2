
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dev.Infrastructure.Presistence
{
    public class ApplicationJsonDataContext<T> where T : class
    {
        private readonly string _dataFilePath;

        public ApplicationJsonDataContext() {

            string apiProjectDirectory = Directory.GetCurrentDirectory();
            string infrastructureProjectDirectory = Path.Combine(apiProjectDirectory, "../../","Infra", "dev.Infrastructure");
            _dataFilePath = Path.Combine(infrastructureProjectDirectory, "Presistence", "Files", "Application.json");

        }

        public async Task Add(T entity)
        {
            var data = await ReadDataFromFileAsync();
            var listData = data.ToList();
            listData.Add(entity);
            await WriteDataToFileAsync(listData);
        }

        public async Task<List<T>> GetAll()
        {
            var data = await ReadDataFromFileAsync();
            return data ;
        }


        private async Task<List<T>> ReadDataFromFileAsync()
        {
            try
            {
                using (var streamReader = new StreamReader(_dataFilePath))
                {
                    var jsonContent = await streamReader.ReadToEndAsync();
                    return JsonSerializer.Deserialize<List<T>>(jsonContent);
                }
            }
            catch (FileNotFoundException)
            {
                return new List<T>();
            }
        }

        private async Task WriteDataToFileAsync(List<T> entity)
        {
            var jsonContent = JsonSerializer.Serialize(entity, new JsonSerializerOptions
            {
                WriteIndented = true, // Pretty-print JSON
            });

            using (var streamWriter = new StreamWriter(_dataFilePath))
            {
                await streamWriter.WriteAsync(jsonContent);
            }
        }

        private int GetNextId(List<T> entities, Func<T, int> getIdFunc)
        {
            return entities.Count > 0 ? entities.Max(getIdFunc) + 1 : 1;
        }
    }
}
