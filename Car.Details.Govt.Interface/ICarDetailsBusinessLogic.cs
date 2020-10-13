using Car.Details.Govt.Common.DTO;
using System.Threading.Tasks;

namespace Car.Details.Govt.Interface
{
    public interface ICarDetailsBusinessLogic
    {
        public Task<bool> InsuranceStatusAsync(string carReg);
        public Task<bool> AccidentDetailsAsync(string carReg);
        public Task<bool> CarOwnersAsync(string carReg);
        public Task<bool> PollutionCertificateAsync(string carReg);
        public Task<InsuranceDto> InsuranceDownloadAsync(string carReg);
        public Task<AccidentDto> AccidentDownloadAsync(string carReg);
        public Task<OwnerDto> CarOwnersDownloadAsync(string carReg);
        public Task<PollutionDto> PollutionCertDownloadAsync(string carReg);
    }
}
