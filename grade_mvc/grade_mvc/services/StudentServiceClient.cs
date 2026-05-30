using grade_mvc.Models;
using System.Text.Json;

namespace grade_mvc.services
{
    public class StudentsServiceClient
    {
        private readonly HttpClient _httpClient;

        public StudentsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            try
            {
                var response = await _httpClient.GetAsync("/Student/GetAll");
                if (!response.IsSuccessStatusCode)
                    return new List<Student>();

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<List<Student>>(
         json,
         new JsonSerializerOptions
         {
             PropertyNameCaseInsensitive = true
         }
     ) ?? new List<Student>();
            }
            catch
            {
                return new List<Student>();
            }
           
        }

        public async Task<Student?> GetStudentById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/Student/GetById/{id}");

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<Student>(
         json,
         new JsonSerializerOptions
         {
             PropertyNameCaseInsensitive = true
         }
           ) ?? null;
            }
            catch
            {
                return null;
            }
        }
    }
}
