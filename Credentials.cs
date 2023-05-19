using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_with_classes
{
    class Credentials
    {
        public string Name;
        public string Password;
        public string Role;
        public Credentials()
        {

        }
        public Credentials(string Name, string Password, string Role)
        {
            this.Name = Name;
            this.Password = Password;
            this.Role = Role;
        }
    }
    
}
