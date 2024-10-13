using System.Diagnostics;

namespace Fiap.Api.DesastresNaturais.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}