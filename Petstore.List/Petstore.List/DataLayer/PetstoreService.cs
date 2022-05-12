using Petstore.List.Model;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;

namespace Petstore.List.DataLayer
{
    public class PetstoreService : IPetstoreService
    {
        public List<Pet> GetAvailablePets()
        {
            var request = new RestRequest(
                resource: "https://petstore.swagger.io/v2/pet/findByStatus?status=available",
                method: Method.Get);
            RestClient restClient = new();
            RestResponse response = restClient.ExecuteAsync(request).Result;
            if (response.IsSuccessful)
            {
                return JsonSerializer.Deserialize<List<Pet>>(response.Content);
            }

            return new List<Pet>();
        }
    }
}
