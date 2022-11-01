using Newtonsoft.Json;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper_Api
{
    public class ModelHelper
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public ModelHelper(HttpClient client, string url)
        {
            _client = new HttpClient();
            _url = url;
        }


        public async Task<string>InsertReg(RegionDTO regionDTO)
        {
            var json = JsonConvert.SerializeObject(regionDTO);
            var data = new StringContent(json,Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_url,data);
            return response.ReasonPhrase;
        }

        

        public async Task<string>UpdateReg(int id,RegionDTO regionDTO)
        {
            var json = JsonConvert.SerializeObject(regionDTO);
            var data = new StringContent(json, encoding: Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync(_url + "/" + id.ToString(), data);
            return responce?.ReasonPhrase;
        }

        public async Task<string>DeleteReg(int id)
        {
            var responce = await _client.DeleteAsync(_url + "/" + id.ToString());
            return responce.ReasonPhrase;
        }



        public async Task<List<Countrys>> GetAll()
        {
           var responce = await _client.GetAsync(_url);
            if (responce.IsSuccessStatusCode)
            {
                var copy = await responce.Content.ReadAsStringAsync();
                var Data = JsonConvert.DeserializeObject<List<Countrys>>(copy);
                return Data;
            }
            else return null;
        }


        public async Task<string> Insert(CountryDTO countryDTO)
        {
            var json =  JsonConvert.SerializeObject(countryDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responce = await _client.PostAsync(_url, data);
            return responce.ReasonPhrase;
        }


        public async Task<string> Delete(int id)
        {
            var response = await _client.DeleteAsync(_url+"/"+id.ToString());
            return response.ReasonPhrase;
        }


        public async Task<string> Update(int id, CountryDTO countryDTO)
        {
            var json = JsonConvert.SerializeObject(countryDTO);
            var data = new StringContent(json,encoding: Encoding.UTF8, "application/json");
            var responce = await _client.PutAsync(_url + "/" + id.ToString(),data);
            return responce?.ReasonPhrase;
        }



        
    }
}
