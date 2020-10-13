using Car.Details.Govt.Common.DTO;
using Car.Details.Govt.Facades;
using Car.Details.Govt.Interface;
using System.Threading.Tasks;

namespace Car.Details.Govt.BusinessLogic
{
    public class CarDetailsBusinessLogic : ICarDetailsBusinessLogic
    {
        private readonly CarDetailsFacade carDetailsFacade;
        private CarTestDataDto carTestData;
        private readonly ICarDetailsCache _cache;

        public CarDetailsBusinessLogic(ICarDetailsCache cache)
        {
            carDetailsFacade = new CarDetailsFacade();
            _cache = cache;
        }

        #region Submit Request

        /// <summary>
        /// Method to Submit Request for Insurance
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<bool> InsuranceStatusAsync(string carReg)
        {
            bool res = false;
            carTestData = await carDetailsFacade.InsuranceStatusAsync(carReg);

            foreach (var data in carTestData.TestData)
            {
                if (data.CarRegNumber.Equals(carReg))
                {
                    res = true;
                    _cache.Store(carReg, carTestData);
                }
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for AccidentDetails
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<bool> AccidentDetailsAsync(string carReg)
        {
            bool res = false;
            carTestData = await carDetailsFacade.AccidentDetailsAsync(carReg);

            foreach (var data in carTestData.TestData)
            {
                if (data.CarRegNumber.Equals(carReg))
                {
                    res = true;
                    _cache.Store(carReg, carTestData);
                }
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for CarOwners
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<bool> CarOwnersAsync(string carReg)
        {
            bool res = false;
            carTestData = await carDetailsFacade.CarOwnersAsync(carReg);

            foreach (var data in carTestData.TestData)
            {
                if (data.CarRegNumber.Equals(carReg))
                {
                    res = true;
                    _cache.Store(carReg, carTestData);
                }
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for PollutionCertificate
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<bool> PollutionCertificateAsync(string carReg)
        {
            bool res = false;
            carTestData = await carDetailsFacade.PollutionCertificateAsync(carReg);

            foreach (var data in carTestData.TestData)
            {
                if (data.CarRegNumber.Equals(carReg))
                {
                    res = true;
                    _cache.Store(carReg, carTestData);
                }
            }
            return res;
        }

        #endregion

        #region Download Report

        /// <summary>
        /// Method to Download Report for Insurnace after Requesting
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<InsuranceDto> InsuranceDownloadAsync(string carReg)
        {
            InsuranceDto response = null;
            var caheData = _cache.Get(carReg);
            await Task.Run(() => {
                if (caheData != null)
                {
                    foreach (var data in caheData.TestData)
                    {
                        if (data.CarRegNumber.Equals(carReg))
                        {
                            response = data.Insurance;
                        }
                    }
                }
            });
            return response;
        }


        /// <summary>
        /// Method to Download Report for Accident after Requesting
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<AccidentDto> AccidentDownloadAsync(string carReg)
        {
            AccidentDto response = null;
            var caheData = _cache.Get(carReg);
            await Task.Run(() => {
                if (caheData != null)
                {
                    foreach (var data in caheData.TestData)
                    {
                        if (data.CarRegNumber.Equals(carReg))
                        {
                            response = data.Accident;
                        }
                    }
                }
            });
            return response;
        }

        /// <summary>
        /// Method to Download Report for Car Owner after requesting
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<OwnerDto> CarOwnersDownloadAsync(string carReg)
        {
            OwnerDto response = null;
            var caheData = _cache.Get(carReg);
            await Task.Run(() => {
                if (caheData != null)
                {
                    foreach (var data in caheData.TestData)
                    {
                        if (data.CarRegNumber.Equals(carReg))
                        {
                            response = data.Owner;
                        }
                    }
                }
            });
            return response;
        }

        /// <summary>
        /// Method to Download Report for Polluction Certificate after requesting
        /// </summary>
        /// <param name="carReg"></param>
        /// <returns></returns>
        public async Task<PollutionDto> PollutionCertDownloadAsync(string carReg)
        {
            PollutionDto response = null ;
            var caheData = _cache.Get(carReg);
            await Task.Run(() => {
                if (caheData != null)
                {
                    foreach (var data in caheData.TestData)
                    {
                        if (data.CarRegNumber.Equals(carReg))
                        {
                            response = data.Pollution;
                        }
                    }
                }
            });
            return response;
        }

        #endregion
    }
}
