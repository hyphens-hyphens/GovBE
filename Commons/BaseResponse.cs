namespace GovBE.Commons
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public int Status { get; set; } = 200;
        public bool IsError { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }
}
