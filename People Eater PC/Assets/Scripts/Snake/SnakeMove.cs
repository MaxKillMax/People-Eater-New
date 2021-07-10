using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Snake snake;
    [SerializeField] private SnakeLength snakeLength;
    [SerializeField] private SkillController skillController;
    [SerializeField] private OnDeath onDeath;

    private float SpeedTimer = 1;
    private float CurrentSpeed;

    private Vector3 Zero = Vector3.zero;
    private Vector3 Path = Vector3.zero;

    private bool ModeFever;
    private bool ModeTranquility;

    void Update()
    {
        if (!ModeTranquility)
        {
            SpeedTimer += Time.deltaTime / (snake.SpeedTimerSlower);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Path = new Vector3(0, hit.point.y, hit.point.z);

            if (Path.z > 7)
            {
                Path = new Vector3(0, Path.y, 7);
            }
            else if (Path.z < -7)
            {
                Path = new Vector3(0, Path.y, -7);
            }
        }

        if (Input.GetKey(StaticControls.GetNum("Acceleration")))
        {
            CurrentSpeed = snake.Speed + snake.Faster;
        }
        else if (Input.GetKey(StaticControls.GetNum("Deceleration")))
        {
            CurrentSpeed = snake.Speed - snake.Slower;
        }
        else
        {
            CurrentSpeed = snake.Speed;
        }

        if (!ModeFever)
        {
            RB.velocity = new Vector3((CurrentSpeed + SpeedTimer - snake.Length / 20) * Time.deltaTime * 1.5f, 0, (-(transform.position.z - Path.z) * snake.Speed / snake.TurnSlower) * Time.deltaTime * 1.25f);
            snake.Distance = this.transform.position.x - 4;
            transform.eulerAngles = new Vector3(0, -RB.velocity.z * 2, -90);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y, 0), ref Zero, 0.75f);
            RB.velocity = new Vector3(((snake.Speed + SpeedTimer) * 3) * Time.deltaTime * 1.5f, 0, 0);
            snake.Distance = this.transform.position.x - 4;
        }
    }

    // ModeFever активация
    public void UseModeFever()
    {
        Path = Vector3.zero;
        ModeFever = !ModeFever;
    }

    // ModeFeverReverse активация
    public void UseModeFeverReverse()
    {
        SpeedTimer--;
    }

    // Режим спокойствия
    public void UseModeTranquility()
    {
        ModeTranquility = !ModeTranquility;
    }
}
