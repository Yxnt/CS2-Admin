using CounterStrikeSharp.API.Core;


namespace CS2_Admin.Models
{
    class RoundInfo
    {

        public bool WarmUpRound = false;
        
        private long _roundNumber = 0;

        public long RoundNumber {
            get => _roundNumber;
            set 
            {
                _roundNumber = value;
            }
        }

        private List<UserAttackInfo> _attackInfo = new List<UserAttackInfo>();

        public List<UserAttackInfo> AttackInfo {
            get => _attackInfo;
            set
            {
                _attackInfo = value;
            }
        } // 造成伤害信息
    }

    
    internal class UserAttackInfo
    {
        public CCSPlayerController User { get; set; } // 被攻击玩家
        public int Hp { get; set; }
        public CCSPlayerController AttackUser { get; set; } // 发起攻击玩家
    }
    
    // 友军伤害信息
    internal class FriendlyFireInfo
    {
        public int UserID { get; set; }
        public int HitCount { get; set; }
        public int Hp { get; set; }
        public bool IsDead { get; set; }
        public int AttckUserID { get; set; }
    }

}
