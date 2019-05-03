using HotelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelStaffApp.Web_Service
{
    public class HotelRestService
    {
        HttpClient Client;
        private static HotelRestService instance;

        public static HotelRestService Instance
        {
            get
            {
                if (instance == null)
                    instance = new HotelRestService();
                return instance;
            }
        }

        private HotelRestService()
        {
            Client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<List<Room>> GetRoomsForHotel(int id)
        {
            //Url = http://192.168.0.24:57162/api/hotel

            string bookingAPIURI = URIString.WEBAPIURI + "Hotel/" + id;
            var uri = new Uri(bookingAPIURI);

            List<Room> rooms = new List<Room>();
            try
            {
                var response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    content = content.Replace("\\", string.Empty);
                    content = content.Trim('"');
                    Hotel h = JsonConvert.DeserializeObject<Hotel>(content);
                    rooms = h.RoomsInHotel;
                }
            }
            catch (Exception ex)
            {
                string meme = ex.ToString();
            }
            return rooms;
        }

        public async void BookDownRoom(string report, int roomID)
        {
            string reportURI = URIString.WEBAPIURI + "Hotel/BookDown";
            var uri = new Uri(reportURI);
            RoomReportWrapper rrw = new RoomReportWrapper
            {
                RoomID = roomID,
                Report = report
            };

            string json = JsonConvert.SerializeObject(rrw);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(reportURI, content);
                if(response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception e)
            {

            }
        }

        public async void SolveProblem(int roomID)
        {
            string reportURI = URIString.WEBAPIURI + "Hotel/Solve/" + roomID;
            var uri = new Uri(reportURI);

            try
            {
                var response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
