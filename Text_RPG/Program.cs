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

            ShowMsgOnBattle("Text RPG");
            ShowMsgOnBattle("환영합니다.");
            while(true)
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
            if ((messageListOnBattle.Count + 1) > (screenHeight - 3))
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
            if (File.Exists("./PlayerData.json")) return JsonConvert.DeserializeObject<Player>(File.ReadAllText("./PlayerData.json"));
            else return new Player();
        }

    }
}