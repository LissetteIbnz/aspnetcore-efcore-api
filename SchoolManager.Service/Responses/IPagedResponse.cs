namespace SchoolManager.Service.Responses
{
    public interface IPagedResponse<TModel> : IListReponse<TModel>
    {
        int ItemsCount { get; set; }
        int PageCount { get; }
    }
}
