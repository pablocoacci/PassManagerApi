using Core.Data;
using Core.Shared;
using Core.V1.PasswordSites.GetPasswordSiteList.Models;
using MediatR;

namespace Core.V1.PasswordSites.GetPasswordSiteList
{
    public class GetPasswordSiteListRequest : LoggedRequest, IRequest<PagedResults<PasswordSiteModel>>
    {
        public GetPasswordSiteListRequest()
        {
            SortParams = new SortParams();
        }

        public SortParams SortParams { get; set; }
        public PageParams PageParams { get; set; }
        public string SearchValue { get; set; }
    }
}
