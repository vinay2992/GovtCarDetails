using Car.Details.Govt.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Details.Govt.Interface
{
    public interface ICarDetailsCache
    {
        CarTestDataDto Get(string carReg);

        void Store(string carReg, CarTestDataDto value);
    }
}
