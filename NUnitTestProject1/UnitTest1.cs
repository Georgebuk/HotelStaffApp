using HotelClassLibrary;
using HotelStaffApp;
using HotelStaffApp.Web_Service;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        static HttpClient Client = new HttpClient();
        static Staff TestStaff;
        [SetUp]
        public void Setup()
        {
            TestStaff = new Staff
            {
                StaffID = 1,
                Location = new Hotel
                {
                    HotelID = 1
                },
                FirstName = "George",
                LastName = "Boulton",
                Username = "gb96",
                Password = "meme"

            };
            string setupURI = URIString.WEBAPIURI + "Setup/setupDB";
            var uri = new Uri(setupURI);
            try
            {
                var response = Client.GetAsync(uri);
            }
            catch (Exception e)
            {

            }
        }

        [Test]
        public async Task MakeRoomAvailableTest()
        {
            HotelRestService service = HotelRestService.Instance;
            service.SolveProblem(2);
            var response = await service.GetRoomsForHotel(TestStaff.Location.HotelID);
            Room testRoom = response[1];
            Assert.AreEqual(true, testRoom.IsAvailable);
        }

        [Test]
        public async Task MarkRoomDownTest()
        {
            HotelRestService service = HotelRestService.Instance;
            service.BookDownRoom("Bad Sink", 1);
            var response = await service.GetRoomsForHotel(TestStaff.Location.HotelID);
            Room testRoom = response[0];
            Assert.AreEqual(false, testRoom.IsAvailable);
        }

        [Test]
        public async Task GetStaffTest()
        {
            //Check for incorrect login attempt
            StaffRestService service = StaffRestService.Instance;
            Staff staff = await service.GetStaffMember(TestStaff.Username, "notcorrectpassword");
            Assert.AreEqual(0, staff.StaffID);
            //Check for correct login
            staff = await service.GetStaffMember(TestStaff.Username, TestStaff.Password);

            Assert.AreEqual(TestStaff.StaffID, staff.StaffID);
        }
    }
}