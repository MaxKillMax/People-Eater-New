using System.Collections.Generic;
using UnityEngine;

public class OnDeath : MonoBehaviour
{
    [SerializeField] Snake snake;
    [SerializeField] GameObject PreMenu;
    [SerializeField] GameObject PreTwoMenu;
    [SerializeField] GameObject InfoMenu;
    [SerializeField] GameObject MenuContinue;
    [SerializeField] GameObject MenuControls;
    [SerializeField] GameManagment gameManagment;

    [HideInInspector] public List<float> ShortImmortality = new List<float>();
    private bool ActivateShort;

    public bool DestroySnake()
    {
        // Через этот метод происходит умерщвление змейки
        if (!StaticOptions.Immortality)
        {
            if (ShortImmortality.Count <= 0)
            {
                InfoMenu.SetActive(false);
                PreMenu.SetActive(true);
                PreTwoMenu.SetActive(true);
                MenuContinue.SetActive(false);
                MenuControls.SetActive(false);
                gameManagment.enabled = false;
                Score.AddLastMatch(snake.GetScore(), snake.GetStats());
                Destroy(transform.parent.gameObject);
                return true;
            }
            else
            {
                ActivateShort = true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (ActivateShort)
        {
            ShortImmortality[ShortImmortality.Count - 1] -= Time.deltaTime;

            if (ShortImmortality[ShortImmortality.Count - 1] <= 0)
            {
                ShortImmortality.RemoveAt(ShortImmortality.Count - 1);
                ActivateShort = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Eat" || collision.gameObject.tag == "Crystal")
        {
            DestroySnake();
        }
    }
}
