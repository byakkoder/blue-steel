using System.Collections.Generic;

namespace Byakkoder.BlueSteel.SharedKernel.Dto
{
    public class GenericResultsPage<T> where T : class
    {
        #region Properties
        
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }

        public List<T> Results { get; set; } = new List<T>();

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        #endregion
    }
}
