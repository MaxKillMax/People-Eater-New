using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private float DeathTimer = 0;

    private Vector3 Zero = Vector3.zero;
    private bool Activate = false;
    private float ZoomTime = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && ZoomTime == 0)
        {
            ZoomTime = 1f;
        }
        else if (ZoomTime > 0)
        {
            ZoomTime -= Time.deltaTime;

            if (Player != null && !Activate) transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(Player.transform.position.x - 24, 25, Player.transform.position.z * 0.5f), ref Zero, 0.75f);
            else if (Player != null && Activate) transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(Player.transform.position.x - 3, 15, Player.transform.position.z * 0.5f), ref Zero, 0.75f);
            else ZoomTime = 0;

            if (ZoomTime <= 0)
            {
                ZoomTime = 0;
                Activate = !Activate;
            }
        }

        if (ZoomTime == 0 && Activate)
        {
            // Передвижение за игроком в зуме(в случае, если он погибнет, камера будет следовать дальше для динамичности)
            if (Player != null)
                transform.position = new Vector3(Player.transform.position.x - 24, 25, Player.transform.position.z * 0.4f);
            else if (DeathTimer < 100)
            {
                DeathTimer += Time.deltaTime;
                transform.position = new Vector3(transform.position.x + Time.deltaTime, 25, transform.position.z * 0.99f);
            }
        }

        if (ZoomTime == 0 && !Activate)
        {
            // Передвижение за игроком(в случае, если он погибнет, камера будет следовать дальше для динамичности)
            if (Player != null)
                transform.position = new Vector3(Player.transform.position.x - 3, 15, Player.transform.position.z * 0.4f);
            else if (DeathTimer < 100)
            {
                DeathTimer += Time.deltaTime;
                transform.position = new Vector3(transform.position.x + Time.deltaTime, 15, transform.position.z * 0.99f);
            }
        }
    }
}
