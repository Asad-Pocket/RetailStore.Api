using RetailStore.Api.Models;
using RetailStore.Api.Models.ViewModel;

namespace RetailStore.Api.Repositories
{
    public interface ICompanyRepository 
    {
        public List<Company> GetAllCompanies();
        public Company GetCompanyById(int id);
        public void AddCompany(CompanyViewModel item);
        public void UpdateCompany(int id, string itemname);
        public void DeleteCompany(int id);
    }
}
