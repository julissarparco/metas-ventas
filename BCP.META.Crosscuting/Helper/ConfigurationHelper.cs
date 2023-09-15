using BCP.META.Application.DTO.General;

namespace BCP.META.Crosscuting.Helper
{
    public class ConfigurationHelper
    {
        public static string GetMessageResponseService(CodeResponseService codeResponseService)
        {
            string messageResponse = codeResponseService switch
            {
                CodeResponseService.Success => "Successful operation",
                CodeResponseService.NoData => "No data found",
                CodeResponseService.TimeOutBd => "Database timeout error",
                CodeResponseService.AvailabilityBd => "A problem occurred in the database",
                CodeResponseService.TimeOutServicio => "Service timeout error",
                CodeResponseService.AvailabilityService => "Service availability error",
                CodeResponseService.UnexpectedError => "An unexpected error occurred",
                _ => string.Empty
            };

            return messageResponse;
        }

        public int ObtenerStatusCode(string codeResponse)
        {
            int statusCode = 0;

            if (codeResponse == Convert.ToString((int)CodeResponseService.TimeOutBd) ||
                codeResponse == Convert.ToString((int)CodeResponseService.TimeOutServicio))
            {
                statusCode = Convert.ToInt32(StatusCode.TimeOut);
            }
            else if (codeResponse == Convert.ToString((int)CodeResponseService.Success))
            {
                statusCode = Convert.ToInt32(StatusCode.Ok);
            }
            else if (codeResponse == Convert.ToString((int)CodeResponseService.Created))
            {
                statusCode = Convert.ToInt32(StatusCode.Created);
            }
            else if (codeResponse == Convert.ToString((int)CodeResponseService.NoData))
            {
                statusCode = Convert.ToInt32(StatusCode.NotFound);
            }
            else
            {
                statusCode = Convert.ToInt32(StatusCode.IncorrectRequest);
            }

            return statusCode;
        }

        public void GetResponseCode(ref AuditResponse auditResponse, int exNumber, string exMessage)
        {
            if (exNumber != 0)
            {
                if (exNumber != -2)
                {
                    auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.AvailabilityBd);
                    auditResponse.MessageResponse = GetMessageResponseService(CodeResponseService.AvailabilityBd);
                }
                switch (exNumber)
                {
                    case 50000:
                        auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.AvailabilityBd);
                        auditResponse.MessageResponse = exMessage;
                        break;
                    case -2:
                        auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.TimeOutBd);
                        auditResponse.MessageResponse = GetMessageResponseService(CodeResponseService.TimeOutBd);
                        break;
                    case -5:
                        auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.UnexpectedError);
                        auditResponse.MessageResponse = GetMessageResponseService(CodeResponseService.UnexpectedError);
                        break;
                    case 2:
                        auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.NoData);
                        auditResponse.MessageResponse = GetMessageResponseService(CodeResponseService.NoData);
                        break;
                }
            }
            else
            {
                auditResponse.CodeResponse = Convert.ToString((int)CodeResponseService.Success);
                auditResponse.MessageResponse = GetMessageResponseService(CodeResponseService.Success);
            }
            auditResponse.StatusCode = ObtenerStatusCode(auditResponse.CodeResponse);
        }

        public enum CodeResponseService
        {
            Success = 0,
            Created = 1,
            NoData = 2,
            TimeOutBd = -1,
            AvailabilityBd = -2,
            TimeOutServicio = -3,
            AvailabilityService = -4,
            UnexpectedError = -5
        }

        public enum StatusCode
        {
            Ok = 200,
            Created = 201,
            IncorrectRequest = 400,
            NotFound = 404,
            ErrorInternal = 500,
            TimeOut = 504
        }
    }
}
