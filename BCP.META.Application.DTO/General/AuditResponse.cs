namespace BCP.META.Application.DTO.General;

public class AuditResponse
{
    /// <summary>
    /// Request response code
    /// </summary>
    public string CodeResponse { get; set; }
    /// <summary>
    /// Request response message
    /// </summary>
    public string MessageResponse { get; set; }
    /// <summary>
    /// Request error code
    /// </summary>
    public int StatusCode { get; set; }
}
