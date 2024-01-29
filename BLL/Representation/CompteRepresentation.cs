using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Representation
{
    public class CompteRepresentation
    {
        public long idRepresentation { get; set; }
        public string usernameRepresentation { get; set; }
        public string passwordRepresentation { get; set; }
        public string emailRepresentation { get; set; }
        public string telephoneRepresentation { get; set; }

    }
}
