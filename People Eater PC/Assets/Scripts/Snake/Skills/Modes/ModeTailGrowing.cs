using UnityEngine;

public class ModeTailGrowing : MonoBehaviour
{
    [SerializeField] SnakeLength snakeLength;
    [SerializeField] MeshRenderer snakeColor;
    public void Activate()
    {
        snakeLength.AddTail(snakeColor.material);
    }
}
