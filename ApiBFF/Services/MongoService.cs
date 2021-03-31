using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiBFF.Dto;
using Newtonsoft.Json;

namespace ApiBFF.Services
{
    public class MongoService
    {
        HttpClient httpClient = new HttpClient();
        IEnumerable<ProdutoDto> lstProduto;
        IEnumerable<ClienteDto> lstCliente;
        public async Task<IEnumerable<ProdutoDto>> GetProdutoAsync()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5003/");

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync("api/Produto");

            if (response.IsSuccessStatusCode)
            {
                var produtoString = await response.Content.ReadAsStringAsync();
                lstProduto = JsonConvert.DeserializeObject<IEnumerable<ProdutoDto>>(produtoString);
            }
            else{
                response.EnsureSuccessStatusCode();
            }
            
            return lstProduto;
        }

        public async Task<IEnumerable<ClienteDto>> GetClienteAsync()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5001/");

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync("api/Cliente");

            if (response.IsSuccessStatusCode)
            {
                var clienteString = await response.Content.ReadAsStringAsync();
                lstCliente = JsonConvert.DeserializeObject<IEnumerable<ClienteDto>>(clienteString);
            }
            else{
                response.EnsureSuccessStatusCode();
            }
            
            return lstCliente;
        }
    }
}