namespace BCP.META.Presentation.Entities
{
    public class ApiResponse<T>
    {
        public bool isValid { get; set; }
        public AuditResponse auditResponse { get; set; }
        public object entity { get; set; }
        public List<T> entityList { get; set; }
    }

    public class AuditResponse
    {
        public string codeResponse { get; set; }
        public string messageResponse { get; set; }
        public int statusCode { get; set; }
    }

}
