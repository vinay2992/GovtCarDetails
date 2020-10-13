using Car.Details.Govt.Common.DTO;
using Car.Details.Govt.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Details.Govt.Cache
{
    public sealed class CarDetailsCache : ICarDetailsCache
    {
        private readonly IMemoryCache _cache;

        public CarDetailsCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public CarTestDataDto Get(string carReg)
        {
            CarTestDataDto carTestDataDto = null;
            if(_cache.TryGetValue(carReg, out CarTestDataDto temp)) {
                carTestDataDto = temp;
            }
            return carTestDataDto;
        }

        public void Store(string carReg, CarTestDataDto value)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
            };
            _cache.Set(carReg, value, options);
        }
    }
}
