using AutoMapper;
using ECommerceApi.DTO;
using ECommerceApi.Interfaces;
using ECommerceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.Services
{
    public class LaptopService:ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly ILaptopValidator _laptopValidator;
        private readonly IMapper _mapper;
        public  LaptopService(ILaptopRepository laptopRepository, IMapper mapper, ILaptopValidator laptopValidator)
        {
            _laptopRepository = laptopRepository;
            _laptopValidator = laptopValidator;
            _mapper = mapper;
        }

        public async Task<Laptop> AddLaptop(Laptop laptop)
        {
            if (!_laptopValidator.IsLaptopValid(laptop))
                throw new Exception("Laptop with same details found, please add different laptop" + laptop);

            return await _laptopRepository.AddLaptop(laptop);
        }

        public async Task<List<LaptopDTO>> GetLaptops()
        {
            var laptops = await _laptopRepository.GetLaptops();
            var laptopsDto = _mapper.Map<List<LaptopDTO>>(laptops);

            return laptopsDto;
        }
    }
}
