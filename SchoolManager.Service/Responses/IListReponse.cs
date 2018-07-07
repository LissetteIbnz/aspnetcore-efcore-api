using System.Collections.Generic;

namespace SchoolManager.Service.Responses
{
    public interface IListReponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
