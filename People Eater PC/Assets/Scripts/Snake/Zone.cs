using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] GameObject SnakeHead;
    [SerializeField] GameObject Snake;
    [SerializeField] SkillController skillController;
    [SerializeField] Snake snake;
    [SerializeField] SnakeLength snakeLength;
    [SerializeField] OnDeath Death;

    [SerializeField] MeshRenderer Mesh;
    Material EatColor;

    public void Start()
    {
        SetScale();
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(0.5f, snake.ZoneScale, snake.ZoneScale);
    }

    // Это зона поедания шариков
    private void OnTriggerEnter(Collider other)
    {
        // Это еда?
        if (other.transform.tag == "Eat")
        {
            EatColor = other.GetComponent<MeatBallColor>().ReadInformation();

            // Проверка на совпадение материалов (и в случае чего - умерщвление червяка)
            if (Mesh.material.name != EatColor.name + " (Instance)")
            {
                Death.DestroySnake();
            }

            // Добавление хвоста
            snakeLength.AddTail(EatColor);
            Destroy(other.gameObject);
        }
        // А может кристал?
        else if (other.transform.tag == "Crystal")
        {
            // Добавление к режиму февера
            skillController.AddCrystal();
            Destroy(other.transform.gameObject);
        }
    }
}
