namespace Dto.Api
{
    public class ApiRequestDto<T> where T : class
    {
        public T RequestValue { set; get; }
        public long Timestamp { set; get; }
        public string Token { set; get; }
    }
}