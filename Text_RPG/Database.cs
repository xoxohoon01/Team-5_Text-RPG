using Newtonsoft.Json;

namespace TextRPG
{
    public class Database
    {
        //Program.cs에서 Main 맨 위에서 Database 인스턴스화 시켜줄 것

        public List<Item> ITEM = new List<Item>();
        public Player PLAYER = new Player();

        public Database()
        {
            InitItemDatabase();
        }

        public void InitItemDatabase() // 이름, 설명, 타입, 등급, 직업, 공격력, 방어력, hp, mp, 속도, 크리확률, 크리데미지
        {
            ITEM.Add(new Item());
            // 포션
            ITEM.Add(new Item("체력 회복 물약", "사용 시 체력을 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 50, 0, 0, 0, 0));
            ITEM.Add(new Item("마나 회복 물약", "사용 시 마나를 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 0, 50, 0, 0, 0));
            ITEM.Add(new Item("엘릭서", "사용 시 체력 100 마나를 50 회복", ItemType.Potion, ItemGrade.None, Job.None, 0, 0, 100, 50, 0, 0, 0));
            // 기본무기
            ITEM.Add(new Item("검", "평범한 검이다.", ItemType.Weapon, ItemGrade.Common, Job.Warrior, 10, 0, 0, 0, 0, 0.2, 20));
            ITEM.Add(new Item("단검", "평범한 단검이다.", ItemType.Weapon, ItemGrade.Common, Job.Thief, 10, 0, 0, 0, 0, 0.5, 35));
            ITEM.Add(new Item("활", "평범한 활이다.", ItemType.Weapon, ItemGrade.Common, Job.Archer, 10, 0, 0, 0, 0, 0.3, 30));
            ITEM.Add(new Item("지팡이", "평범한 지팡이다.", ItemType.Weapon, ItemGrade.Common, Job.Mage, 10, 0, 0, 0, 0, 0.3, 25));
            // 검류
            ITEM.Add(new Item("본 크래셔", "맞으면 뼈도 못 추릴 망치이다.", ItemType.Weapon, ItemGrade.Common, Job.Warrior, 30, 0, 15, 0, 0, 0, 0));
            ITEM.Add(new Item("무쇠 대검", "무겁고 날카로운 대검.", ItemType.Weapon, ItemGrade.Uncommon, Job.Warrior, 50, 0, 20, 0, 7, 0, 0));
            ITEM.Add(new Item("드래곤 슬레이어", "용을 잡았다는 한손검.", ItemType.Weapon, ItemGrade.Rare, Job.Warrior, 90, 0, 30, 0, 10, 0, 0));
            ITEM.Add(new Item("엑스칼리버", "전설의 그 대검.", ItemType.Weapon, ItemGrade.Unique, Job.Warrior, 1000, 0, 50, 0, 30, 0, 0));
            // 단검류
            ITEM.Add(new Item("비도", "던지는 용인데..", ItemType.Weapon, ItemGrade.Common, Job.Thief, 40, 0, 0, 0, 4, 12, 0));
            ITEM.Add(new Item("장미칼", "절삭력이 대단하다.", ItemType.Weapon, ItemGrade.Uncommon, Job.Thief, 60, 0, 0, 0, 7, 17, 0));
            ITEM.Add(new Item("단 검", "꿀처럼 달다.", ItemType.Weapon, ItemGrade.Rare, Job.Thief, 100, 0, 0, 0, 10, 25, 0));
            ITEM.Add(new Item("시그룬의 단검", "발키리 영웅의 파트너.", ItemType.Weapon, ItemGrade.Unique, Job.Thief, 1100, 0, 0, 0, 30, 40, 0));
            // 활류
            ITEM.Add(new Item("단궁", "최종병기 활.", ItemType.Weapon, ItemGrade.Common, Job.Archer, 30, 0, 0, 0, 6, 0, 0));
            ITEM.Add(new Item("컴파운드 보우", "대한민국 양궁 파이팅.", ItemType.Weapon, ItemGrade.Uncommon, Job.Archer, 50, 0, 0, 0, 10, 0, 0));
            ITEM.Add(new Item("세계수목 대궁", "세계수를 깎아만든 대궁.", ItemType.Weapon, ItemGrade.Rare, Job.Archer, 100, 0, 0, 0, 15, 0, 0));
            ITEM.Add(new Item("아폴론의 활", "하프처럼 생겼다.", ItemType.Weapon, ItemGrade.Unique, Job.Archer, 1000, 0, 0, 0, 40, 0, 0));
            // 지팡이류
            ITEM.Add(new Item("나뭇가지", "누군가 마력을 넣어놨다.", ItemType.Weapon, ItemGrade.Common, Job.Mage, 30, 0, 0, 30, 3, 0, 0));
            ITEM.Add(new Item("효자손", "누군가 마력을 많이 넣어놨다.", ItemType.Weapon, ItemGrade.Uncommon, Job.Mage, 50, 0, 0, 50, 5, 0, 0));
            ITEM.Add(new Item("딱총나무 지팡이", "읭가르디움 레비오우 싸.", ItemType.Weapon, ItemGrade.Rare, Job.Mage, 100, 0, 0, 100, 10, 0, 0));
            ITEM.Add(new Item("네크로노미콘", "악마의 책이 말을 건넨다. 시끄럽다.", ItemType.Weapon, ItemGrade.Unique, Job.Mage, 1000, 0, 0, 200, 20, 0, 0));
            // 머리 방어구류
            ITEM.Add(new Item("가죽 모자", "대부분 모험가들의 모자다.", ItemType.Head, ItemGrade.Common, Job.None, 0, 5, 10, 0, 0, 0, 0));
            ITEM.Add(new Item("강철 투구", "머리가 안전해 보이긴하다.", ItemType.Head, ItemGrade.Uncommon, Job.None, 0, 10, 20, 0, 0, 0, 0));
            ITEM.Add(new Item("황실 정예 투구", "군 대장들이 쓰던 투구", ItemType.Head, ItemGrade.Rare, Job.None, 0, 25, 50, 0, 3, 0, 0));
            ITEM.Add(new Item("엘룬의 투구", "엘룬의 가호가 깃든 신비한 투구", ItemType.Head, ItemGrade.Unique, Job.None, 0, 250, 350, 100, 10, 0, 0));
            // 상의 방어구류
            ITEM.Add(new Item("가죽 갑옷", "모험가들의 모나미룩", ItemType.Top, ItemGrade.Common, Job.None, 0, 10, 20, 0, 0, 0, 0));
            ITEM.Add(new Item("강철 갑옷 상의", "쉽게 뚫리진 않을것같다.", ItemType.Top, ItemGrade.Uncommon, Job.None, 0, 20, 40, 0, 0, 0, 0));
            ITEM.Add(new Item("황실 정예 갑옷", "문양에서 위엄이 느껴진다.", ItemType.Top, ItemGrade.Rare, Job.None, 0, 40, 100, 0, 3, 0, 0));
            ITEM.Add(new Item("엘룬의 갑옷", "엘룬의 가호가 느껴지는 신비한 갑옷", ItemType.Top, ItemGrade.Unique, Job.None, 0, 400, 500, 200, 10, 0, 0));
            // 하의 방어구류
            ITEM.Add(new Item("가죽 하의", "의외로 통풍이 잘된다.", ItemType.Bottom, ItemGrade.Common, Job.None, 0, 5, 10, 0, 0, 0, 0));
            ITEM.Add(new Item("강철 갑옷 하의", "가볍진 않지만 든든하다.", ItemType.Bottom, ItemGrade.Uncommon, Job.None, 0, 10, 20, 0, 0, 0, 0));
            ITEM.Add(new Item("황실 정예 바지", "황실의 기운이 다가온다.", ItemType.Bottom, ItemGrade.Rare, Job.None, 0, 25, 50, 0, 3, 0, 0));
            ITEM.Add(new Item("엘룬의 바지", "엘룬의 가호가 주위에 나타난다.", ItemType.Bottom, ItemGrade.Unique, Job.None, 0, 250, 350, 100, 10, 0, 0));
        }

        public void SaveDatabase()
        {
            string content = JsonConvert.SerializeObject(PLAYER);
            File.WriteAllText("/UserData.json", content);
        }

        public void LoadDatabase()
        {
            if (File.Exists("/userData.json"))
            {
                PLAYER = JsonConvert.DeserializeObject<Player>(File.ReadAllText("/UserData.json"));
            }
        }
    }
}
   