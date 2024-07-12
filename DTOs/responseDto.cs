namespace bookproject.DTOs
{
    public class responseDto
    {
        public int statusCode { get; set; }
        public string? message { get; set; }
        public object? model { get; set; }
        public bool isSuccess { get; set; }
        public ICollection<Object>? models { get; set; }
    }
}
