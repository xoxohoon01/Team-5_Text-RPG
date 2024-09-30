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

        //데이터베이스 (Program.cs에서 메소드 호출할 것) (n줄 - 20이 아이템 번호)
        public void InitItemDatabase()
        {
            ITEM.Add(new Item());
            ITEM.Add(new Item("체력 회복 물약", "사용 시 체력을 50 회복", ItemType.Potion, 0, 0, 50, 0, 0, 0, 0));
            ITEM.Add(new Item("마나 회복 물약", "사용 시 마나를 50 회복", ItemType.Potion, 0, 0, 0, 50, 0, 0, 0));
            ITEM.Add(new Item("엘릭서", "사용 시 체력 100 마나를 50 회복", ItemType.Potion, 0, 0, 100, 50, 0, 0, 0));
            ITEM.Add(new Item("검", "평범한 검이다.", ItemType.Weapon, 10, 0, 0, 0, 0, 0.2, 20));
            ITEM.Add(new Item("단검", "기본 공격력 14 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.5, 35));
            ITEM.Add(new Item("활", "기본 공격력 12 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 30));
            ITEM.Add(new Item("지팡이", "기본 공격력 13 증가", ItemType.Weapon, 10, 0, 0, 0, 0, 0.3, 25));
            ITEM.Add(new Item("강철 투구", "방어력 5 증가", ItemType.Head, 0, 5, 0, 0, 0, 0, 0));
            ITEM.Add(new Item("가죽 갑옷", "방어력 10 증가", ItemType.Top, 0, 10, 0, 0, 0, 0, 0));
            ITEM.Add(new Item("강철 바지", "방어력 7 증가", ItemType.Bottom, 0, 7, 0, 0, 0, 0, 0));
        }

        //데이터 저장 (플레이어 데이터)
        public void SaveDatabase()
        {
            string content = JsonConvert.SerializeObject(PLAYER);
            File.WriteAllText("/UserData.json", content);
        }

        //데이터 불러오기 (플레이어 데이터)
        public void LoadDatabase()
        {
            if (File.Exists("/userData.json"))
            {
                PLAYER = JsonConvert.DeserializeObject<Player>(File.ReadAllText("/UserData.json"));
            }
        }
    }
}
   