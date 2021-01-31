using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Data.Helpers.Extensions;
using Core.Data.Repositories;

namespace Core.Data.EF.Repositories
{
    public class PasswordSiteRepository : IPasswordSiteRepository
    {
        private readonly DataContext dataContext;

        public PasswordSiteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Add(PasswordSite password)
            => dataContext.PasswordSites.Add(password);

        public void Delete(PasswordSite password)
            => dataContext.PasswordSites.Remove(password);

        public void Update(PasswordSite password)
            => dataContext.PasswordSites.Update(password);

        public async Task<PasswordSite> GetPasswordSiteById(int id)
            => await dataContext.PasswordSites.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IList<PasswordSite>> GetAllPasswords(string userId, ISortParams sortParams, IPageParams pageParams)
            => await dataContext.PasswordSites
                        .Where(x => x.UserId == userId)
                        .OrderBy(sortParams, "nameSite", x => x.NameSite)
                        .ThenBy(sortParams, "urlSite", x => x.URLSite)
                        .ThenBy(sortParams, "userNameSite", x => x.UserNameSite)
                        .ThenBy(sortParams, "password", x => x.Password)
                        .Skip(pageParams.Skip)
                        .Take(pageParams.Take)
                        .ToListAsync();
    }
}
