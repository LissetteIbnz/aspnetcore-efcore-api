using System.Collections.Generic;

namespace SchoolManager.Service.Responses
{
    public class ListResponse<TModel> : IListReponse<TModel>
    {
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<TModel> Model { get; set; }
    }
}
