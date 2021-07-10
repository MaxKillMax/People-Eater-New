using UnityEngine;
using UnityEngine.UI;

public class MenuManagment : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject GuidesPanel;
    [SerializeField] GameObject StorePanel;
    [SerializeField] GameObject ResultsPanel;
    [SerializeField] GameObject OptionsPanel;
    [SerializeField] GameObject AboutGamePanel;
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject AbilitiesPanel;
    [SerializeField] GameObject GameplayPanel;
    [SerializeField] GameObject AudioPanel;
    [SerializeField] GameObject QuitPanel;

    [SerializeField] string[] TextsRU = new string[6];
    [SerializeField] string[] TextsEN = new string[6];
    [SerializeField] Text Header;

    private int QuitCount;
    private int ClickToQuit = 5;

    // Используется в обоих сценах в Basic: связывается с SceneManagment
    public void ConnectToSceneManagment(int id)
    {
        SceneManagment.LoadScene(id);
    }

    // Выход из игры на кнопку
    private void Update()
    {
        if (Input.GetKeyDown(StaticControls.GetNum("Quit")))
        {
            GuidesPanel.SetActive(false);
            StorePanel.SetActive(false);
            ResultsPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            AboutGamePanel.SetActive(false);
            ControlsPanel.SetActive(false);
            QuitPanel.SetActive(false);
            GameplayPanel.SetActive(false);
            AudioPanel.SetActive(false);

            MenuPanel.SetActive(true);
        }
    }

    // Меню выхода из игры
    public void MenuQuit(bool Open)
    {
        if (!Open)
        {
            QuitCount = 0;
        }

        if (QuitCount == 0)
        {
            if (PlayerPrefs.GetString("Language") == "English")
            {
                Header.text = TextsEN[0];
            }
            else
            {
                Header.text = TextsRU[0];
            }
        }

        MenuPanel.SetActive(!Open);
        QuitPanel.SetActive(Open);
    }

    // Зайти в меню выхода заново
    public void MenuQuitReset()
    {
        if (StaticOptions.FastQuit)
        {
            print("Leave");
            Application.Quit();
        }
        else
        {
            QuitCount++;

            if (QuitCount >= ClickToQuit)
            {
                print("Leave");
                Application.Quit();
            }

            if (PlayerPrefs.GetString("Language") == "English")
            {
                Header.text = TextsEN[QuitCount];
            }
            else
            {
                Header.text = TextsRU[QuitCount];
            }
        }
    }

    // Меню гайдов
    public void MenuGuides(bool Open)
    {
        MenuPanel.SetActive(!Open);
        GuidesPanel.SetActive(Open);
    }

    // Меню магазина
    public void MenuStore(bool Open)
    {
        MenuPanel.SetActive(!Open);
        StorePanel.SetActive(Open);
    }

    // Меню статистик
    public void MenuResults(bool Open)
    {
        MenuPanel.SetActive(!Open);
        ResultsPanel.SetActive(Open);
    }

    // Меню опций
    public void MenuOptions(bool Open)
    {
        MenuPanel.SetActive(!Open);
        OptionsPanel.SetActive(Open);
    }

    public void MenuAboutGame(bool Open)
    {
        OptionsPanel.SetActive(!Open);
        AboutGamePanel.SetActive(Open);
    }

    public void MenuControls(bool Open)
    {
        OptionsPanel.SetActive(!Open);
        ControlsPanel.SetActive(Open);
    }

    public void MenuAbilities(bool Open)
    {
        ControlsPanel.SetActive(!Open);
        AbilitiesPanel.SetActive(Open);
    }

    public void MenuGameplay(bool Open)
    {
        OptionsPanel.SetActive(!Open);
        GameplayPanel.SetActive(Open);
    }

    public void MenuAudio(bool Open)
    {
        OptionsPanel.SetActive(!Open);
        AudioPanel.SetActive(Open);
    }
}
