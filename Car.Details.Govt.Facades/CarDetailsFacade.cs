using Car.Details.Govt.Common.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Car.Details.Govt.Facades
{
    public sealed class CarDetailsFacade
    {
        private readonly IConfiguration configuration;
        private readonly CarTestDataDto carTestData;

        public CarDetailsFacade()
        {
            configuration = GetTestData();
            carTestData = configuration.GetSection("MockData").Get<CarTestDataDto>();

        }
        private IConfiguration GetTestData()
        {
            var testfile = new ConfigurationBuilder()
                .AddJsonFile("TestData.json")
                .Build();
            return testfile;
        }

        /// <summary>
        /// Method to call 3rd party service to fetch Insurenace Details .
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<CarTestDataDto> InsuranceStatusAsync(string carReg)
        {

            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("http://www.google.com")
            };

            requestMessage.Headers.Add("Add", "Header Value");
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            //Sending Mock data back Business Class
            return carTestData;
        }

        /// <summary>
        /// Method to call 3rd party service to fetch Accident Details .
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<CarTestDataDto> AccidentDetailsAsync(string carReg)
        {

            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("http://www.google.com")
            };

            requestMessage.Headers.Add("Add", "Header Value");
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            //Sending Mock data back Business Class
            return carTestData;
        }

        /// <summary>
        /// Method to call 3rd party service to fetch CarOwners Details .
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<CarTestDataDto> CarOwnersAsync(string carReg)
        {

            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("http://www.google.com")
            };

            requestMessage.Headers.Add("Add", "Header Value");
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            //Sending Mock data back Business Class
            return carTestData;
        }

        /// <summary>
        /// Method to call 3rd party service to fetch PollutionCertificate Details .
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<CarTestDataDto> PollutionCertificateAsync(string carReg)
        {

            HttpClient client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri("http://www.google.com")
            };

            requestMessage.Headers.Add("Add", "Header Value");
            HttpResponseMessage response = await client.SendAsync(requestMessage);

            //Sending Mock data back Business Class
            return carTestData;
        }


    }
}
