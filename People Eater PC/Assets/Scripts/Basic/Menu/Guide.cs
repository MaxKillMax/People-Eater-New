using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] List<string> TagNames = new List<string>();
    [SerializeField] List<Sprite> TagIcons = new List<Sprite>();
    [Header("Structure")]
    [SerializeField] Image MainImage;
    [SerializeField] Image TagImage;
    [SerializeField] Text Head;
    [SerializeField] Text Body;
    [SerializeField] Text Type;
    [Header("Other")]
    [SerializeField] Color color;
    [SerializeField] Image Favorite;

    private bool IsFavorite;
    private GuidesList Parent;

    public void SetInformation(GuidesList Parent, string Head, string Body, string Type, Sprite sprite)
    {
        this.Head.text = Head;
        this.Body.text = Body;
        this.Type.text = "#" + Type;

        MainImage.sprite = sprite;
        MainImage.color = color;
        this.Parent = Parent;

        for (int i = 0; i < TagNames.Count; i++)
        {
            if (Type == TagNames[i])
            {
                TagImage.sprite = TagIcons[i];
                TagImage.color = color;
                break;
            }

            if (i == TagNames.Count - 1)
            {
                this.Type.transform.localPosition = new Vector3(665, 325, 0);
                TagImage.enabled = false;
                Debug.LogWarning("У статьи: " + Head + " - тег " + Type + " не обнаружен.");
            }
        }
    }

    public void SetFavorite()
    {
        IsFavorite = !IsFavorite;

        if (IsFavorite)
        {
            Favorite.color = Color.red;
            Parent.ToFavorites(this.gameObject);
        }
        else
        {
            Favorite.color = Color.white;
            Parent.ToFavorites(this.gameObject);
        }
    }
}
