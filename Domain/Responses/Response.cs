using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Descrip { get; set; }
    public T? Data { get; set; }

    public Response(HttpStatusCode code,List<string> descrip,T data)
    {
        StatusCode = (int)code;
        Descrip = descrip;
        Data = data;
    }
    public Response(HttpStatusCode code,string descrip,T data)
    {
        StatusCode = (int)code;
        Descrip.Add(descrip);
        Data = data;
    }
    
    public Response(HttpStatusCode code,List<string> descrip)
    {
        StatusCode = (int)code;
        Descrip = descrip;
        
    }
    public Response(HttpStatusCode code,string descrip)
    {
        StatusCode = (int)code;
        Descrip.Add(descrip);
    }
    
    public Response(HttpStatusCode code,T data)
    {
        StatusCode = (int)code;
        Data = data;
    }
    
    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}
