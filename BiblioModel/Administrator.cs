using System;
using System.Collections.Generic;
using System.Text;

namespace BiblioModel
{
    public class Administrator :ApplicationUser
    {
        public Administrator()
        {
            Role.Descriminator = Descriminator.Administrator;
        }
        public bool IsSuperUser { get; set; }
        public DateTime StartAsAdmin { get; set; }
        public TimeSpan WorkPeriodTime { get; set; }
    }
}
