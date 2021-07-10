using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLocalization : MonoBehaviour
{
    [SerializeField] GuidesList guidesList;


    [SerializeField] List<string> Russian = new List<string>();
    [SerializeField] List<string> English = new List<string>();
    [SerializeField] List<Text> MenuText = new List<Text>();

    [SerializeField] Image Language;
    [SerializeField] Sprite[] Languages;
    private string CurrentLanguage;

    public void SetLanguage()
    {
        if (CurrentLanguage == "English")
        {
            PlayerPrefs.SetString("Language", "Russian");

            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = Russian[i];
            }

            Language.sprite = Languages[1];
            CurrentLanguage = "Russian";
        }
        else if (CurrentLanguage == "Russian")
        {
            PlayerPrefs.SetString("Language", "English");

            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = English[i];
            }

            Language.sprite = Languages[0];
            CurrentLanguage = "English";
        }

        guidesList.ReLocalize();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "English");
        }

        if (PlayerPrefs.GetString("Language") == "English")
        {
            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = English[i];
            }

            Language.sprite = Languages[0];
            CurrentLanguage = "English";
        }
        else if (PlayerPrefs.GetString("Language") == "Russian")
        {
            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = Russian[i];
            }

            Language.sprite = Languages[1];
            CurrentLanguage = "Russian";
        }
    }
}
