using UnityEngine;

public class ModeFoodForChildren : MonoBehaviour
{
    [SerializeField] SnakeLength snakeLength;
    public void Activate()
    {
        snakeLength.RemoveTail();
        print("������ �� ����� ����� ��� ����� ��� ��������!");
    }
}
