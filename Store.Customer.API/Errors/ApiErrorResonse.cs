namespace Store.Customer.API.Errors
{
    //Go To All Controll And User This Error To Handling

    public class ApiErrorResonse
    {
        public string? Message {  get; set; }

        public int StatusCode {  get; set; }

        public ApiErrorResonse( int StatusCode, string? Message=null)
        {
            //Null Collesing Operator

            this.Message = Message ?? GetMSH(StatusCode);


            this.StatusCode = StatusCode;
        }

        private string GetMSH(int statuscode)
        {
            var message = statuscode switch
            {
                400 => "Bad Request",
                401 => "Not Authorized",
                404 => "Not Found",
                500 => "Server Error",
                _ => null
            } ;
            return message;
            
        }

    }
}
