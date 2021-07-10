using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ModeTranquility : MonoBehaviour
{
    [SerializeField] Image FillSprite;
    [SerializeField] Text FillText;

    [SerializeField] private Snake snake;
    [SerializeField] SnakeMove snakeMove;
    [SerializeField] SkillController skillController;

    private float TranquilityTimer;

    public void Activate()
    {
        FillSprite.gameObject.SetActive(true);
        FillSprite.fillAmount = 1;
        FillText.text = snake.TranquilityTimer.ToString("N1", CultureInfo.CurrentCulture);

        snakeMove.UseModeTranquility();
        TranquilityTimer = snake.TranquilityTimer;
    }

    private void Update()
    {
        if (TranquilityTimer > 0)
        {
            FillSprite.fillAmount = TranquilityTimer / snake.TranquilityTimer;
            FillText.text = TranquilityTimer.ToString("N1", CultureInfo.CurrentCulture);

            TranquilityTimer -= Time.deltaTime;
            if (TranquilityTimer <= 0)
            {
                FillSprite.gameObject.SetActive(false);

                snakeMove.UseModeTranquility();
                TranquilityTimer = 0;
                skillController.ActiveSkillSafe = false;
            }
        }
    }
}
