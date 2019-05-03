using HotelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelStaffApp.Web_Service
{
    public class StaffRestService
    {
        HttpClient Client;

        private static StaffRestService instance;

        public static StaffRestService Instance
        {
            get
            {
                if (instance == null)
                    instance = new StaffRestService();
                return instance;
            }
        }

        private StaffRestService()
        {
            Client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<Staff> GetStaffMember(string email, string password)
        {
            string loginURI = URIString.WEBAPIURI + "staff";

            var URI = new Uri(loginURI);
            UserDetailsAPIModel model = new UserDetailsAPIModel
            {
                Email = email,
                Password = password
            };
            var param = JsonConvert.SerializeObject(model);

            var content = new StringContent(param, Encoding.UTF8, "application/json");
            try
            {
                var response = await Client.PostAsync(URI, content);
                var jsonstring = await response.Content.ReadAsStringAsync();
                jsonstring = jsonstring.Replace("\\", string.Empty);
                jsonstring = jsonstring.Trim('"');
                return JsonConvert.DeserializeObject<Staff>(jsonstring);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
