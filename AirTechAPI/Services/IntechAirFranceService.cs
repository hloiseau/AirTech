using AirTechAPI.Server.Models_IntechAirFrance;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AirTechAPI.Server.Services
{
    public class IntechAirFranceService
    {
        private HttpClient _http;

        private const string _endpoint = "https://intech-airfrance-api.herokuapp.com";
        public IntechAirFranceService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Airport>> GetAirportsAsync() 
        {
           return await _http.GetFromJsonAsync<List<Airport>>($"{_endpoint}/aeroport");
        }
        public async Task<List<Travel>> GetTravelsAsync()
        {
            return await _http.GetFromJsonAsync<List<Travel>>($"{_endpoint}/vol");
        }
        public async Task<List<Models_IntechAirFrance.Client>> GetClientsAsync()
        {
            return await _http.GetFromJsonAsync<List<Models_IntechAirFrance.Client>>($"{_endpoint}/client");
        }
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _http.GetFromJsonAsync<List<Order>>($"{_endpoint}/commande");
        }
        public async Task<List<Billet>> GetBilletsAsync()
        {
            return await _http.GetFromJsonAsync<List<Billet>>($"{_endpoint}/billet");
        }
        public async Task<List<Voyager>> GetVoyagersAsync()
        {
            return await _http.GetFromJsonAsync<List<Voyager>>($"{_endpoint}/passager");
        }

    }
}
