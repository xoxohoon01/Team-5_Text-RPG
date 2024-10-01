using Microsoft.VisualBasic;
using System;
using System.Numerics;
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
        public static void Main()
        {
            Database database = new Database();
            Player player = new Player();

            Tutorial.EnterTutorial(ref player);
            Town.EnterTown(ref player);
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
            string[] contents = content.Split("\n");
            if ((messageListOnBattle.Count + contents.Length) > (screenHeight - 3))
            {
                messageListOnBattle.RemoveRange(0, (messageListOnBattle.Count + contents.Length) - (screenHeight - 3));
            }

            foreach(string line in contents)
            {
                for (int i = 0; i < messageListOnBattle.Count; i++)
                {
                    messageListOnBattle[i].y -= 1;
                }
                Message newMessage = new Message(line);
                messageListOnBattle.Add(newMessage);
            }

            for (int i = 0; i < messageListOnBattle.Count; i++)
            {
                int byteLength = System.Text.Encoding.Default.GetByteCount(content);
                int sizeOfContent = content.Length + ((byteLength - content.Length) / 2);

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
        
    }
}