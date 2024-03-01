using CounterStrikeSharp.API.Core;
using CS2_Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2_Admin.Utils
{
    internal class UserAttack
    {

        public UserAttackInfo Damage(CCSPlayerController attackUserInfo, CCSPlayerController UserInfo, int hp)
        {
            UserAttackInfo attackInfo = new UserAttackInfo();
                // 他人造成伤害
                attackInfo.User = UserInfo;
                attackInfo.Hp = hp;
                attackInfo.AttackUser= attackUserInfo;
            return attackInfo;
        }
    }
    
}
