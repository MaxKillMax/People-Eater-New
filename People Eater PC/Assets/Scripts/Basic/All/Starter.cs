using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Starter : MonoBehaviour
{
    [SerializeField] Controls controls;
    [SerializeField] Text[] ScoreText = new Text[8];
    // Этот метод просто расскидывает счёт в меню и в класс Score
    void Awake()
    {
        // Запись текста в Results
        int[] Last = new int[] { PlayerPrefs.GetInt("A0"), PlayerPrefs.GetInt("B0"), PlayerPrefs.GetInt("C0"), PlayerPrefs.GetInt("D0") };
        int[] Best = new int[] { PlayerPrefs.GetInt("A1"), PlayerPrefs.GetInt("B1"), PlayerPrefs.GetInt("C1"), PlayerPrefs.GetInt("D1") };
        Score.Starter(Last, Best);

        // Запись результатов
        if (PlayerPrefs.HasKey("A0")) ScoreText[7].text = PlayerPrefs.GetInt("A0").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("A1")) ScoreText[6].text = PlayerPrefs.GetInt("A1").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("B0")) ScoreText[3].text = PlayerPrefs.GetInt("B0").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("B1")) ScoreText[2].text = PlayerPrefs.GetInt("B1").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("C0")) ScoreText[5].text = PlayerPrefs.GetInt("C0").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("C1")) ScoreText[4].text = PlayerPrefs.GetInt("C1").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("D0")) ScoreText[1].text = PlayerPrefs.GetInt("D0").ToString("N0", CultureInfo.CurrentCulture);
        if (PlayerPrefs.HasKey("D1")) ScoreText[0].text = PlayerPrefs.GetInt("D1").ToString("N0", CultureInfo.CurrentCulture);

        // Запись настроек геймплея
        if (PlayerPrefs.HasKey("Difficulty")) StaticOptions.GetDifficulty(PlayerPrefs.GetInt("Difficulty"));
        if (PlayerPrefs.HasKey("ChunkCount")) StaticOptions.GetChunkCount(PlayerPrefs.GetInt("ChunkCount"));
        if (PlayerPrefs.HasKey("Quality")) StaticOptions.GetQuality(PlayerPrefs.GetInt("Quality"));
        if (PlayerPrefs.HasKey("Immortality"))
        {
            if (PlayerPrefs.GetInt("Immortality") == 0) StaticOptions.GetImmortality(false);
            else StaticOptions.GetImmortality(true);
        }
        if (PlayerPrefs.HasKey("FastQuit"))
        {
            if (PlayerPrefs.GetInt("FastQuit") == 0) StaticOptions.GetFastQuit(false);
            else StaticOptions.GetFastQuit(true);
        }

        // Запись настроек управления
        if (PlayerPrefs.HasKey("Quit"))
        {
            switch (PlayerPrefs.GetString("Quit"))
            {
                case "Q":
                    StaticControls.SetNum("Quit", KeyCode.Q);
                    controls.SetQuit("Q");
                    break;
                case "E":
                    StaticControls.SetNum("Quit", KeyCode.E);
                    controls.SetQuit("E");
                    break;
            }
        }
        else
        {
            StaticControls.SetNum("Quit", KeyCode.Q);
            controls.SetQuit("Q");
        }

        if (PlayerPrefs.HasKey("Zoom"))
        {
            switch (PlayerPrefs.GetString("Zoom"))
            {
                case "Z":
                    StaticControls.SetNum("Zoom", KeyCode.Z);
                    controls.SetZoom("Z");
                    break;
                case "X":
                    StaticControls.SetNum("Zoom", KeyCode.X);
                    controls.SetZoom("X");
                    break;
            }
        }
        else
        {
            StaticControls.SetNum("Zoom", KeyCode.Z);
            controls.SetZoom("Z");
        }

        // Запись настроек способностей
        if (!PlayerPrefs.HasKey("A"))
        {
            StaticControls.SetAbilityA("Fever");
        }
        if (!PlayerPrefs.HasKey("D"))
        {
            StaticControls.SetAbilityD("FeverReverse");
        }
    }
}
