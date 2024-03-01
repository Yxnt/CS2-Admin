using CounterStrikeSharp.API.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2_Admin.Models
{
    internal class UserInfo
    {
        public CCSPlayerController Name { get; set; }
        public int Hp { get; set; }
        public int Team { get; set; }
    }
}
