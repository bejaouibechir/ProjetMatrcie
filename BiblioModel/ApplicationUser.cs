using Microsoft.AspNetCore.Identity;
using System;

namespace BiblioModel
{
    public class ApplicationUser : IdentityUser
    {
        private string _password;
        private string _confirmpassword;

        public string Password {
            get { return _password; } 
            set
            {
                PasswordHash = Password.GetHashCode().ToString();
                _password = value;
            }
        }
        public string ConfirmPassword {
            get { return _confirmpassword; }
            set
            {
                if (!_confirmpassword.Equals(Password))
                    throw new ConfirmPasswordException("Le mot de passe n'est pas" +
                        "conforme");
                _confirmpassword = value;
            }
        
        }

        public ApplicationRole Role { get; set; }
    }
}
