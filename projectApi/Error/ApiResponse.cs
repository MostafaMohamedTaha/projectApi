namespace projectApi.Error
{
    public class ApiResponse
    {
        #region params

        public int StatusCode { get; set; }
        public string Message { get; set; }
        #endregion

        #region ctor
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        #endregion

        #region get message method
        private string? GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "bad request",
                401 => "unAuth please sign in",
                404 => "source not found",
                500 => "server error",
                _ => null
            };
        }
        #endregion
    }
}
