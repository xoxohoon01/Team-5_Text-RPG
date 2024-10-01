using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Skill
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int MPCost {  get; set; }

        public Skill(string name, int damage, int mpCost)
        {
            Name = name;
            Damage = damage;
            MPCost = mpCost;
        }

        // 스킬을 사용하여 피해자에게 피해를 입히는 메서드
        public void UseSkill(ref Player caster, ref Player target)
        {
            if (caster.MP < MPCost)
            {
                Console.WriteLine($"{caster.Name}은(는) MP가 부족하여 {Name} 스킬을 사용할 수 없습니다.");
                return;
            }

            caster.MP -= MPCost;  // 스킬 사용으로 마나 소모
            Console.WriteLine($"{caster.Name}이(가) {Name} 스킬을 사용하여 {target.Name}에게 {Damage}의 피해를 입혔습니다. (MP 소모: {MPCost})");

            target.HP -= Damage;  // 피해자의 HP 감소

            if (target.HP <= 0)
            {
                target.HP = 0;  // HP는 0 이하로 떨어지지 않도록 설정
                Console.WriteLine($"{target.Name}은(는) 쓰러졌습니다.");
            }
            else
            {
                Console.WriteLine($"{target.Name}의 남은 HP: {target.HP}");
            }

            Console.WriteLine($"{caster.Name}의 남은 MP: {caster.MP}");
        }



        //직업별 스킬 생성 메서드
        public static Skill[] CreateSkills(string job)
        {
            switch (job.ToLower())
            {
                case "warrior":
                    return new Skill[]
                    {
                    new Skill("Slash", 20, 10),
                    new Skill("Shield Bash", 15, 5),
                    new Skill("Power Strike", 30, 15)
                    };

                case "archer":
                    return new Skill[]
                    {
                    new Skill("Arrow Shot", 15, 7),
                    new Skill("Rapid Fire", 25, 12),
                    new Skill("Piercing Arrow", 35, 18)
                    };

                case "thief":
                    return new Skill[]
                    {
                    new Skill("Backstab", 25, 12),
                    new Skill("Poison Dagger", 20, 10),
                    new Skill("Stealth Attack", 40, 21)
                    };

                case "mage":
                    return new Skill[]
                    {
                    new Skill("Fireball", 30, 15),
                    new Skill("Ice Blast", 25, 12),
                    new Skill("Lightning Strike", 40, 21)
                    };

                default:
                    throw new ArgumentException("잘못된 직업명입니다.");

            }
        }
    }
}
