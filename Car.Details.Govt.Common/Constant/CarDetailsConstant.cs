using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Details.Govt.Common.Constant
{
    public static class CarDetailsConstant
    {
        const string URLValue = "https://localhost:44355/Govtdomain/api/<DownloadMethod>?carreg={0}";
        public static string DETAILS_FOUND = "Request Done. Ready for Download on below URL" + Environment.NewLine + String.Format(URLValue, "Car Registartion number")
                    + Environment.NewLine + "PLEASE Note - Download link will be validonly for 1 Hour, after that you have to request again for Download {0} Report";
    }
}
