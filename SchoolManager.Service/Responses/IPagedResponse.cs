namespace SchoolManager.Service.Responses
{
    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }
        int PageCount { get; }
    }
}
