namespace Store.Customer.API.Errors
{
    public class ApiExceptionResponse:ApiErrorResonse
    {
        public string? Details {  get; set; }
        public ApiExceptionResponse(int statuscode,string? message=null,string?details=null):base(statuscode,message)
        {
            Details = details;
        }
    }
}
