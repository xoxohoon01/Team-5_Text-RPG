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

        public void InitItemDatabase() // 이름, 설명, 타입, 공격력, 방어력, hp, mp, 속도, 크리확률, 크리데미지
        {
            ITEM.Add(new Item());
            // 포션
            ITEM.Add(new Item("체력 회복 물약", "사용 시 체력을 50 회복", ItemType.Potion, 0, 0, 50, 0, 0, 0, 0));
            ITEM.Add(new Item("마나 회복 물약", "사용 시 마나를 50 회복", ItemType.Potion, 0, 0, 0, 50, 0, 0, 0));
            ITEM.Add(new Item("엘릭서", "사용 시 체력 100 마나를 50 회복", ItemType.Potion, 0, 0, 100, 50, 0, 0, 0));
            // 기본무기
            ITEM.Add(new Item("검", "평범한 검이다.", ItemType.Weapon, 10, 0, 0, 0, 0, 0.2, 20));
            ITEM.Add(new Item("단검", "평범한 단검이다.", ItemType.Weapon, 10, 0, 0, 0, 0, 0.5, 35));
            ITEM.Add(new Item("활", "평범한 활이다.", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 30));
            ITEM.Add(new Item("지팡이", "평범한 지팡이다.", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 25));
            // 검류
            ITEM.Add(new Item("본 크래셔", "맞으면 뼈도 못 추릴 망치이다.", ItemType.Weapon, 30, 0, 15, 0, 0, 0, 0));
            ITEM.Add(new Item("무쇠 대검", "무겁고 날카로운 대검.", ItemType.Weapon, 50, 0, 20, 0, 7, 0, 0));
            ITEM.Add(new Item("드래곤 슬레이어", "용을 잡았다는 한손검.", ItemType.Weapon, 90, 0, 30, 0, 10, 0, 0));
            ITEM.Add(new Item("엑스칼리버", "전설의 그 대검.", ItemType.Weapon, 1000, 0, 50, 0, 30, 0, 0));
            // 단검류
            ITEM.Add(new Item("비도", "던지는 용인데..", ItemType.Weapon, 40, 0, 0, 0, 4, 12, 0));
            ITEM.Add(new Item("장미칼", "절삭력이 대단하다.", ItemType.Weapon, 60, 0, 0, 0, 7, 17, 0));
            ITEM.Add(new Item("단 검", "꿀처럼 달다.", ItemType.Weapon, 100, 0, 0, 0, 10, 25, 0));
            ITEM.Add(new Item("시그룬의 단검", "발키리 영웅의 파트너.", ItemType.Weapon, 1100, 0, 0, 0, 30, 40, 0));
            // 활류
            ITEM.Add(new Item("단궁", "최종병기 활.", ItemType.Weapon, 30, 0, 0, 0, 6, 0, 0));
            ITEM.Add(new Item("컴파운드 보우", "대한민국 양궁 파이팅.", ItemType.Weapon, 50, 0, 0, 0, 10, 0, 0));
            ITEM.Add(new Item("세계수목 대궁", "세계수를 깎아만든 대궁.", ItemType.Weapon, 100, 0, 0, 0, 15, 0, 0));
            ITEM.Add(new Item("아폴론의 활", "하프처럼 생겼다.", ItemType.Weapon, 1000, 0, 0, 0, 40, 0, 0));
            // 지팡이류
            ITEM.Add(new Item("나뭇가지", "누군가 마력을 넣어놨다.", ItemType.Weapon, 30, 0, 0, 30, 3, 0, 0));
            ITEM.Add(new Item("효자손", "누군가 마력을 많이 넣어놨다.", ItemType.Weapon, 50, 0, 0, 50, 5, 0, 0));
            ITEM.Add(new Item("딱총나무 지팡이", "읭가르디움 레비오우 싸.", ItemType.Weapon, 100, 0, 0, 100, 10, 0, 0));
            ITEM.Add(new Item("네크로노미콘", "악마의 책이 말을 건넨다. 시끄럽다.", ItemType.Weapon, 1000, 0, 0, 200, 20, 0, 0));
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
   