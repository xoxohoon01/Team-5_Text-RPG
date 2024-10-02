using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
     public class Skill
    {
        public string Name { get; set; }
        public int BaseDamage { get; set; }
        public int MPCost { get; set; }
        public float CritcalDamageMultiplier { get; set; }  // 치명타 데미지 배율
        public float CritcalChance { get; set; }  // 치명타 확률

        public Skill(string name, int baseDamage, int mpCost, float critcalDamageMultiplier, float critcalChance)
        {
            Name = name;
            BaseDamage = baseDamage;
            MPCost = mpCost;
            CritcalDamageMultiplier = critcalDamageMultiplier;
            CritcalChance = critcalChance;
        }

        // 스킬을 사용하여 피해자에게 피해를 입히는 메서드
        public void UseSkill(ref Player _caster, ref Monster _unit)
        {
            Program.ShowMsgOnBattle();
            if (_caster.MP < MPCost)
            {
                Program.ShowMsgOnBattle($"{_caster.Name}은(는) MP가 부족하여 {Name} 스킬을 사용할 수 없습니다.");
            }

            _caster.MP -= MPCost;  // 마나 소모

            // 치명타 여부 확인
            bool isCriticalHit = new Random().NextDouble() < CritcalChance;

            // 최종 피해량 계산
            float finalDamage = CalculateFinalDamage(_caster.Damage, _unit.Defense, isCriticalHit);
            _unit.HP -= (int)finalDamage;  // 피해자의 HP 감소

            Console.WriteLine($"{_caster.Name}이(가) {Name} 스킬을 사용하여 {_unit.Name}에게 {(int)finalDamage}의 피해를 입혔습니다. (MP 소모: {MPCost})");         
        }

        private float CalculateFinalDamage(int attackerAttack, int unitDefense, bool isCriticalHit)
        {
            // 기본 피해량 계산
            float damage = (attackerAttack - unitDefense) * BaseDamage;

            // 치명타 적용
            if (isCriticalHit)
            {
                damage *= CritcalDamageMultiplier;
                Console.WriteLine("치명타!");
            }

            // -10% ~ +10%의 랜덤성 적용
            float randomFactor = 1 + (new Random().Next(-10, 11) / 100f);
            damage *= randomFactor;

            return Math.Max(damage, 0);  // 피해량은 0 이하가 되지 않도록
        }

        // 직업별 스킬 생성 메서드
        public static Skill[] CreateSkills(string _job)
        {
            switch (_job.ToLower())
            {
                case "warrior":
                    return new Skill[]
                    {
                        new Skill("Slash", 20, 10, 1.5f, 0.1f),
                        new Skill("Shield Bash", 15, 5, 1.2f, 0.05f),
                        new Skill("Power Strike", 30, 15, 2.0f, 0.15f),
                        new Skill("War Cry", 10, 8, 1.0f, 0.0f)  // 공격력 증가 효과 추가
                    };

                case "thief":
                    return new Skill[]
                    {
                        new Skill("Backstab", 25, 12, 2.0f, 0.3f),
                        new Skill("Poison Dagger", 20, 10, 1.2f, 0.1f),
                        new Skill("Stealth Attack", 40, 21, 2.5f, 0.25f),
                        new Skill("Lucky Strike", 15, 5, 1.5f, 0.2f)  // 추가 공격 기회 제공
                    };

                case "archer":
                    return new Skill[]
                    {
                        new Skill("Arrow Shot", 15, 7, 1.2f, 0.1f),
                        new Skill("Rapid Fire", 10, 10, 1.1f, 0.05f),  // 연속 공격
                        new Skill("Multi-Shot", 12, 15, 1.3f, 0.15f),  // 여러 적 공격
                        new Skill("Piercing Arrow", 35, 18, 1.5f, 0.2f)
                    };

                case "mage":
                    return new Skill[]
                    {
                        new Skill("Fireball", 30, 15, 1.8f, 0.2f),
                        new Skill("Ice Blast", 25, 12, 1.5f, 0.15f),
                        new Skill("Lightning Strike", 40, 21, 2.0f, 0.25f),
                        new Skill("Mana Drain", 20, 10, 1.0f, 0.0f)  // MP 회복 효과 추가
                    };

                default:
                    throw new ArgumentException("잘못된 직업명입니다.");
            }
        }
    }
}
