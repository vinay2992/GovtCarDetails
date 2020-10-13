using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Details.Govt.Common.DTO
{
    public sealed class AllCarDetailsDto
    {
        public string CarRegNumber { get; set; }

        public InsuranceDto Insurance { get; set; }

        public PollutionDto Pollution { get; set; }

        public AccidentDto Accident { get; set; }

        public OwnerDto Owner { get; set; }
    }
}
