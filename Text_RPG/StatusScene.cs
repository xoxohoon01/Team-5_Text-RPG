using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class StatusScene
    {
        public static void EnterStatus(ref Player _player)
        {
            Console.Clear();
            Console.WriteLine($"이름: {_player.Name}");
            Console.WriteLine($"직업: {_player.PlayerJob}");
            Console.WriteLine($"레벨: {_player.Level}");
            Console.WriteLine();
            Console.WriteLine($"공격력: {_player.Damage}");
            Console.WriteLine($"방어력: {_player.Defense}");
            Console.WriteLine($"속도: {_player.Speed}");
            Console.WriteLine($"치명타확률: {_player.CriticalChance}");
            Console.WriteLine($"치명타데미지: {_player.CriticalDamage}");
            Console.WriteLine();
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }
    }
}
