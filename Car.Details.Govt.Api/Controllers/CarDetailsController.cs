using Car.Details.Govt.Common.Constant;
using Car.Details.Govt.Common.DTO;
using Car.Details.Govt.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Car.Details.Govt.Api.Controllers
{
    [Route("Govtdomain/api/[action]/{carreg?}")]
    public class CarDetailsController : Controller
    {
        private readonly ICarDetailsBusinessLogic carDetailsBusinessLogic;

        public CarDetailsController(ICarDetailsBusinessLogic carDetailsBusiness)
        {
            carDetailsBusinessLogic = carDetailsBusiness;
        }


        #region Report Submit

        /// <summary>
        /// Method to Submit Request for Insurance
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> InsuranceStatus(string carreg)
        {
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.InsuranceStatusAsync(carreg);
            if (temp)
            {
                res = String.Format(CarDetailsConstant.DETAILS_FOUND,"Insurance");

            }
            else
            {
                res = "No Details found for given Registration Number.";
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for Accident Details
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> AccidentDetails(string carreg)
        {
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.AccidentDetailsAsync(carreg);
            if (temp)
            {
                res = String.Format(CarDetailsConstant.DETAILS_FOUND, "Accident");

            }
            else
            {
                res = "No Details found for given Registration Number.";
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for Car Owner Details
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> CarOwners(string carreg)
        {
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.CarOwnersAsync(carreg);
            if (temp)
            {
                res = String.Format(CarDetailsConstant.DETAILS_FOUND, "CarOwner");

            }
            else
            {
                res = "No Details found for given Registration Number.";
            }
            return res;
        }

        /// <summary>
        /// Method to Submit Request for Pollution Certificate details
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> PollutionCertificate(string carreg)
        {
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.PollutionCertificateAsync(carreg);
            if (temp)
            {
                res = String.Format(CarDetailsConstant.DETAILS_FOUND, "PollutionCertificate");

            }
            else
            {
                res = "No Details found for given Registration Number.";
            }
            return res;
        }

        #endregion


        #region Download Report

        /// <summary>
        /// Method to Download Report for Insurnace after Requesting
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> InsuranceDownload(string carreg)
        {
            InsuranceDto response = null;
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.InsuranceDownloadAsync(carreg);

            if(temp != null)
            {
                response = temp;
            }
            else
            {
                return Ok("Download Link expire or you have not submit the Request");
            }
            
            return Ok(response);
        }


        /// <summary>
        /// Method to Download Report for Accident after Requesting
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> AccidentDownload(string carreg)
        {
            AccidentDto response = null;
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.AccidentDownloadAsync(carreg);

            if (temp != null)
            {
                response = temp;
            }
            else
            {
                return Ok("Download Link expire or you have not submit the Request");
            }

            return Ok(response);
        }

        /// <summary>
        /// Method to Download Report for Car Owner after requesting
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CarOwnersDownload(string carreg)
        {
            OwnerDto response = null;
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.CarOwnersDownloadAsync(carreg);

            if (temp != null)
            {
                response = temp;
            }
            else
            {
                return Ok("Download Link expire or you have not submit the Request");
            }

            return Ok(response);
        }

        /// <summary>
        /// Method to Download Report for Polluction Certificate after requesting
        /// </summary>
        /// <param name="carreg"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PollutionCertDownload(string carreg)
        {
            PollutionDto response = null;
            string res = string.Empty;
            var temp = await carDetailsBusinessLogic.PollutionCertDownloadAsync(carreg);

            if (temp != null)
            {
                response = temp;
            }
            else
            {
                return Ok("Download Link expire or you have not submit the Request");
            }

            return Ok(response);
        }
        #endregion
    }
}
