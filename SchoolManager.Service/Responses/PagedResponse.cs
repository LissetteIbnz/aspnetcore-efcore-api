using System.Collections.Generic;

namespace SchoolManager.Service.Responses
{
    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }

        public IEnumerable<TModel> Model { get; set; }

        public int ItemsCount { get; set; }
        public int PageCount =>
            PageSize == 0 ? 0 : ItemsCount / PageSize;

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
