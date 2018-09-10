using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Kaizala.Models
{
    public class GenerateAccessTokenRs : ErrorDetails
    {
        public string AccessToken { get; set; }
        public string EndpointUrl { get; set; }
        public long AccessTokenExpiry { get; set; }
        public string Scope { get; set; }
        public string RefreshToken { get; set; }

        public static implicit operator Task<object>(GenerateAccessTokenRs v)
        {
            throw new NotImplementedException();
        }
    }
}
