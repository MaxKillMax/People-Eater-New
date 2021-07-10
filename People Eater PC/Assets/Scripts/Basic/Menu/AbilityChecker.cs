using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AbilityChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image image;
    [SerializeField] Controls controls;
    [SerializeField] Text text;
    [SerializeField] Text[] otherText;
    [SerializeField] string Identificator;
    private bool ChangerActivate;

    private void Start()
    {
        if (StaticControls.GetAbility("A") == Identificator && StaticControls.GetAbility("D") == Identificator)
        {
            text.text = "AD";
            image.sprite = sprites[1];
        }
        else if (StaticControls.GetAbility("D") == Identificator)
        {
            text.text = "D";
            image.sprite = sprites[1];
        }
        else if (StaticControls.GetAbility("A") == Identificator)
        {
            text.text = "A";
            image.sprite = sprites[1];
        }
        
    }

    private void Update()
    {
        if (ChangerActivate)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (text.text == "D")
                {
                    text.text = "AD";
                }
                else
                {
                    text.text = "A";
                }

                for (int i = 0; i < otherText.Length; i++)
                {
                    if (otherText[i].text == "A")
                    {
                        otherText[i].text = "";
                    }
                    else if (otherText[i].text == "AD")
                    {
                        otherText[i].text = "D";
                    }
                }

                image.sprite = sprites[1];
                controls.SetA(Identificator);
                print(Identificator);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (text.text == "A")
                {
                    text.text = "AD";
                }
                else
                {
                    text.text = "D";
                }

                for (int i = 0; i < otherText.Length; i++)
                {
                    if (otherText[i].text == "D")
                    {
                        otherText[i].text = "";
                    }
                    else if (otherText[i].text == "AD")
                    {
                        otherText[i].text = "A";
                    }
                }

                image.sprite = sprites[1];
                controls.SetD(Identificator);
                print(Identificator);
            }
        }

        if (!ChangerActivate && text.text == "")
        {
            image.sprite = sprites[0];
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangerActivate = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ChangerActivate = false;
    }
}
