using System.Collections.Generic;

namespace SchoolManager.Service.Responses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
