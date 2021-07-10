using UnityEngine;

public class StarterDifficulty : MonoBehaviour
{
    [SerializeField] Snake snake;

    void Start()
    {
        if (StaticOptions.Difficulty == 0)
        {
            Debug.Log("Difficulty: Easy");
        }
        else if (StaticOptions.Difficulty == 1)
        {
            Debug.Log("Difficulty: Normal");
            snake.SetMultiply(0.2f);

            snake.SpeedTimerSlower -= 5;
            snake.TurnSlower += 0.3f;
            snake.Faster -= 25;
            snake.Slower -= 15;

        }
        else if (StaticOptions.Difficulty == 2)
        {
            Debug.Log("Difficulty: Hard");
            snake.SetMultiply(0.4f);

            snake.SpeedTimerSlower -= 20;
            snake.TurnSlower += 0.5f;
            snake.Faster -= 50;
            snake.Slower -= 30;

            snake.FeverCost++;
            snake.FeverReverseCost++;
            snake.TailGrowingCost++;
            snake.FoodForChildrenCost++;
            snake.EliminateSpikeCost++;
            snake.EatMealCost++;
            snake.RabidCost++;
            snake.TranquilityCost++;
        }
    }
}
