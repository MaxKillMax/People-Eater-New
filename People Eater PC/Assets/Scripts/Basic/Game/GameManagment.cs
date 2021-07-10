using UnityEngine.UI;
using System.Globalization;
using UnityEngine;

public class GameManagment : MonoBehaviour
{
    [SerializeField] Snake snake;

    [SerializeField] PerkChoose perkChoose;
    [SerializeField] GameObject NEWindow;
    public GameObject NEwindow { get { return NEWindow; } private set { NEWindow = value; } }
    [SerializeField] GameObject GameWindowPanel;
    [SerializeField] GameObject FinalWindow;

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject ControlsMenu;

    [SerializeField] Text HeaderText;
    [SerializeField] Text CostText;
    private float WindowTimer;

    private bool Activate;
    private bool Open;
    private bool OpenControls;

    // ������������ � ����� ������ � Basic: ����������� � SceneManagment
    public void ConnectToSceneManagment(int id)
    {
        if (PlayerPrefs.GetInt("Immortality") == 0)
        {
            if (id == -1)
            {
                id = 0;
                Score.AddLastMatch(snake.GetScore() + 1000, snake.GetStats());
            }
            else
            {
                Score.AddLastMatch(snake.GetScore(), snake.GetStats());
            }
        }

        Time.timeScale = 1;
        SceneManagment.LoadScene(id);
    }

    // ������������ ���������� ��� ��������� ������
    public void ActivateNEWindow(int Cost)
    {
        if (!Activate)
        {
            WindowTimer = 2;
            NEWindow.SetActive(true);

            if (PlayerPrefs.GetString("Language") == "English")
            {
                if (Cost >= 0)
                {
                    HeaderText.text = "Not enough crystals";
                    CostText.text = "Need: " + Cost.ToString("N0", CultureInfo.CurrentCulture);
                }
                else if (Cost == -1)
                {
                    HeaderText.text = "Snake is not long";
                    CostText.text = "Need tails";
                }
                else if (Cost == -2)
                {
                    HeaderText.text = "Some ability is";
                    CostText.text = "already active";
                }
            }
            else if(PlayerPrefs.GetString("Language") == "Russian")
            {
                if (Cost >= 0)
                {                      
                    HeaderText.text = "����� ���������";
                    CostText.text = "�����: " + Cost.ToString("N0", CultureInfo.CurrentCulture);
                }
                else if (Cost == -1)
                {
                    HeaderText.text = "���� ��������";
                    CostText.text = "����� �����";
                }
                else if (Cost == -2)
                {
                    HeaderText.text = "�����-�� �����������";
                    CostText.text = "��� �������";
                }
            }
        }
    }

    // ���� �������� � ����
    public void ControlMenu()
    {
        OpenControls = !OpenControls;

        ControlsMenu.SetActive(OpenControls);
        MainMenu.SetActive(!OpenControls);
    }

    // ������� ����
    public void GameWindow()
    {
        if (!Activate)
        {
            Open = !Open;
            GameWindowPanel.SetActive(Open);

            if (Open)
            {
                Time.timeScale = 0;

                MainMenu.SetActive(true);
                ControlsMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    // �������� ����
    public void OpenFinalWindow()
    {
        Activate = true;
        GameWindowPanel.SetActive(Open);
        FinalWindow.SetActive(true);
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(StaticControls.GetNum("Quit")) && !perkChoose.Activated)
        {
            GameWindow();
        }

        if (WindowTimer > 0)
        {
            WindowTimer -= Time.deltaTime;
            
            if (WindowTimer <= 0)
            {
                WindowTimer = 0;
                NEWindow.SetActive(false);
            }
        }
    }
}
