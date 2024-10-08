﻿namespace TextRPG
{
    public class Item
    {        // 아이템 기본 클래스
        public string Name { get; set; }             // 아이템 이름
        public string Description { get; set; }      // 아이템 설명
        public ItemType Type { get; set; }           // 아이템 유형
        public Job WeaponJob { get; set; }           // 직업무기 유형

        public ItemGrade Grade { get; set; }         // 아이템 등급
        public int AttackPower { get; set; }         // 공격력
        public int DefensePower { get; set; }        // 방어력
        public int HP { get; set; }                  // HP 증가
        public int MP { get; set; }                  // MP 증가
        public int Speed { get; set; }               // 속도
        public double CritChance { get; set; }       // 치명타 확률
        public int CritDamage { get; set; }          // 치명타 데미지
        public int Gold { get; set; }                // 판매 골드
        public bool isEquip { get; set; }            // 아이템 장착여부

        public Item()
        {
            Name = "";
            Description = "";

            Type = ItemType.None;
        }

        public Item(string name, string description, ItemType type, ItemGrade grade, Job weaponJob, int gold,
                     int attackPower, int defensePower, int hp, int mp, int speed, double critChance, int critDamage)
        {
            Name = name;
            Description = description;
            Type = type;
            WeaponJob = weaponJob;
            Grade = grade;
            Gold = gold;
            AttackPower = attackPower;
            DefensePower = defensePower;
            HP = hp;
            MP = mp;
            Speed = speed;
            CritChance = critChance;
            CritDamage = critDamage;
        }

        public override string ToString()
        {
            return $"아이템 이름: {Name}\n" +
                   $"아이템 설명: {Description}\n" +
                   $"아이템 유형: {Type}\n" +
                   $"공격력: {AttackPower}\n" +
                   $"방어력: {DefensePower}\n" +
                   $"HP 증가: {HP}\n" +
                   $"MP 증가: {MP}\n" +
                   $"속도: {Speed}\n" +
                   $"치명타 확률: {CritChance * 100}%\n" +
                   $"치명타 데미지: {CritDamage}\n";
        }
        // 아이템 목록 생성 메소드
        public static List<Item> CreateDefaultItems()
        {
            return new List<Item>
            {
                new Item("마나 회복 물약", "사용 시 마나를 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 0, 0, 50, 0, 0, 0),
                new Item("체력 회복 물약", "사용 시 체력을 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 0, 50, 0, 0, 0, 0),
                new Item("엘릭서", "사용 시 체력 100 마나를 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 0, 100, 50, 0, 0, 0),
                new Item("검", "기본 공격력 10 증가", ItemType.Weapon, ItemGrade.Common, Job.Warrior, 0, 10, 0, 0, 0, 0, 0.2, 20),
                new Item("단검", "기본 공격력 14 증가", ItemType.Weapon, ItemGrade.Common, Job.Thief, 0, 10, 0, 0, 0, 0, 0.5, 35),
                new Item("활", "기본 공격력 12 증가", ItemType.Weapon, ItemGrade.Common, Job.Archer, 0, 10, 0, 0, 0, 0, 0.3, 30),
                new Item("지팡이", "기본 공격력 13 증가", ItemType.Weapon, ItemGrade.Common, Job.Mage, 0, 10, 0, 0, 0, 0, 0.3, 25),
                new Item("강철 투구", "방어력 5 증가", ItemType.Head, ItemGrade.Common, Job.None, 0, 0, 0, 5, 0, 0, 0, 0),
                new Item("가죽 갑옷", "방어력 10 증가", ItemType.Top, ItemGrade.Common, Job.None, 0, 0, 10, 0, 0, 0, 0, 0),
                new Item("강철 바지", "방어력 7 증가", ItemType.Bottom, ItemGrade.Common, Job.None, 0, 0, 7, 0, 0, 0, 0, 0)
            };
         }
    }




    // 아이템 유형 정의
    public enum ItemType
    {
        None,    // 없음
        Potion,  // 물약
        Weapon,  // 무기
        Head,    // 머리 장비
        Top,     // 상의 장비
        Bottom   // 하의 장비
    }

    public enum ItemGrade
    {
        None,
        Common,
        Uncommon,
        Rare,
        Unique
    }
}
   