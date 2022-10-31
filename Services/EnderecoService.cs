using Newtonsoft.Json;
using System;
using ViaCepApi.Entities;

namespace ViaCepApi.Services
{
    public class EnderecoService
    {
        public static async Task<Endereco> Integracao(string cep)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(jsonString);

                Endereco? endereco = JsonConvert.DeserializeObject<Endereco>(jsonString);


                if (endereco != null)
                {
                    return endereco;
                }
                else
                {
                    return new Endereco();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }

}
