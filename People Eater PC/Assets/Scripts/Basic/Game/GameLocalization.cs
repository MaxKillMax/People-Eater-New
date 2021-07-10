using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLocalization : MonoBehaviour
{
    [SerializeField] List<string> Russian = new List<string>();
    [SerializeField] List<string> English = new List<string>();
    [SerializeField] List<Text> MenuText = new List<Text>();

    void Start()
    {
        if (PlayerPrefs.GetString("Language") == "English")
        {
            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = English[i];
            }
        }
        else if (PlayerPrefs.GetString("Language") == "Russian")
        {
            for (int i = 0; i < MenuText.Count; i++)
            {
                MenuText[i].text = Russian[i];
            }
        }
    }
}
