using UnityEngine;
using UnityEngine.EventSystems;

public class PerkButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] PerkChoose perkChoose;
    [SerializeField] int ID;
    public void OnPointerClick(PointerEventData eventData)
    {
        perkChoose.Pick(ID);
    }
}
