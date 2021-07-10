using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] Image[] QuitImages;
    [SerializeField] Image[] ZoomImages;

    [SerializeField] Sprite[] Sprite;

    public void SetQuit(string key)
    {
        if (key == "Q")
        {
            StaticControls.SetNum("Quit", KeyCode.Q);

            QuitImages[0].sprite = Sprite[1];
            QuitImages[1].sprite = Sprite[0];
            QuitImages[2].sprite = Sprite[0];
        }
        else if (key == "E")
        {
            StaticControls.SetNum("Quit", KeyCode.E);

            QuitImages[0].sprite = Sprite[0];
            QuitImages[1].sprite = Sprite[1];
            QuitImages[2].sprite = Sprite[0];
        }
        else if (key == "Esc")
        {
            StaticControls.SetNum("Quit", KeyCode.Escape);

            QuitImages[0].sprite = Sprite[0];
            QuitImages[1].sprite = Sprite[0];
            QuitImages[2].sprite = Sprite[1];
        }
    }

    public void SetZoom(string key)
    {
        if (key == "Z")
        {
            StaticControls.SetNum("Zoom", KeyCode.Z);

            ZoomImages[0].sprite = Sprite[1];
            ZoomImages[1].sprite = Sprite[0];
        }
        else if (key == "X")
        {
            StaticControls.SetNum("Zoom", KeyCode.X);

            ZoomImages[0].sprite = Sprite[0];
            ZoomImages[1].sprite = Sprite[1];
        }
    }

    public void SetA(string key)
    {
        StaticControls.SetAbilityA(key);
    }

    public void SetD(string key)
    {
        StaticControls.SetAbilityD(key);
    }
}
