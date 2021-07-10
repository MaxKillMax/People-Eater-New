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

    // ��� ���� �������� �������
    private void OnTriggerEnter(Collider other)
    {
        // ��� ���?
        if (other.transform.tag == "Eat")
        {
            EatColor = other.GetComponent<MeatBallColor>().ReadInformation();

            // �������� �� ���������� ���������� (� � ������ ���� - ����������� �������)
            if (Mesh.material.name != EatColor.name + " (Instance)")
            {
                Death.DestroySnake();
            }

            // ���������� ������
            snakeLength.AddTail(EatColor);
            Destroy(other.gameObject);
        }
        // � ����� �������?
        else if (other.transform.tag == "Crystal")
        {
            // ���������� � ������ ������
            skillController.AddCrystal();
            Destroy(other.transform.gameObject);
        }
    }
}
