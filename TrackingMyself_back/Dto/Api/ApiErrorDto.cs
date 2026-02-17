namespace Dto.Api
{
    public class ApiErrorDto
    {
        public string Error { set; get; }
        public ApiErrorEnum ErrorType { set; get; }
        public string Where { set; get; }
    }

    public enum ApiErrorEnum
    {
        DOMAIN,
        INFRASTRUCTURE,
        APPLICATION,
        CONTROLLER
    }
}