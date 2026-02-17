namespace Dto.Api
{
    public class ApiResponseDto<T> where T : class
    {
        public T ResponseValue { set; get; }
        public bool ExecutionOk { set; get; }
        public List<ApiErrorDto> Errors { set; get; }
    }
}