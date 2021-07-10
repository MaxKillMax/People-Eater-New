using System.Collections.Generic;
using UnityEngine;

public class TriggerEliminateSpikes : MonoBehaviour
{
    [SerializeField] Snake snake;
    List<GameObject> Spikes = new List<GameObject>();

    private void Start()
    {
        SetScale();
    }

    public void SetScale(float trans = 0)
    {
        transform.localScale = new Vector3(0.5f, snake.EliminateSpikeZoneLength, snake.EliminateSpikeZoneScale);

        if (trans != 0)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y + trans / 2, 0);
        }
    }

    public void DestroySpikes()
    {
        for (int i = Spikes.Count - 1; i >= 0; i--)
        {
            Destroy(Spikes[i]);
            Spikes.RemoveAt(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Spike")
        {
            Spikes.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Spike")
        {
            Spikes.Remove(other.gameObject);
        }
    }
}
