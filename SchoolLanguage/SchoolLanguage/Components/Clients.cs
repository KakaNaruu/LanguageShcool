using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLanguage.Components
{
    public partial class Clients
    {
        public string FullName
            { 
            get
            {
                return $"{FirstName} {LastName} {Patronomic}";
            }
    }
}
