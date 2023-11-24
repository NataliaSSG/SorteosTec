using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TecTrekAPI.Models;


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

		private void splitName(string fullName, out string name, out string lastName) {
            string[] split = fullName.Split(' ');
            name = split[0];
            lastName = split[1];
    	}
	}
}


