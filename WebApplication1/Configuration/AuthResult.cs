using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Error { get; set; }

    }
}
