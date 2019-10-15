using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace trippin
{
    class Tripin
    {
        private static HttpClient HttpClient = new HttpClient() { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(50dnm0lctywymvdizirflwcg))/") };
        public Tripin()
        {
        }
        public async Task<TrippinJsonFileUser[]> ReadFile()
        {
            var input = await System.IO.File.ReadAllTextAsync("users.json");
            return JsonSerializer.Deserialize<TrippinJsonFileUser[]>(input);
        }
        public async Task CheckUsers()
        {
            var input = await ReadFile();
            foreach (TrippinJsonFileUser user in input)
            {
                var exists = await HttpClient.GetAsync("People('" + user.UserName + "')");
                Console.WriteLine("reveived " + exists.StatusCode);
                if (!exists.IsSuccessStatusCode)
                {
                    Console.WriteLine("adding non existing " + user.UserName);
                    var postUser = new UserDTO
                    {
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Emails = new List<string> { user.Email },
                        AddressInfo = new List<UserDTO.AdressInfo> {
                            new UserDTO.AdressInfo
                            {
                                Address = user.Address,
                                City = new UserDTO.City
                                {
                                    Name = user.CityName,
                                    CountryRegion = user.Country,
                                    Region = user.Country
                                }

                            }
                        }
                    };

                    var content = new StringContent(JsonSerializer.Serialize(postUser), Encoding.UTF8, "application/json");
                    var response = await HttpClient.PostAsync("People", content);

                    try
                    {
                        response.EnsureSuccessStatusCode();
                        Console.WriteLine(response.StatusCode);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

        }

    }

}
