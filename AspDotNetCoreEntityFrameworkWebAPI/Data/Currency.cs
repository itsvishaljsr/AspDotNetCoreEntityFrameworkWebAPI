using System.Diagnostics.CodeAnalysis;

namespace AspDotNetCoreEntityFrameworkWebAPI.Data
{
    public class Currency
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public ICollection<BookPrice> BookPrice { get; set; }
    }
}
