using System.Net;

namespace Domain.Responses;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPage { get; set; }
    public int TotalRecord { get; set; }

    public PagedResponse(T data, int pageNumber,int pageSize,int totalRecord):base(data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecord = totalRecord;
        TotalPage = (int)Math.Ceiling(totalRecord/(float)pageSize);
    }
    public PagedResponse(HttpStatusCode code, List<string> descrip, T data) : base(code, descrip, data)
    {
    }public PagedResponse(HttpStatusCode code, string descrip, T data) : base(code, descrip, data)
    {
    }


}
