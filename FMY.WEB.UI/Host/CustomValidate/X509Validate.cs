using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.CustomValidate
{
    public class MyX509Validator : System.IdentityModel.Selectors.X509CertificateValidator
    {

        public override void Validate(System.Security.Cryptography.X509Certificates.X509Certificate2 certificate)
        {
            if (certificate == null)
            {
                throw new ArgumentNullException("X509认证证书为空！");
            }
            if (certificate.Thumbprint != "3cebec23ab7c9604d5ea7309c469b10223ecd9be".ToUpper())
            {
                //throw new System.IdentityModel.Tokens.SecurityTokenException("Certificate Validation Error!");
            }
        }
    }
}
