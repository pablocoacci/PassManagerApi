
namespace Core.Data
{
    public interface ISortParams
    {
        string[] SortBy { get; }
        SortDirs[] SortDir { get; }
    }

    public enum SortDirs
    {
        Asc = 0,
        Desc = 1
    }

    public class SortParams : ISortParams
    {
        public SortParams()
        {
            SortBy = new string[] { };
            SortDir = new SortDirs[] { };
        }

        public string[] SortBy { get; set; }

        public SortDirs[] SortDir { get; set; }
    }
}
