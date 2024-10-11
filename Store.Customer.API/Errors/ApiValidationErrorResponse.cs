namespace Store.Customer.API.Errors
{
    public class ApiValidationErrorResponse: ApiErrorResonse
    {
      public  IEnumerable<string> lstErrors {  get; set; }=new List<string>();

        public ApiValidationErrorResponse():base(404)
        {
            
        }
    }
}
