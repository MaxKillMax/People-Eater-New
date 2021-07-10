using UnityEngine;

public class SkillController : MonoBehaviour
{
    [SerializeField] Snake snake;
    [HideInInspector] public bool ActiveSkill = false;
    [HideInInspector] public bool ActiveSkillSafe = false;
    [SerializeField] GameManagment gameManagment;

    [SerializeField] ModeFever Fever;
    [SerializeField] ModeFeverReverse FeverReverse;
    [SerializeField] ModeTailGrowing TailGrowing;
    [SerializeField] ModeFoodForChildren FoodForChildren;
    [SerializeField] ModeEliminateSpikes EliminateSpikes;
    [SerializeField] ModeEatMeal EatMeal;
    [SerializeField] ModeRabid Rabid;
    [SerializeField] ModeTranquility Tranquility;

    [HideInInspector] public float Full;
    private float timer = 10;

    public void AddCrystal()
    {
        if (!ActiveSkill)
        {
            snake.Crystals++;
            snake.SumCrystals++;
        }
    }

    private void Update()
    {
        if (!ActiveSkill && !ActiveSkillSafe)
        {
            if (Input.GetKeyUp(StaticControls.GetNum("Ability1")))
            {
                switch(StaticControls.GetAbility("A"))
                {
                    case "Fever":
                        ActivateFever();
                        break;
                    case "FeverReverse":
                        ActivateFeverReverse();
                        break;
                    case "TailGrowing":
                        ActivateTailGrowing();
                        break;
                    case "FoodForChildren":
                        ActivateFoodForChildren();
                        break;
                    case "EliminateSpike":
                        ActivateEliminateSpikes();
                        break;
                    case "EatMeal":
                        ActivateEatMeal();
                        break;
                    case "Rabid":
                        ActivateRabid();
                        break;
                    case "Tranquility":
                        ActivateTranquility();
                        break;
                    default:
                        Debug.LogError("Несуществующая способность: " + StaticControls.GetAbility("A"));
                        break;
                }
            }

            if (Input.GetKeyUp(StaticControls.GetNum("Ability2")))
            {
                switch(StaticControls.GetAbility("D"))
                {
                    case "Fever":
                        ActivateFever();
                        break;
                    case "FeverReverse":
                        ActivateFeverReverse();
                        break;
                    case "TailGrowing":
                        ActivateTailGrowing();
                        break;
                    case "FoodForChildren":
                        ActivateFoodForChildren();
                        break;
                    case "EliminateSpike":
                        ActivateEliminateSpikes();
                        break;
                    case "EatMeal":
                        ActivateEatMeal();
                        break;
                    case "Rabid":
                        ActivateRabid();
                        break;
                    case "Tranquility":
                        ActivateTranquility();
                        break;
                    default:
                        Debug.LogError("Несуществующая способность: " + StaticControls.GetAbility("D"));
                        break;
                }
            }
        }
        else if (Input.GetKeyUp(StaticControls.GetNum("Ability1")) || Input.GetKeyUp(StaticControls.GetNum("Ability2")))
        {
            gameManagment.ActivateNEWindow(-2);
        }

        if (Full != 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = Full;
                TailGrowing.Activate();
            }
        }
    }

    public void ActivateFever()
    {
        if (snake.Crystals >= snake.FeverCost)
        {
            Fever.Activate();
            ActiveSkill = !ActiveSkill;
            snake.Crystals -= snake.FeverCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.FeverCost);
        }
    }

    public void ActivateFeverReverse()
    {
        if (snake.Crystals >= snake.FeverReverseCost)
        {
            FeverReverse.Activate();
            ActiveSkill = !ActiveSkill;
            snake.Crystals -= snake.FeverReverseCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.FeverReverseCost);
        }
    }

    public void ActivateTailGrowing()
    {
        if (snake.Crystals >= snake.TailGrowingCost)
        {
            TailGrowing.Activate();
            snake.Crystals -= snake.TailGrowingCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.TailGrowingCost);
        }
    }

    public void ActivateFoodForChildren()
    {
        if (snake.Crystals >= snake.FoodForChildrenCost)
        {
            if (snake.Length > 1)
            {
                FoodForChildren.Activate();
                snake.Crystals -= snake.FoodForChildrenCost;
            }
            else
            {
                gameManagment.ActivateNEWindow(-1);
            }
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.FoodForChildrenCost);
        }
    }

    public void ActivateEliminateSpikes()
    {
        if (snake.Crystals >= snake.EliminateSpikeCost)
        {
            EliminateSpikes.Activate();
            snake.Crystals -= snake.EliminateSpikeCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.EliminateSpikeCost);
        }
    }

    public void ActivateEatMeal()
    {
        if (snake.Crystals >= snake.EatMealCost)
        {
            EatMeal.Activate();
            snake.Crystals -= snake.EatMealCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.EatMealCost);
        }
    }

    public void ActivateRabid()
    {
        if (snake.Crystals >= snake.RabidCost)
        {
            Rabid.Activate();
            ActiveSkillSafe = !ActiveSkillSafe;
            snake.Crystals -= snake.RabidCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.RabidCost);
        }
    }

    public void ActivateTranquility()
    {
        if (snake.Crystals >= snake.TranquilityCost)
        {
            Tranquility.Activate();
            ActiveSkillSafe = !ActiveSkillSafe;
            snake.Crystals -= snake.TranquilityCost;
        }
        else
        {
            gameManagment.ActivateNEWindow(snake.TranquilityCost);
        }
    }
}
