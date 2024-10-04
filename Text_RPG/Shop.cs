namespace TextRPG
{
    public static class Shop
    {
        static Database shopItem = new Database();

        static List<Item> equipmentShopWeapon = new List<Item>();
        static List<Item> equipmentShopArmor = new List<Item>();
        static List<Item> potionShop = new List<Item>();

        public static void UpdateShopItem()
        {
            for (int i = 0; i < shopItem.ITEM.Count; i++)
            {
                if (shopItem.ITEM[i].Grade != ItemGrade.Unique)
                {
                    if (shopItem.ITEM[i].Type != ItemType.None)
                    {
                        if (shopItem.ITEM[i].Type != ItemType.Potion)
                        {

                            if (shopItem.ITEM[i].Type != ItemType.Weapon)
                            {
                                equipmentShopArmor.Add(shopItem.ITEM[i]);
                            }
                            else
                            {
                                equipmentShopWeapon.Add(shopItem.ITEM[i]);
                            }
                        }
                        else
                        {
                            potionShop.Add(shopItem.ITEM[i]);
                        }
                    }
                }
            }
        }

        public static void EnterShop(ref Player _player) // 상점가
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점가에 오신 것을 환영합니다.");
                Console.WriteLine("어느 상점으로 이동하시겠습니까?\n");

                Console.WriteLine("0. 상점가 나가기");
                Console.WriteLine("1. 대장간으로 이동");
                Console.WriteLine("2. 포션 상점으로 이동");
                Console.WriteLine("3. 선술집으로 이동\n");

                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력 : ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0) // 메뉴창으로 나가기
                        {
                            Town.EnterTown(ref _player);
                        }
                        else if (select == 1) // 대장간으로 이동
                        {
                            Blacksmith(ref _player);
                        }
                        else if (select == 2) // 포션 상점으로 이동
                        {
                            PotionStore(ref _player);
                        }
                        else if (select == 3) // 선술집으로 이동
                        {
                            Tavern(ref _player);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }

        public static void Blacksmith(ref Player _player) // 대장간
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("대장간에 온걸 환영하네. 여러 장비들 구경하고 가게나.\n");

                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                equipmentShopWeapon.Clear();
                equipmentShopArmor.Clear();
                UpdateShopItem();

                Console.WriteLine("[ 무기류 ]\n");
                for (int i = 0; i < equipmentShopWeapon.Count; i++)
                {
                    if (equipmentShopWeapon[i].Type == ItemType.Weapon)
                    {
                        Console.WriteLine($"- {equipmentShopWeapon[i].Name}      {equipmentShopWeapon[i].Description}    {equipmentShopWeapon[i].Gold}G");
                    }
                }

                Console.WriteLine("\n[ 방어구류 ]\n");
                for (int i = 0; i < equipmentShopArmor.Count; i++) 
                {
                    if (equipmentShopArmor[i].Type != ItemType.Weapon)
                    {
                        Console.WriteLine($"- {equipmentShopArmor[i].Name}      {equipmentShopArmor[i].Description}    {equipmentShopArmor[i].Gold}G");
                    }
                }

                Console.WriteLine("\n0. 대장간 나가기");
                Console.WriteLine("1. 무기 구매");
                Console.WriteLine("2. 방어구 구매");
                Console.WriteLine("3. 보유 아이템 판매\n");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력 : ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0) // 상점가로 나가기
                        {
                            EnterShop(ref _player);
                        }
                        else if (select == 1) // 무기 구매화면으로 이동
                        {
                            BlacksmithWeapon(ref _player);
                        }
                        else if (select == 2) // 방어구 구매화면으로 이동
                        {
                            BlacksmithArmor(ref _player);
                        }
                        else if (select == 3) // 보유 아이템 판매창으로 이동
                        {
                            ItemSellMenu(ref _player);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }
        public static void BlacksmithWeapon(ref Player _player) // 무기 구매창
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 무기 구매 ]");
                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                Console.WriteLine("[ 무기 목록 ]\n");
                for (int i = 0; i < equipmentShopWeapon.Count; i++)
                {
                    if (equipmentShopWeapon[i].Type == ItemType.Weapon)
                    {
                        Console.WriteLine($"{i + 1}. {equipmentShopWeapon[i].Name}      {equipmentShopWeapon[i].Description}    {equipmentShopWeapon[i].Gold}G");
                    }
                }
                Console.WriteLine("\n0. 대장간 목록으로");
                Console.WriteLine("\n구매하실 아이템 번호나 다음 행동을 입력해주세요.");
                Console.Write("입력 :  ");

                int select;
                while (true) 
                {
                    if (int.TryParse(Console.ReadLine(), out select) &&
                       select >= 0 && select <= equipmentShopWeapon.Count)
                    {
                        if (select == 0)
                        {
                            Blacksmith(ref _player);
                        }
                        else if (select >= 0 && select <= equipmentShopWeapon.Count)
                        {
                            if (_player.Gold >= equipmentShopWeapon[select - 1].Gold)
                            {
                                _player.Gold -= equipmentShopWeapon[select - 1].Gold;
                                _player.inventory.itemList.Add(equipmentShopWeapon[select - 1]);
                                Console.WriteLine("구매를 완료했습니다.");
                                Console.Write("입력: ");
                            }
                            else // 골드부족
                            {
                                Console.WriteLine("골드가 부족합니다");
                                Console.Write("입력: ");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                        Console.Write("입력: ");
                    }
                }
            }
        }
        public static void BlacksmithArmor(ref Player _player) // 방어구 구매창
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 방어구 구매 ]");
                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                equipmentShopArmor.Clear();
                UpdateShopItem();

                Console.WriteLine("[ 방어구 목록 ]\n");
                for (int i = 0; i < equipmentShopArmor.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {equipmentShopArmor[i].Name}     {equipmentShopArmor[i].Description}    {equipmentShopArmor[i].Gold}G");
                }
                Console.WriteLine("\n0. 대장간 목록으로");
                Console.WriteLine("\n구매하실 아이템 번호나 다음 행동을 입력해주세요.");
                Console.Write("입력 :  ");

                int select;
                while (true)
                if (int.TryParse(Console.ReadLine(), out select) &&
                    select >= 0 && select <= equipmentShopArmor.Count)
                {
                    if (select == 0)
                    {
                        Blacksmith(ref _player);
                        break;
                    }
                    else if (select > 0 && select <= equipmentShopArmor.Count)
                    {
                        if (_player.Gold >= equipmentShopArmor[select - 1].Gold)
                        {
                            _player.Gold -= equipmentShopArmor[select - 1].Gold;
                            _player.inventory.itemList.Add(equipmentShopArmor[select - 1]);
                            Console.WriteLine("구매를 완료했습니다.");
                            Console.Write("입력: ");
                        }
                        else // 골드부족
                        {
                            Console.WriteLine("골드가 부족합니다");
                            Console.Write("입력: ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    Console.Write("입력: ");
                }
            }
        }
        public static void ItemSellMenu(ref Player _player) // 장비/포션 판매창
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("판매가는 기존 아이템 가격의 70% 입니다.\n");
                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                Console.WriteLine("[ 장비 목록 ]");
                for (int i = 0; i < _player.inventory.itemList.Count; i++)
                {
                    if (_player.inventory.itemList[i].Type != ItemType.Potion)
                    {
                        Console.WriteLine($"- {_player.inventory.itemList[i]}");
                    }
                }

                Console.WriteLine("\n[ 포션 목록 ]");
                for (int i = 0; i < _player.inventory.itemList.Count; i++)
                {
                    if (_player.inventory.itemList[i].Type == ItemType.Potion)
                    {
                        Console.WriteLine($"- {_player.inventory.itemList[i]}");
                    }
                }

                Console.WriteLine("\n0. 상점가로 이동");
                Console.WriteLine("1. 판매하기");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력 : ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0) // 뒤로 가기
                        {
                            EnterShop(ref _player);
                        }
                        else if (select == 1) // 아이템 판매로 이동
                        {
                            SellItem(ref _player);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }

        public static void SellItem(ref Player _player) // 아이템 판매 메뉴
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 아이템 목록 ]");
                for (int i = 0; i < _player.inventory.itemList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_player.inventory.itemList[i]}");
                }

                Console.WriteLine("\n0. 뒤로 가기");
                Console.WriteLine("\n판매하실 아이템 번호나 다음 행동을 입력해주세요. 판매가는 원가의 70%입니다.");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력 : ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0)
                        {
                            ItemSellMenu(ref _player);
                        }
                        else if (select >= 1 && select <= _player.inventory.itemList.Count)
                        {
                            _player.Gold += (int)(_player.inventory.itemList[select - 1].Gold * 0.7);  // 상점가의 70%
                            _player.inventory.itemList.RemoveAt(select - 1);
                            Console.WriteLine("아이템 판매가 완료되었습니다.");
                            Console.Write("입력: ");
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }
        public static void PotionStore(ref Player _player) // 포션상점
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("포션 상점에 어서오세요! 많이 구경하고 가세요!\n");

                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                potionShop.Clear();
                UpdateShopItem();

                Console.WriteLine("[ 포션 목록 ]\n");
                for (int i = 0; i < potionShop.Count; i++)
                {
                    Console.WriteLine($"- {potionShop[i].Name}      {potionShop[i].Description}    {potionShop[i].Gold}G");
                }

                Console.WriteLine("\n0. 포션 상점 나가기");
                Console.WriteLine("1. 포션 구매");
                Console.WriteLine("2. 보유 아이템 판매\n");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력: ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0) // 상점가로 나가기
                        {
                            EnterShop(ref _player);
                        }
                        else if (select == 1) // 포션 구매화면으로 이동
                        {
                            PotionBuyMenu(ref _player);
                        }
                        else if (select == 2) // 보유 아이템 판매창으로 이동
                        {
                            ItemSellMenu(ref _player);
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }

        public static void PotionBuyMenu(ref Player _player) // 포션 구매 메뉴
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[ 포션 구매 ]");
                Console.WriteLine($"{_player.Name}의 소지 골드 : {_player.Gold}G\n");

                Console.WriteLine("[ 포션 목록 ]\n");
                for (int i = 0; i < potionShop.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {potionShop[i].Name}     {potionShop[i].Description}    {potionShop[i].Gold}G");
                }
                Console.WriteLine("\n0. 포션 상점으로");
                Console.WriteLine("\n구매하실 아이템 번호를 입력해주세요");
                Console.Write("입력 : ");

                int select;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select >= 0 && select <= potionShop.Count)
                        {
                            if (select == 0)
                            {
                                PotionStore(ref _player);
                            }
                            else if (select > 0 && select <= potionShop.Count)
                            {
                                if (_player.Gold >= potionShop[select - 1].Gold)
                                {
                                    _player.Gold -= potionShop[select - 1].Gold;
                                    _player.inventory.itemList.Add(potionShop[select - 1]);
                                    Console.WriteLine("구매를 완료했습니다.");
                                    Console.Write("입력: ");
                                }
                                else // 골드부족
                                {
                                    Console.WriteLine("골드가 부족합니다");
                                    Console.Write("입력: ");
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                                Console.Write("입력: ");
                            }
                        }
                    }
                }
            }
        }

        public static void Tavern(ref Player _player) // 선술집
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("선술집에 오신 것을 환영합니다. 마음껏 쉬다 가세요!\n");

                Console.WriteLine("500G을 내면 체력을 회복할 수 있습니다.  (보유 골드 : " + _player.Gold + " G)");
                Console.WriteLine($"{_player.Name}의 현재 체력 = {_player.HP}    |   최대 체력 = {_player.MaxHP}\n");

                Console.WriteLine("0. 선술집 나가기");
                Console.WriteLine("1. 휴식하기\n");
                Console.WriteLine("다음 행동을 선택해주세요.");
                Console.Write("입력 : ");

                int select = 0;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out select))
                    {
                        if (select == 0)
                        {
                            EnterShop(ref _player); // 메인 화면으로 이동
                        }
                        else if (select == 1)
                        {
                            if (_player.Gold >= 500)
                            {
                                if (_player.HP == _player.MaxHP) // 캐릭터의 체력이 꽉차있을시
                                {
                                    Console.WriteLine($"이미 {_player.Name}의 상태는 완벽합니다");
                                    Console.Write("입력: ");
                                }
                                else // 캐릭터의 체력이 안 꽉차있을시
                                {
                                    _player.HP = _player.MaxHP;
                                    _player.Gold -= 500;
                                    Console.WriteLine("선술집에서 휴식을 완료했습니다.     ( 소지 골드 -500G ) ");
                                    Console.Write("입력: ");
                                }
                            }
                            else // 골드 부족
                            {
                                Console.WriteLine("소유한 골드가 부족합니다.");
                                Console.Write("입력: ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.Write("입력: ");
                        }
                    }
                }
            }
        }
    }
}
