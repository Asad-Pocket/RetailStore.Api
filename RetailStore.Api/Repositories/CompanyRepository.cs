using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RetailStore.Api.Models.ViewModel;
using RetailStore.Api.Models;
using RetailStore.Api.Models.Domain;

namespace RetailStore.Api.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCompany(CompanyViewModel company)
        {
            _context.Database.ExecuteSqlRaw("EXEC CreateCompany @Name", new SqlParameter("@Name", company.Name));
        }
        public void UpdateCompany(int id , string companyName)
        {
            
            _context.Database.ExecuteSqlRaw("EXEC UpdateCompany @Id, @Name",
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", companyName));
        }


        public void DeleteCompany(int companyId)
        {
            _context.Database.ExecuteSqlRaw("EXEC DeleteCompany @Id", new SqlParameter("@Id", companyId));
        }


        public List<Company> GetAllCompanies()
        {

            return _context.CompanyList.FromSqlRaw("EXEC GetAllCompanies").ToList();

        }

        public Company GetCompanyById(int id)
        {
            return _context.CompanyList
                .FromSqlRaw("EXEC GetCompanyById @Id", new SqlParameter("@Id", id))
                .AsEnumerable()
                .SingleOrDefault();
        }

    }
}
