using AutoMapper;
using CityManagerApi.Data;
using CityManagerApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;
        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            //var cities = _appRepository.GetCities(3)
            //    .Select(c => new CityForListDto
            //    {
            //         Description = c.Description,
            //          Id=c.Id,
            //           Name = c.Name,
            //           PhotoUrl=c.Photos.FirstOrDefault(p=>p.IsMain).Url
            //    });

            var cities = _appRepository.GetCities(3);
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            return Ok(citiesToReturn);
        }
    }
}
