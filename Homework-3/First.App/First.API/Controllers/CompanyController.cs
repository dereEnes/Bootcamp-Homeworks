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
        public IActionResult Post([FromBody] CreateCompanyModel model)
        {
            //derste bu alanı required yaptık diye ekledim yoksa fluent validation ile her alanı kontrol edip o hatalar dönülmeli 
            // tek tek böyle bakmak doğru olmaz.
            if (model.Name is null)
            {
                return BadRequest(
                    new CompanyResponse { 
                        Error = "İsim alanı boş geçilemez",
                        Success = false
                    });
            }
            companyService.AddCompany(ConvertCreateCompanyModelToCompany(model));
            return Ok(
                new CompanyResponse
                {
                    Data = "İşleminiz Başarıyla Tamamlandı",
                    Success = true
                });
        }

        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] UpdateCompanyModel model)
        {
            if (CheckCompanyExist(model.Id))
            {
                companyService.UpdateCompany(ConvertCompanyUpdateModelToCompany(model));
                return Ok(
                    new CompanyResponse
                    {
                        Data = "Şirket güncellendi.",
                        Success = true
                    });
            }
            return BadRequest(new CompanyResponse
            {
                Data = $"{model.Id} Id li bir şirket bulunamadı!",
                Success = false
            });
        }
        [NonAction]
        public Company ConvertCreateCompanyModelToCompany(CreateCompanyModel model)
        {
            return new Company
            {
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                CreatedBy = "Samet",
                CreatedAt = System.DateTime.Now,
                Description = model.Description,
                Location = model.Location,
                Name = model.Name,
                Phone = model.Phone
            };
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
        public Company ConvertCompanyUpdateModelToCompany(UpdateCompanyModel model)
        {
            Company company = companyService.GetCompany(c => c.Id == model.Id);
            return (new Company
            {

                Address = model.Address == default ? company.Address : model.Address,
                City = model.City == default ? company.City : model.City,
                Description = model.Description == default ? company.City : model.City,
                CreatedBy = company.CreatedBy,
                CreatedAt = company.CreatedAt,
                IsDeleted = company.IsDeleted,
                Name = model.Name.ToUpper() == default ? company.Name : model.Name,
                Country = model.Country == default ? company.Country : model.Country,
                Phone = model.Phone == default ? company.Phone : model.Phone,
                Location = model.Location == default ? company.Location : model.Location,
            });
        }
        
    }
}
