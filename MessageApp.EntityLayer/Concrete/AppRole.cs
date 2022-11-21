using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.EntityLayer.Concrete
{
    public class AppRole : IdentityRole<int>
    {
        public string RoleName { get; set; }
    }
}
