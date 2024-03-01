using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2_Admin.Models
{
    internal class GameInfo
    {
        public string MapName { get; set; }
        public long MaxRound { get; set; }
        public string MaxPlayer { get; set; }

        private List<UserInfo> _playerTeamInfo = new List<UserInfo>() ;
        public List<UserInfo> PlayerTeamInfo
        {
            get => _playerTeamInfo;
            set
            {
                _playerTeamInfo = value;
            }
        }
    }

}
