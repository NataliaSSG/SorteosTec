using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TecTrekAPI.Controllers;
using TecTrekAPI.Models;
using TecTrekAPI.Services;


namespace SorteosTec.Pages.Models
{
	public class ApiClient
	{
		private readonly HttpClient _httpClient = new HttpClient();

		public async Task CreateClienteAndAddress(string fullName, string gender, string username, string password, DateTime dob, string email, string state, string city) {
            string name, lastName;
            int genderInt;

            splitName(fullName, out name, out lastName);

            switch (gender)
                {
                    case "Masculino":
                        genderInt = 0;
                        break;

                    case "Femenino":
                        genderInt = 1;
                        break;

                    case "Otro":
                        genderInt = 2;
                        break;

                    default:
                        throw new Exception("El género seleccionado no es válido");
            }

            var cliente = new ClienteModel { 
                    first_name = name,
                    last_name = lastName,
                    birth_date = dob,
                    sexo = genderInt,
                    email = email,
                    username = username,
                    user_password = password
                };

            var clienteJson = JsonConvert.SerializeObject(cliente);
            var clienteResponse = await _httpClient.PostAsync("https://localhost:7256/Cliente", new StringContent(clienteJson, Encoding.UTF8, "application/json"));
            clienteResponse.EnsureSuccessStatusCode();
            var createdCliente = JsonConvert.DeserializeObject<ClienteModel>(await clienteResponse.Content.ReadAsStringAsync());

            // Create the Address
            var address = new AddressModel {id_client = createdCliente.id_client, state_name = state, city_name = city};
            var addressJson = JsonConvert.SerializeObject(address);
            var addressResponse = await _httpClient.PostAsync("https://localhost:7256/Address", new StringContent(addressJson, Encoding.UTF8, "application/json"));
            addressResponse.EnsureSuccessStatusCode();
            var createdAddress = JsonConvert.DeserializeObject<AddressModel>(await addressResponse.Content.ReadAsStringAsync());
		}

        public async Task<ClienteModel> LogIn(string Identifier, string Password) {
            var credentials = new {
                username = Identifier,
                password = Password
            };

            var credentialsJson = JsonConvert.SerializeObject(credentials);
            var credentialsResponse = await _httpClient.PostAsync("https://localhost:7256/Cliente/login", new StringContent(credentialsJson, Encoding.UTF8, "application/json"));
            credentialsResponse.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<ClienteModel>(await credentialsResponse.Content.ReadAsStringAsync());
        }
        
        public async Task BuyProduct(int idClient, int idProduct) {
            Console.WriteLine("Comprando producto");
            Console.WriteLine(idClient);
            Console.WriteLine(idProduct);
            // Obtener el producto
            var product = await _httpClient.GetAsync("https://localhost:7256/Items/" + idProduct);
            product.EnsureSuccessStatusCode();

            var productJson = await product.Content.ReadAsStringAsync();
            var productModel = JsonConvert.DeserializeObject<ItemsModel>(productJson);

            // Obtener el cliente
            var client = await _httpClient.GetAsync("https://localhost:7256/Cliente/" + idClient);
            client.EnsureSuccessStatusCode();
            var clientJson = await client.Content.ReadAsStringAsync();
            var clientModel = JsonConvert.DeserializeObject<ClienteModel>(clientJson);

            Console.WriteLine(clientModel.first_name);

            if (clientModel.points >= productModel.item_virtual_price) {
                clientModel.points -= productModel.item_virtual_price;
                var clientUpdateJson = JsonConvert.SerializeObject(clientModel);
                var clientUpdateResponse = await _httpClient.PutAsync("https://localhost:7256/Cliente/" + idClient, new StringContent(clientUpdateJson, Encoding.UTF8, "application/json"));
                clientUpdateResponse.EnsureSuccessStatusCode();

                Console.WriteLine(clientModel.points);
                
                var invItem = new UserInventoryModel {id_client = idClient, 
                                                      id_item = idProduct};
                
                var addItem = JsonConvert.SerializeObject(invItem);

                var productUpdateResponse = await _httpClient.PostAsync("https://localhost:7256/UserInventory/", new StringContent(addItem, Encoding.UTF8, "application/json"));
                productUpdateResponse.EnsureSuccessStatusCode();
            }
            else {
                throw new Exception("No tienes suficientes puntos para comprar este producto");
            }
        }
        // Helpers
		private void splitName(string fullName, out string name, out string lastName) {
            string[] split = fullName.Split(' ');
            name = split[0];
            lastName = split[1];
    	}
	}
}


