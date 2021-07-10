using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkController : MonoBehaviour
{
    [SerializeField] Snake snake;
    [SerializeField] SnakeLength snakeLength;
    [SerializeField] MeshRenderer snakeMaterial;
    [SerializeField] SkillController skillController;
    [SerializeField] PerkChoose perkChoose;
    [SerializeField] OnDeath onDeath;

    private List<int> Levels = new List<int>();
    private int CurrentLevel = -1;

    private float count2;

    private void Start()
    {
        Levels.Add(-5);
        // Easy 4
        Levels.Add(1000);
        Levels.Add(2500);
        Levels.Add(5000);
        Levels.Add(7500);
        // Normal 8
        Levels.Add(15000);
        Levels.Add(20000);
        Levels.Add(25000);
        Levels.Add(30000);
        Levels.Add(35000);
        Levels.Add(40000);
        Levels.Add(45000);
        Levels.Add(50000);
        // Hard 12
        Levels.Add(56500);
        Levels.Add(61000);
        Levels.Add(65500);
        Levels.Add(70000);
        Levels.Add(74500);
        Levels.Add(79000);
        Levels.Add(83500);
        Levels.Add(88000);
        Levels.Add(92500);
        Levels.Add(97000);
        Levels.Add(101500);
        Levels.Add(110000);
    }

    private void Update()
    {
        if (snake.GetScore() > Levels[CurrentLevel + 1])
        {
            List<int> Accepted = new List<int>() { 0, 1, 2, 3, 5, 6, 7, 26, 11, 12, 13 };
            bool[] Activate = new bool[3] { false, false, false };
            int[] Randoms = new int[3];

            switch (PlayerPrefs.GetString("A"))
            {
                case "Fever":
                    Accepted.Add(8);
                    Accepted.Add(10);
                    Accepted.Add(19);
                    break;
                case "FeverReverse":
                    Accepted.Add(9);
                    Accepted.Add(10);
                    Accepted.Add(20);
                    break;
                case "TailGrowing":
                    // Null
                    break;
                case "FoodForChildren":
                    Accepted.Add(4);
                    Accepted.Add(21);
                    break;
                case "EliminateSpike":
                    Accepted.Add(14);
                    Accepted.Add(22);
                    Accepted.Add(27);
                    break;
                case "EatMeal":
                    Accepted.Add(15);
                    Accepted.Add(23);
                    break;
                case "Rabid":
                    Accepted.Add(16);
                    Accepted.Add(17);
                    Accepted.Add(24);
                    break;
                case "Tranquility":
                    Accepted.Add(18);
                    Accepted.Add(25);
                    break;
            }
            switch (PlayerPrefs.GetString("D"))
            {
                case "Fever":
                    Accepted.Add(8);
                    Accepted.Add(10);
                    Accepted.Add(19);
                    break;
                case "FeverReverse":
                    Accepted.Add(9);
                    Accepted.Add(10);
                    Accepted.Add(20);
                    break;
                case "TailGrowing":
                    // Null
                    break;
                case "FoodForChildren":
                    Accepted.Add(4);
                    Accepted.Add(21);
                    break;
                case "EliminateSpike":
                    Accepted.Add(14);
                    Accepted.Add(22);
                    Accepted.Add(27);
                    break;
                case "EatMeal":
                    Accepted.Add(15);
                    Accepted.Add(23);
                    break;
                case "Rabid":
                    Accepted.Add(16);
                    Accepted.Add(17);
                    Accepted.Add(24);
                    break;
                case "Tranquility":
                    Accepted.Add(18);
                    Accepted.Add(25);
                    break;
            }

            do
            {
                Activate[0] = false;
                Activate[1] = false;
                Activate[2] = false;

                for (int i = 0; i < Randoms.Length; i++)
                {
                    Randoms[i] = Random.Range(0, 28);

                    for (int a = 0; a < Accepted.Count; a++)
                    {
                        if (Randoms[i] == Accepted[a])
                        {
                            Activate[i] = true;
                        }
                    }
                }
            }
            while (!Activate[0] || !Activate[1] || !Activate[2]);

            CurrentLevel++;
            perkChoose.StartChoose(Randoms[0], Randoms[1], Randoms[2]);
        }
    }

    public void AddPerk(int Choosen)
    {
        switch (Choosen)
        {
            case 0:
                print("Рост +7");
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                snakeLength.AddTail(snakeMaterial.material);
                break;
            case 1:
                print("Кристаллы +15");
                snake.Crystals += 15;
                snake.SumCrystals += 15;
                break;
            case 2:
                print("Рост змейки раз в 180/160/140/120/100/80/60/40/20 секунд");
                count2++;

                if (count2 == 1) skillController.Full = 180;
                if (count2 == 2) skillController.Full = 160;
                if (count2 == 3) skillController.Full = 140;
                if (count2 == 4) skillController.Full = 120;
                if (count2 == 5) skillController.Full = 100;
                if (count2 == 6) skillController.Full = 80;
                if (count2 == 7) skillController.Full = 60;
                if (count2 == 8) skillController.Full = 40;
                if (count2 == 9) skillController.Full = 20;
                break;
            case 3:
                print("Бессмертие на полторы секунды в случае попытки смерти");
                onDeath.ShortImmortality.Add(1.5f);
                break;
            case 4:
                print("Бесплатная активация FoodForChildren");
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                skillController.AddCrystal();
                snakeLength.AddTail(snakeMaterial.material);
                skillController.ActivateFoodForChildren();
                break;
            case 5:
                print("-40 Скорости");
                snake.Speed -= 40;
                break;
            case 26:
                print("+30 Скорости");
                snake.Speed += 30;
                break;
            case 6:
                print("-50 скорости при замедлении");
                snake.Slower += 50;
                break;
            case 7:
                print("+50 скорости при ускорении");
                snake.Faster += 50;
                break;
            case 8:
                print("+1 секунда Fever");
                snake.FeverTimer += 1;
                break;
            case 9:
                print("+1 секунда FeverReverse");
                snake.FeverReverseTimer += 1;
                break;
            case 10:
                print("+0.5 секунд постбессмертия после способностей Fever и FeverReverse");
                snake.ImmortalityAddTimer += 0.5f;
                break;
            case 11:
                print("+10 силы замедления времени");
                snake.SpeedTimerSlower += 10;
                break;
            case 12:
                print("-0.25 поворотов");
                snake.TurnSlower -= 0.25f;
                break;
            case 13:
                print("+0.25 зоны поедания");
                snake.ZoneScale += 0.25f;
                break;
            case 14:
                print("+0.4 зоны уничтожения спайков EliminateSpike");
                snake.EliminateSpikeZoneScale += 0.4f;
                break;
            case 15:
                print("+1 зоны поедания способности EatMeal");
                snake.EatMealZoneScale += 1;
                break;
            case 16:
                print("+0.7 скорости бешенства Rabid");
                snake.RabidBoost -= 0.7f;
                break;
            case 17:
                print("+1 секунда бешенства Rabid");
                snake.RabidTimer += 1;
                break;
            case 18:
                print("+4 секунды спокойствия Tranquility");
                snake.TranquilityTimer += 4;
                break;
            case 19:
                print("Снижение стоимости Fever на 1");
                snake.FeverCost -= 1;
                break;
            case 20:
                print("Снижение стоимости FeverReverse на 1");
                snake.FeverReverseCost -= 1;
                break;
            case 21:
                print("Снижение стоимости FoodForChildren на 1");
                snake.FoodForChildrenCost -= 1;
                break;
            case 22:
                print("Снижение стоимости EliminateSpike на 1");
                snake.EliminateSpikeCost -= 1;
                break;
            case 23:
                print("Снижение стоимости EatMeal на 1");
                snake.EatMealCost -= 1;
                break;
            case 24:
                print("Снижение стоимости Rabid на 1");
                snake.RabidCost -= 1;
                break;
            case 25:
                print("Снижение стоимости Tranquility на 1");
                snake.TranquilityCost -= 1;
                break;
            case 27:
                print("+2 длины зоны уничтожения спайков EliminateSpike");
                snake.EliminateSpikeZoneLength += 2f;
                break;
        }
    }
}
