using System.Collections.Generic;
using UnityEngine;

public class SnakeLength : MonoBehaviour
{
    List<GameObject> Tails = new List<GameObject>();
    [SerializeField] GameObject TailPrefab;
    [SerializeField] GameObject Head;
    [SerializeField] Snake snake;
    [SerializeField] MeshRenderer HeadColor;

    public void AddTail(Material Color)
    {
        // Создание хвоста
        Tails.Add(Instantiate(TailPrefab));
        Tails[Tails.Count - 1].transform.position = new Vector3(Head.transform.position.x - 0.4f - 0.9f * Tails.Count, 0, Head.transform.position.z);
        Tails[Tails.Count - 1].transform.parent = this.transform;
        Tails[Tails.Count - 1].GetComponent<MeshRenderer>().material = Color;

        // Если хвост самый первый, к нему дополнительные требования по соблюдению дистанции от предыдущего
        if (Tails.Count > 1)
        {
            Tails[Tails.Count - 1].GetComponent<Tail>().GetInformation(Tails[Tails.Count - 2]);
        }
        else
        {
            Tails[0].GetComponent<Tail>().GetInformation(Head, 1.3f);
        }

        snake.Length = Tails.Count + 1;
        snake.SumLength++;
    }

    public void RemoveTail()
    {
        if (Tails.Count > 0)
        {
            Destroy(Tails[Tails.Count - 1]);
            Tails.RemoveAt(Tails.Count - 1);
            snake.Length = Tails.Count + 1;
        }
        else
        {
            print("Хвост не может быть удалён из-за остутствия его");
        }
    }
}
