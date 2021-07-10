using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ModeRabid : MonoBehaviour
{
    [SerializeField] Image FillSprite;
    [SerializeField] Text FillText;

    [SerializeField] Snake snake;
    [SerializeField] SkillController skillController;
    private float RabidTimer;
    private float Helper;
    public void Activate()
    {
        FillSprite.gameObject.SetActive(true);
        FillSprite.fillAmount = 1;
        FillText.text = snake.RabidTimer.ToString("N1", CultureInfo.CurrentCulture);

        Helper = snake.TurnSlower;
        snake.TurnSlower = snake.RabidBoost;
        RabidTimer = snake.RabidTimer;
    }

    private void Update()
    {
        if (RabidTimer > 0)
        {
            FillSprite.fillAmount = RabidTimer / snake.RabidTimer;
            FillText.text = RabidTimer.ToString("N1", CultureInfo.CurrentCulture);

            RabidTimer -= Time.deltaTime;
            if (RabidTimer <= 0)
            {
                FillSprite.gameObject.SetActive(false);

                RabidTimer = 0;
                skillController.ActiveSkillSafe = false;
                snake.TurnSlower = Helper;
            }
        }
    }
}
