using System.Reflection.Metadata.Ecma335;

namespace TextRPG
{
    internal class Program
    {

        static void Main()
        {
            Player player = new Player();

            EnterTutorial(ref player);
            EnterTown(ref player);
        }

        public static void EnterTutorial(ref Player _player)
        {
            //이름 정하는 내용 
            //클래스 정하는 내용
        }

        public static void EnterTown(ref Player _player)
        {
            while(true)
            {
            }
        }

        public static void EnterDungeon(ref Player _player)
        {
            while(true)
            {
            }
        }

        public static void SetStatus(ref Player _player, ClassType _classType)
        {
            _player.classType = _classType;
            while (true)
            {

                if (_player.classType == ClassType.None)
                {
                    break;
                }
                else
                {
                    switch (_player.classType)
                    {
                        case ClassType.None:

                            break;

                        case ClassType.Warrior:

                            break;

                        case ClassType.Rogue:

                            break;

                        case ClassType.Mage:

                            break;
                    }
                }
            }    
        }

    }
}