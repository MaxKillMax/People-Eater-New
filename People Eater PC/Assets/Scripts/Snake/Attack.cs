using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Snake snake;
    [SerializeField] SnakeLength snakeLength;
    
    public void StartAttack()
    {
        if (snake.Length > 1)
        {
            snakeLength.RemoveTail();
            print("ядекюи ярпекэас оюдфюксярю!!!!");
        }
        else
        {
            print("Attack need tails");
        }
    }
}
