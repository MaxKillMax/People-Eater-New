using System.Collections.Generic;
using UnityEngine;

public class TriggerEatMeal : MonoBehaviour
{
    [SerializeField] Snake snake;
    [SerializeField] SnakeLength snakeLength;
    [SerializeField] MeshRenderer meshRenderer;
    List<GameObject> MeatBall = new List<GameObject>();

    private void Start()
    {
        SetScale();
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(snake.EatMealZoneScale, 0.5f, snake.EatMealZoneScale);
    }

    public void DestroyMeatBalls()
    {
        for (int i = MeatBall.Count - 1; i >= 0; i--)
        {
            snakeLength.AddTail(meshRenderer.material);
            Destroy(MeatBall[i]);
            MeatBall.RemoveAt(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Eat")
        {
            MeatBall.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Eat")
        {
            MeatBall.Remove(other.gameObject);
        }
    }
}
