using UnityEngine;

public class FinalChunkTrigger : MonoBehaviour
{
    [SerializeField] FinalChunk finalChunk;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "SnakeHead")
        {
            finalChunk.SetFinal();
        }
    }
}
