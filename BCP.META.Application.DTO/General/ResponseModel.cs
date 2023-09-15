namespace BCP.META.Application.DTO.General
{
    public class ResponseModel<T> where T : class
    {
        /// <summary>
        /// Constructor for ResponseModel
        /// </summary>
        public ResponseModel()
        {
            IsValid = true;
        }

        /// <summary>
        /// Generation Indicator (1 = correct, 0 = error)
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Entity for Audit
        /// </summary>
        public AuditResponse AuditResponse { get; set; }

        /// <summary>
        /// Entity for Response
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// Entity for Response List
        /// </summary>
        public IEnumerable<T> EntityList { get; set; }
    }
}
