using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    private bool Activate = false;
    // ��� ��������������� � ���� �������� ���������� ��������� ���� ����� PlatformSpeed.cs
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "SnakeHead" && !Activate)
        {
            print("Activated");
            GetComponentInParent<PlatformSpeed>().Next();
            Activate = true;
        }
    }
}
