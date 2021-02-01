using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repositories
{
    public interface IPasswordSiteRepository
    {
        void Add(PasswordSite password);
        void Delete(PasswordSite password);
        void Update(PasswordSite password);
        Task<PasswordSite> GetPasswordSiteById(string userId, int passwordId);
        Task<int> GetAllPasswordsCount(string userId, string search);
        Task<IList<PasswordSite>> GetAllPasswords(string userId, string search, ISortParams sortParams, IPageParams pageParams);
    }
}
