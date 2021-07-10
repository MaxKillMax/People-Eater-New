using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkChoose : MonoBehaviour
{
    [SerializeField] GameManagment gameManagment;
    [SerializeField] PerkController perkController;
    [SerializeField] GameObject PerkMenu;

    [SerializeField] List<string> PerkName = new List<string>();
    [SerializeField] List<string> PerkDescription = new List<string>();
    [SerializeField] List<string> PerkDescriptionRU = new List<string>();

    [SerializeField] Text[] Headers = new Text[3];
    [SerializeField] Text[] Bodies = new Text[3];

    private List<int> Numbers = new List<int>();

    [HideInInspector] public bool Activated;
    private bool TimerActivate;
    private float Timer;

    public void StartChoose(int One, int Two, int Three)
    {
        gameManagment.NEwindow.SetActive(false);

        if (PlayerPrefs.GetString("Language") == "English")
        {
            Headers[0].text = PerkName[One];
            Bodies[0].text = PerkDescription[One];
            Headers[1].text = PerkName[Two];
            Bodies[1].text = PerkDescription[Two];
            Headers[2].text = PerkName[Three];
            Bodies[2].text = PerkDescription[Three];
        }
        else if (PlayerPrefs.GetString("Language") == "Russian")
        {
            Headers[0].text = PerkName[One];
            Bodies[0].text = PerkDescriptionRU[One];
            Headers[1].text = PerkName[Two];
            Bodies[1].text = PerkDescriptionRU[Two];
            Headers[2].text = PerkName[Three];
            Bodies[2].text = PerkDescriptionRU[Three];
        }


        Numbers.Add(One);
        Numbers.Add(Two);
        Numbers.Add(Three);

        Time.timeScale = 0;
        PerkMenu.SetActive(true);
        Activated = true;
    }

    public void Pick(int Number)
    {
        perkController.AddPerk(Numbers[Number]);

        for (int i = Numbers.Count - 1; i >= 0; i--)
        {
            Numbers.RemoveAt(i);
        }

        PerkMenu.SetActive(false);
        TimerActivate = true;
        Time.timeScale = 0.2f;
        Timer = 0.1f;
    }

    private void Update()
    {
        if (TimerActivate)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                TimerActivate = false;
                Time.timeScale = 1;
                Activated = false;
            }
        }
    }
}
