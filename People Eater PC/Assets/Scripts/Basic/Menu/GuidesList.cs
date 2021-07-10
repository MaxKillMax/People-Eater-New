using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuidesList : MonoBehaviour
{
    [Header("Guides")]
    private List<GameObject> Guides = new List<GameObject>();
    public List<GameObject> Favorites = new List<GameObject>();
    // Тег
    [SerializeField] List<string> Type = new List<string>();
    // Заголовок
    [SerializeField] List<string> Header = new List<string>();
    [SerializeField] List<string> HeaderRU = new List<string>();
    // Суть
    [SerializeField] List<string> Bodies = new List<string>();
    [SerializeField] List<string> BodiesRU = new List<string>();
    // Иконка
    [SerializeField] List<Sprite> Images = new List<Sprite>();

    [Header("Other")]
    [SerializeField] Slider slider;
    [SerializeField] GuidesList guidesList;
    private bool FavoriteView;
    private List<GameObject> CurrentList = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Guides.Add(transform.GetChild(i).gameObject);
        }

        if (Guides.Count > 0)
        {
            for (int i = 0; i < Guides.Count; i++)
            {
                if (PlayerPrefs.GetString("Language") == "English")
                {
                    Guides[i].GetComponent<Guide>().SetInformation(guidesList, Header[i], Bodies[i], Type[i], Images[i]);
                }
                else if (PlayerPrefs.GetString("Language") == "Russian")
                {
                    Guides[i].GetComponent<Guide>().SetInformation(guidesList, HeaderRU[i], BodiesRU[i], Type[i], Images[i]);
                }

                if (PlayerPrefs.HasKey(i.ToString("N0")))
                {
                    Guides[i].GetComponent<Guide>().SetFavorite();
                }
            }

            Refresh(Guides);
        }
    }

    public void Refresh(List<GameObject> Lists, bool RefreshNow = false)
    {
        CurrentList = Lists;

        for (int i = 0; i < Guides.Count; i++)
        {
            Guides[i].SetActive(false);
        }

        if (Lists.Count > 0)
        {
            float a = Lists.Count / 3f;
            if (a % 1 != 0)
            {
                a = a - (a % 1) + 1;
            }

            slider.maxValue = a - 1;
            if (!RefreshNow)
            {
                slider.value = 0;
            }
            else
            {
                if (slider.value > slider.maxValue)
                {
                    slider.value = slider.maxValue;
                }
            }

            for (int i = 0; i < Lists.Count; i++)
            {
                switch (i % 3)
                {
                    case 1:
                        Lists[i].transform.localPosition = new Vector3(0, -70);
                        break;
                    case 2:
                        Lists[i].transform.localPosition = new Vector3(0, -280);
                        break;
                    case 0:
                        Lists[i].transform.localPosition = new Vector3(0, 140);
                        break;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (i + 1 <= Lists.Count)
                {
                    Lists[i].SetActive(true);
                }
            }
        }
    }

    public void ChangeView()
    {
        FavoriteView = !FavoriteView;

        if (FavoriteView)
        {
            Refresh(Favorites);
        }
        else
        {
            Refresh(Guides);
        }
    }

    public void ToFavorites(GameObject Child)
    {
        if (Favorites.Contains(Child))
        {
            Favorites.Remove(Child);
            PlayerPrefs.DeleteKey(Guides.IndexOf(Child).ToString("N0"));
        }
        else
        {
            Favorites.Add(Child);
            PlayerPrefs.SetInt(Guides.IndexOf(Child).ToString("N0"), Guides.IndexOf(Child));
        }

        if (FavoriteView)
        {
            Refresh(Favorites, true);
        }
    }

    public void SliderSet()
    {
        for (int i = 0; i < CurrentList.Count; i++)
        {
            if (i == slider.value * 3 || i == slider.value * 3 + 1 || i == slider.value * 3 + 2)
            {
                CurrentList[i].SetActive(true);
            }
            else
            {
                CurrentList[i].SetActive(false);
            }

        }
    }

    public void ReLocalize()
    {
        for (int i = 0; i < Guides.Count; i++)
        {
            if (PlayerPrefs.GetString("Language") == "English")
            {
                Guides[i].GetComponent<Guide>().SetInformation(guidesList, Header[i], Bodies[i], Type[i], Images[i]);
            }
            else if (PlayerPrefs.GetString("Language") == "Russian")
            {
                Guides[i].GetComponent<Guide>().SetInformation(guidesList, HeaderRU[i], BodiesRU[i], Type[i], Images[i]);
            }

            if (PlayerPrefs.HasKey(i.ToString("N0")))
            {
                Guides[i].GetComponent<Guide>().SetFavorite();
            }
        }
    }
}
