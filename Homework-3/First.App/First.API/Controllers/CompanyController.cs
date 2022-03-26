using First.API.Filters;
using First.API.Models;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace First.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        //[HttpGet]
        //[ServiceFilter(typeof(ActionFilterExample))]
        //public IActionResult GetData()
        //{
        //    return Ok(new { data = "Veriler Yüklendi"});
        //}
        [HttpGet]
        [Log]
        public IActionResult Log()
        {
            return NoContent();
        }
        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete([FromForm]int id)
        {
            if (CheckCompanyExist(id))
            {
                companyService.DeleteCompany(companyService.GetCompany(x=> x.Id == id));
                return Ok(new CompanyResponse
                {
                    Success = true,
                    Data = "Şirket silindi"
                });
            }
            return BadRequest(new CompanyResponse
            {
                Data = "Şirket bulunamadı",
                Success = false
            });

        }
        [Route("getbyid")]
        [HttpGet]
        public IActionResult GetById([FromForm] int id)
        {
            if (CheckCompanyExist(id))
            {
                return Ok(new CompanyResponse
                {
                    Success = true,
                    Data = companyService.GetCompany(x => x.Id == id)
                });
            }
            return BadRequest(new CompanyResponse
            {
                Data = "Şirket bulunamadı",
                Success = false
            });

        }
        /// <summary>
        /// Tüm şirket bilgilerini getirir.
        /// </summary>
        /// <returns></returns>
        [Route("Companies")]
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAllCompany().Select(x => new CompanyDto
            {
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                Description = x.Description,
                Location = x.Location,
                Phone = x.Phone
            });
            return Ok(new CompanyResponse { Data = companies, Success = true });
        }

        /// <summary>
        /// Şirket ekleme işlemi yapar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("AddCompany")]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto model)
        {
            companyService.AddCompany(ConvertCompanyDtoToCompany(model));
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] CompanyDto model,[FromQuery] int companyId)
        {
            if (CheckCompanyExist(companyId))
            {
                companyService.UpdateCompany(ConvertCompanyDtoToCompany(model));
                return Ok(
                    new CompanyResponse
                    {
                        Data = "İşleminiz Başarıyla Tamamlandı",
                        Success = true
                    });
            }
            return BadRequest(new CompanyResponse
            {
                Data = $"{companyId} Id li bir şirket bulunamadı!",
                Success = false
            });
        }
        [NonAction]
        public bool CheckCompanyExist(int id)
        {
            var company = companyService.GetCompany(x => x.Id == id);
            if (company is null)
            {
                return false;
            }
            return true;
        }
        [NonAction]
        public Company ConvertCompanyDtoToCompany(CompanyDto model)
        {
            return (new Company
            {
                Address = model.Address,
                City = model.City,
                Description = model.Description,
                CreatedBy = "SAMET",
                CreatedAt = System.DateTime.Now,
                IsDeleted = false,
                Name = model.Name.ToUpper(),
                Country = model.Country,
                Phone = model.Phone,
                Location = model.Location,
            });
        }
        
    }
}
