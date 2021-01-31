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
        Task<IList<PasswordSite>> GetAllPasswords(string userId, ISortParams sortParams, IPageParams pageParams);
    }
}
