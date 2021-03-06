﻿using Core.Entities;
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

        public async Task<PasswordSite> GetPasswordSiteById(string userId, int passwordId)
            => await dataContext.PasswordSites.Where(x => x.UserId == userId && x.Id == passwordId).FirstOrDefaultAsync();

        public async Task<int> GetAllPasswordsCount(string userId, string search)
        {
            search = search.ToUpper();
            return await dataContext.PasswordSites
                        .Where(x => x.UserId == userId)
                        .Where(!string.IsNullOrEmpty(search), x => x.NameSite.ToUpper().Contains(search) || x.UserNameSite.ToUpper().Contains(search) || x.Password.ToUpper().Contains(search))
                        .CountAsync();
        }

        public async Task<IList<PasswordSite>> GetAllPasswords(string userId, string search, ISortParams sortParams, IPageParams pageParams)
            => await dataContext.PasswordSites
                        .Where(x => x.UserId == userId)
                        .Where(string.IsNullOrEmpty(search), x => x.NameSite.Contains(search) || x.UserNameSite.Contains(search))
                        .OrderBy(sortParams, "nameSite", x => x.NameSite)
                        .ThenBy(sortParams, "userNameSite", x => x.UserNameSite)
                        .ThenBy(sortParams, "password", x => x.Password)
                        .Skip(pageParams.Skip)
                        .Take(pageParams.Take)
                        .ToListAsync();
    }
}
