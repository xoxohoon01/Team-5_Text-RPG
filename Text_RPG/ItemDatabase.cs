using Newtonsoft.Json;

namespace TextRPG
{
    /*

     Program.cs에서 
     ItemDatabase 인스턴스를 만들고 
     직렬화 및 역직렬화로 저장 및 부러오기 구현할 것

     ItemDatabase itemDatabase = new ItemDatabase();
     public void LoadItemDatabase()
     {
         if (File.Exists("./ItemDatabase.json"))
         {
             itemDatabase = JsonConvert.DeserializeObject<ItemDatabase>(File.ReadAllText("./ItemDatabase.json"));
         }
         else
         {
             itemDatabase.ITEM.Add(new Item());
             SaveItemDatabase();
         }
     }
     public void SaveItemDatabase()
     {
         string content = JsonConvert.SerializeObject(itemDatabase, Formatting.Indented);
         File.WriteAllText("./ItemDatabase.json", content);
     }

     */
    public class ItemDatabase
    {
        public List<Item> ITEM = new List<Item>();
    }
}
   