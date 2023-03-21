namespace HelsiTest.Core.Entities
{
    public class PaginationModel<T>
    {
        public List<T> Items { get; set; }

        public int ItemsOnPage { get; set; }

        public int PageNum { get; set; }

        public int TotalPages { get; set; }
        
    }
}
