using System.Reflection.Metadata.Ecma335;

namespace TextRPG
{
    public enum ClassType { None, Warrior, Rogue, Mage };

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
        }

        public static void EnterTown(ref Player _player)
        {
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