using UnityEngine;

public class SpikeDeath : MonoBehaviour
{
    // Смертельное касание
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "SnakeHead")
        {
            if (!other.GetComponent<OnDeath>().DestroySnake())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
