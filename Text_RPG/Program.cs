using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace TextRPG
{
    internal class Program
    {
        public static List<Message> messageListOnBattle = new List<Message>();
        public static Random random = new Random();         //Random 객체 생성
        public static int screenWidth = 64;
        public static int screenHeight = 14;
        public static bool hasPlayer = false;

        public static void Main()
        {
            Database database = new Database();
            Player player = LoadPlayerData();

            DrawBox();
            messageListOnBattle.Clear();
            ShowMsgOnBattle("Text RPG");
            ShowMsgOnBattle("환영합니다.");
            ShowMsgOnBattle("");
            ShowMsgOnBattle("");
            ShowMsgOnBattle("");
            ShowMsgOnBattle("");

            Console.WriteLine("게속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();

            while (true)
            {
                player = LoadPlayerData();
                
                if (hasPlayer == false)
                {
                    Tutorial.EnterTutorial(ref player);
                    hasPlayer = true;
                }
                else
                {
                    Town.EnterTown(ref player);
                }
            }
        }

        public static void DrawBox()
        {
            Console.Clear();

            for (int i = 0; i <= screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, screenHeight);
                Console.Write("#");
            }
            for (int i = 0; i <= screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(screenWidth, i);
                Console.Write("#");
            }
        }

        public static void ShowMsgOnBattle(string content)
        {
            DrawBox();

            if ((messageListOnBattle.Count + 1) > (screenHeight - 6))
            {
                messageListOnBattle.RemoveAt(0);
            }

            for (int i = 0; i < messageListOnBattle.Count; i++)
            {
                messageListOnBattle[i].y -= 1;
            }
            Message newMessage = new Message(content);
            messageListOnBattle.Add(newMessage);

            for (int i = 0; i < messageListOnBattle.Count; i++)
            {
                int byteLength = System.Text.Encoding.Default.GetByteCount(messageListOnBattle[i].content);
                int sizeOfContent = messageListOnBattle[i].content.Length + ((byteLength - messageListOnBattle[i].content.Length) / 2);

                Console.SetCursorPosition((screenWidth / 2 - sizeOfContent / 2), (screenHeight - 2) + messageListOnBattle[i].y);
                Console.Write(messageListOnBattle[i].content);
            }
            
            Console.SetCursorPosition(0, screenHeight + 1);
        }

        public static void ShowMsgOnBattle()
        {
            DrawBox();

            for (int i = 0; i < messageListOnBattle.Count; i++)
            {
                int byteLength = System.Text.Encoding.Default.GetByteCount(messageListOnBattle[i].content);
                int sizeOfContent = messageListOnBattle[i].content.Length + ((byteLength - messageListOnBattle[i].content.Length) / 2);

                Console.SetCursorPosition((screenWidth / 2 - sizeOfContent / 2), (screenHeight - 2) + messageListOnBattle[i].y);
                Console.Write(messageListOnBattle[i].content);
            }

            Console.SetCursorPosition(0, screenHeight + 1);
        }

        public static void ShowStatusOnBattle(ref Player _player)
        {
            int byteLength = System.Text.Encoding.Default.GetByteCount(_player.Name);
            int sizeOfContent = _player.Name.Length + ((byteLength - _player.Name.Length) / 2);
            Console.SetCursorPosition((8 - sizeOfContent / 2), 2);
            Console.Write($"{_player.Name}");

            string hp = $"{_player.HP}/{_player.MaxHP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(hp);
            sizeOfContent = hp.Length + ((byteLength - hp.Length) / 2);
            Console.SetCursorPosition(4, 3);
            Console.Write("HP: " + hp);

            string mp = $"{_player.MP}/{_player.MaxMP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(mp);
            sizeOfContent = mp.Length + ((byteLength - mp.Length) / 2);
            Console.SetCursorPosition(4, 4);
            Console.Write("MP: " + mp);

            Console.SetCursorPosition(0, screenHeight + 1);
        }

        public static void ShowStatusOnBattle(ref Player _player, ref Monster _monster)
        {
            int byteLength = System.Text.Encoding.Default.GetByteCount(_player.Name);
            int sizeOfContent = _player.Name.Length + ((byteLength - _player.Name.Length) / 2);
            Console.SetCursorPosition((8 - sizeOfContent / 2), 2);
            Console.Write($"{_player.Name}");

            string hp = $"{_player.HP}/{_player.MaxHP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(hp);
            sizeOfContent = hp.Length + ((byteLength - hp.Length) / 2);
            Console.SetCursorPosition(4, 3);
            Console.Write("HP: " + hp);

            string mp = $"{_player.MP}/{_player.MaxMP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(mp);
            sizeOfContent = mp.Length + ((byteLength - mp.Length) / 2);
            Console.SetCursorPosition(4, 4);
            Console.Write("MP: " + mp);


            byteLength = System.Text.Encoding.Default.GetByteCount(_monster.Name);
            sizeOfContent = _monster.Name.Length + ((byteLength - _monster.Name.Length) / 2);
            Console.SetCursorPosition(((screenWidth - 9) - (sizeOfContent / 2)), 2);
            Console.Write($"{_monster.Name}");

            hp = $"{_monster.HP}/{_monster.MaxHP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(hp);
            sizeOfContent = hp.Length + ((byteLength - hp.Length) / 2);
            Console.SetCursorPosition(screenWidth - 13, 3);
            Console.Write("HP: " + hp);

            mp = $"{_monster.MP}/{_monster.MaxMP}";
            byteLength = System.Text.Encoding.Default.GetByteCount(mp);
            sizeOfContent = mp.Length + ((byteLength - mp.Length) / 2);
            Console.SetCursorPosition(screenWidth - 13, 4);
            Console.Write("MP: " + mp);

            Console.SetCursorPosition(0, screenHeight + 1);
        }

        public static void ShowMsgWrongValue()
        {
            Console.WriteLine("올바른 값을 입력하세요.");
            Console.WriteLine("계속하시려면 아무 키나 입력하세요.");
            Console.ReadKey();
        }
        
        public static void SavePlayerData(Player _player)
        {
            string content = JsonConvert.SerializeObject(_player, Formatting.Indented);
            File.WriteAllText("./PlayerData.json", content);
        }

        public static Player LoadPlayerData()
        {
            if (File.Exists("./PlayerData.json"))
            {
                hasPlayer = true;
                return JsonConvert.DeserializeObject<Player>(File.ReadAllText("./PlayerData.json"));
            }
            else
            {
                hasPlayer = false;
                return new Player();
            }
        }

    }
}