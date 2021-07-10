using UnityEngine;

public class SnakeBot : MonoBehaviour
{
    [SerializeField] Rigidbody RB;
    [SerializeField] bool Z;
    float SpeedZ;
    float SpeedX;

    [SerializeField] Vector3 PointStart;
    private Vector3 CurrentStart;
    [SerializeField] Vector3 PointEnd;

    private void Start()
    {
        if (Z)
        {
            SpeedZ = Random.Range(1000, 4000);
        }
        else
        {
            SpeedX = Random.Range(1000, 4000);
        }

        CurrentStart = PointStart;
    }

    void Update()
    {
        RB.velocity = new Vector3(SpeedX * Time.deltaTime * 1.25f, 0, SpeedZ * Time.deltaTime * 1.25f);

        if (SpeedZ != 0)
        {
            if (transform.position.z > PointEnd.z)
            {
                CurrentStart = new Vector3(Random.Range(PointStart.x - 5, PointStart.x + 6), PointStart.y, PointStart.z);
                transform.position = CurrentStart;
                SpeedZ = Random.Range(1000, 4000);
            }
        }
        else if (SpeedX != 0)
        {
            if (transform.position.x > PointEnd.x)
            {
                CurrentStart = new Vector3(PointStart.x, PointStart.y, Random.Range(PointStart.z - 5, PointStart.z + 6));
                transform.position = CurrentStart;
                SpeedX = Random.Range(1000, 4000);
            }
        }
    }
}
