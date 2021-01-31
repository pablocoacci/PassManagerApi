
namespace Core.Data
{
    public interface IPageParams
    {
        int Skip { get; }
        int Take { get; }
    }

    public class PageParams : IPageParams
    {
        public int Skip { get; set; } = 0;

        public int Take { get; set; } = 10;
    }
}
