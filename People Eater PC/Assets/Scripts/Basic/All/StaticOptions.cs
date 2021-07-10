using UnityEngine;
// ����� ������ ������ ���������� ������ �������
// (� �������, ���� ���������� �� ��������, �� ��������� ������ - ������� �� ������ ���������)
public static class StaticOptions
{
    // ��� ������ ��������� �������� � ���� �������� ����� ����� Options
    public static float difficulty = 1;
    public static float chunkCount = 10000;
    public static bool immortality = false;
    public static bool fastQuit = false;

    public static float Difficulty { get { return difficulty; } set { difficulty = value; } }
    public static float ChunkCount { get { return chunkCount; } set { chunkCount = value; } }
    public static bool Immortality { get { return immortality; } set { immortality = value; } }
    public static bool FastQuit { get { return fastQuit; } set { fastQuit = value; } }

    // ��������� ����
    public static void GetDifficulty(int Num)
    {
        difficulty = Num;

        // 0,1,2
        PlayerPrefs.SetInt("Difficulty", Num);
    }

    // ���������� ������ �� �����
    public static void GetChunkCount(int Num)
    {
        chunkCount = Num;

        PlayerPrefs.SetInt("ChunkCount", Num);
    }

    public static void GetQuality(int i)
    {
        QualitySettings.SetQualityLevel(i, true);

        // 0,1,2
        PlayerPrefs.SetInt("Quality", i);
    }

    // ����� ����������
    public static void GetImmortality(bool Act = false)
    {
        immortality = Act;

        if (!Act)
        {
            PlayerPrefs.SetInt("Immortality", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Immortality", 1);
        }
    }

    // ������� ����� �� ����
    public static void GetFastQuit(bool Act = false)
    {
        fastQuit = Act;

        if (!Act)
        {
            PlayerPrefs.SetInt("FastQuit", 0);
        }
        else
        {
            PlayerPrefs.SetInt("FastQuit", 1);
        }
    }
}
