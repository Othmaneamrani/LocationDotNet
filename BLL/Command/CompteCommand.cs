using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Command
{
    public class CompteCommand
    {
        public long idCommand { get; set; }
        public string usernameCommand { get; set; }
        public string passwordCommand { get; set; }
        public string emailCommand { get; set; }
        public string telephoneCommand { get; set; }

    }
}
