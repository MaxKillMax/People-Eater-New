using UnityEngine;

public static class Score
{
    // ��������� ����
    static int LastScore;
    static int LastSnakeLength;
    static int LastCrystals;
    static int LastDistance;

    // ������ ����
    static int BestScore;
    static int BestSnakeLength;
    static int BestCrystals;
    static int BestDistance;

    // � ������ ������ ��������� � PlayerPrefs ���� � ���������� � ������ ������ ������(���� �� ����)
    public static void AddLastMatch(int _Score, int[] _Stats)
    {
        LastScore = _Score;
        LastSnakeLength = _Stats[0];
        LastCrystals = _Stats[1];
        LastDistance = _Stats[2];

        PlayerPrefs.SetInt("A0", LastScore);
        PlayerPrefs.SetInt("B0", LastSnakeLength);
        PlayerPrefs.SetInt("C0", LastCrystals);
        PlayerPrefs.SetInt("D0", LastDistance);

        if (LastScore > BestScore)
        {
            BestScore = LastScore;
            PlayerPrefs.SetInt("A1", BestScore);
        }

        if (LastSnakeLength > BestSnakeLength)
        {
            BestSnakeLength = LastSnakeLength;
            PlayerPrefs.SetInt("B1", BestSnakeLength);
        }

        if (LastCrystals > BestCrystals)
        {
            BestCrystals = LastCrystals;
            PlayerPrefs.SetInt("C1", BestCrystals);
        }

        if (LastDistance > BestDistance)
        {
            BestDistance = LastDistance;
            PlayerPrefs.SetInt("D1", BestDistance);
        }
    }

    // � ������� Starter ��� ����� ��������� �������� � ������, ���� ����� ��� ��������
    public static void Starter(int[] Last, int[] Best)
    {
        LastScore = Last[0];
        LastSnakeLength = Last[1];
        LastCrystals = Last[2];
        LastDistance = Last[3];

        BestScore = Best[0];
        BestSnakeLength = Best[1];
        BestCrystals = Best[2];
        BestDistance = Best[3]; 
    }
}
