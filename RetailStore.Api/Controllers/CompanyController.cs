using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RetailStore.Api.Models;
using RetailStore.Api.Models.ViewModel;
using RetailStore.Api.Repositories;
using System.Text;

[Route("api/companies")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    // GET: api/companies
    [HttpGet]
    public ActionResult<List<Company>> GetAllCompanies()
    {
        var companies = _companyRepository.GetAllCompanies();
        return Ok(companies);
    }
    [HttpGet("DawonloadCSV")]
    public FileContentResult DownloadCsv()
    {
        List<Company> items = _companyRepository.GetAllCompanies().ToList();  // Retrieve items from the database here

        StringBuilder Csv = new StringBuilder();
        Csv.AppendLine("Id,Name"); // Add headers

        foreach (var item in items)
        {
            Csv.AppendLine($"{item.Id},{item.Name}");
        }

        byte[] data = Encoding.UTF8.GetBytes(Csv.ToString());
        return File(data, "text/csv", "itemlist.csv");
    }
    // GET: api/companies/{id}
    [HttpGet("{id}")]
    public IActionResult GetCompanyById(int id)
    {
        var company = _companyRepository.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    // POST: api/companies
    [HttpPost]
    public IActionResult CreateCompany(CompanyViewModel company)
    {
        if (company.Name == null)
        {
            return BadRequest();
        }

        _companyRepository.AddCompany(company);

        return CreatedAtAction(nameof(GetCompanyById), new { id = company.CompanyId }, company);
    }

    // PUT: api/companies/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateCompany(CompanyViewModel company)
    {

        _companyRepository.UpdateCompany(company.CompanyId,company.Name);

        return NoContent();
    }

    // DELETE: api/companies/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteCompany(int id)
    {
        var company = _companyRepository.GetCompanyById(id);

        if (company == null)
        {
            return NotFound();
        }

        _companyRepository.DeleteCompany(id);

        return NoContent();
    }
}
