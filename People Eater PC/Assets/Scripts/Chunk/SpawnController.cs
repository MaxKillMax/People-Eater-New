using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Учёт всех чанков и количества их за всё время
    private List<GameObject> Chunks = new List<GameObject>();
    [SerializeField] GameObject ChunkPrefab;
    [SerializeField] GameObject FinalChunkPrefab;
    [SerializeField] GameObject StartChunk;
    int Count;

    // Параметры для других чанков
    [SerializeField] GameManagment gameManagment;
    [SerializeField] List<Material> Colors = new List<Material>();
    [SerializeField] List<Material> SnakeColors = new List<Material>();
    [SerializeField] GameObject SpikePrefab;
    [SerializeField] GameObject MeatBallPrefab;
    [SerializeField] GameObject CrystalPrefab;
    [SerializeField] GameObject Snake;
    [SerializeField] SpawnController Folder;
    float Chance = 90;

    // Просто переменная, которой я не смог придумать название, но она мне помогала)
    int Helper = 0;

    // Добавление начального чанка в список и передача ему тонны информации
    void Start() 
    {
        Helper = Random.Range(0, 6);
        Chunks.Add(StartChunk);
        StartChunk.GetComponent<Chunk>().GetInformation
            (SpikePrefab, MeatBallPrefab, CrystalPrefab, Snake, Folder, Chance, Count, Colors[Helper], SnakeColors[Helper], SnakeColors);

        Count++;
    }

    // Создание нового чанка
    public void CreateNewChunk()
    {
        if (Count < StaticOptions.ChunkCount)
        {
            Chance -= 0.2f;
            Helper = Random.Range(0, 6);

            Chunks.Add(Instantiate(ChunkPrefab));
            Chunks[Chunks.Count - 1].transform.position = new Vector3(150 * Count, 0, 0);
            Chunks[Chunks.Count - 1].transform.parent = this.transform;
            Chunks[Chunks.Count - 1].GetComponent<Chunk>().GetInformation
                (SpikePrefab, MeatBallPrefab, CrystalPrefab, Snake, Folder, Chance, Count, Colors[Helper], SnakeColors[Helper], SnakeColors);

            Count++;
            if (Count > 3) DeleteOldChunk();
        }
        else
        {
            Chunks.Add(Instantiate(FinalChunkPrefab));
            Chunks[Chunks.Count - 1].transform.position = new Vector3(150 * Count, 0, 0);
            Chunks[Chunks.Count - 1].transform.parent = this.transform;
            Chunks[Chunks.Count - 1].GetComponent<FinalChunk>().GetInformation(gameManagment);
            if (Count > 3) DeleteOldChunk();
        }
    }

    // Удаление старого чанка
    public void DeleteOldChunk()
    {
        GameObject Object;
        Object = Chunks[0];
        Chunks.Remove(Object);
        Destroy(Object);
    }
}
