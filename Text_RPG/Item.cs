namespace TextRPG
{
    public class Item
    {        // 아이템 기본 클래스
        public string Name { get; set; }             // 아이템 이름
        public string Description { get; set; }      // 아이템 설명
        public ItemType Type { get; set; }           // 아이템 유형
        public int AttackPower { get; set; }         // 공격력
        public int DefensePower { get; set; }        // 방어력
        public int HP { get; set; }                  // HP 증가
        public int MP { get; set; }                  // MP 증가
        public int Speed { get; set; }               // 속도
        public double CritChance { get; set; }       // 치명타 확률
        public int CritDamage { get; set; }          // 치명타 데미지            

        public bool isEquip { get; set; }

        public Item(string name = "", string description = "", ItemType type = ItemType.None, int attackPower = 0, int defensePower = 0, int hp = 0, int mp = 0, int speed = 0, double critChance = 0, int critDamage = 0)
        {
            Name = name;
            Description = description;
            Type = type;
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
                new Item("체력 회복 물약", "사용 시 체력을 50 회복", ItemType.Potion, 0, 0, 50, 0, 0, 0, 0),
                new Item("마나 회복 물약", "사용 시 마나를 50 회복", ItemType.Potion, 0, 0, 0, 50, 0, 0, 0),
                new Item("엘릭서", "사용 시 체력 100 마나를 50 회복", ItemType.Potion, 0, 0, 100, 50, 0, 0, 0),
                new Item("검", "기본 공격력 10 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.2, 20),
                new Item("단검", "기본 공격력 14 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.5, 35),
                new Item("활", "기본 공격력 12 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 30),
                new Item("지팡이", "기본 공격력 13 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 25),
                new Item("강철 투구", "방어력 5 증가", ItemType.Head, 0, 5, 0, 0, 0, 0, 0),
                new Item("가죽 갑옷", "방어력 10 증가", ItemType.Top, 0, 10, 0, 0, 0, 0, 0),
                new Item("강철 바지", "방어력 7 증가", ItemType.Bottom, 0, 7, 0, 0, 0, 0, 0)
                new Item("검", "기본 공격력 20, 크리티컬 확률 2, 크리티컬 데미지 15 증가", ItemType.Weapon, 20, 0, 0, 0, 0, 0.2, 15),
                new Item("강철 검", "기본 공격력 25, 크리티컬 확률 3, 크리티컬 데미지 20 증가", ItemType.Weapon, 25, 0, 0, 0, 0, 0.3, 20),
                new Item("단검", "기본 공격력 35,크리티컬 확률 4, 크리티컬 데미지 30 증가", ItemType.Weapon, 30, 0, 0, 0, 0, 0.4, 30),
                new Item("강철 단검", "기본 공격력 35,크리티컬 확률 5, 크리티컬 데미지 35 증가", ItemType.Weapon, 35, 0, 0, 0, 0, 0.5, 35),
                new Item("활", "기본 공격력 25,크리티컬 확률 3, 크리티컬 데미지 20 증가", ItemType.Weapon, 25, 0, 0, 0, 0, 0.3, 20),
                new Item("단궁", "기본 공격력 20 크리티컬 확률 3, 크리티컬 데미지 30 증가", ItemType.Weapon, 20, 0, 0, 0, 10, 0.3, 30),
                new Item("장궁", "기본 공격력 30 크리티컬 확률 5, 크리티컬 데미지 35 증가", ItemType.Weapon, 30, 0, 0, 0, 0, 0.5, 35),
                new Item("지팡이", "기본 공격력 25 크리티컬 확률3, 크리티컬 데미지 20 증가", ItemType.Weapon, 25, 0, 0, 0, 0, 0.3, 20),
                new Item("고대 지팡이", "기본 공격력 35 크리티컬 확률5, 크리티컬 데미지 35 증가", ItemType.Weapon, 35, 0, 0, 0, 0, 0.5, 35),
                new Item("강철 투구", "방어력 10 증가", ItemType.Head, 0, 10, 0, 0, 0, 0, 0),
                new Item("미스릴 투구", "방어력 15 증가", ItemType.Head, 0, 15, 0, 0, 0, 0, 0),
                new Item("가죽 갑옷", "방어력 5, 스피드 5 증가", ItemType.Top, 0, 5, 0, 0, 5, 0, 0),
                new Item("미스릴 갑옷", "방어력 20 증가", ItemType.Top, 0, 20, 0, 0, 5, 0, 0),
                new Item("강철 바지", "방어력 7 증가", ItemType.Bottom, 0, 7, 0, 0, 0, 0, 0),          
                new Item("미스릴 바지", "방어력 17 증가", ItemType.Bottom, 0, 17, 0, 0, 0, 0, 0)          
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
        Top,   // 상의 장비
        Bottom    // 하의 장비
    }
}
   