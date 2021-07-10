using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ModeFeverReverse : MonoBehaviour
{
    [SerializeField] Image FillSprite;
    [SerializeField] Text FillText;

    [SerializeField] private Snake snake;
    [SerializeField] SnakeMove snakeMove;
    [SerializeField] SkillController skillController;

    private float ImmortalityTimer = 0;
    private float FeverReverseTimer = 0;
    public void Activate()
    {
        snakeMove.UseModeFeverReverse();

        FillSprite.gameObject.SetActive(true);
        FillSprite.fillAmount = 1;
        FillText.text = snake.FeverReverseTimer.ToString("N1", CultureInfo.CurrentCulture);

        snake.Speed /= 2;
        FeverReverseTimer = snake.FeverReverseTimer;

        if (!StaticOptions.Immortality)
        {
            StaticOptions.Immortality = true;
            ImmortalityTimer = FeverReverseTimer + snake.ImmortalityAddTimer;
        }
    }

    private void Update()
    {
        if (ImmortalityTimer > 0)
        {
            snake.Speed *= 2;
            ImmortalityTimer -= Time.deltaTime;

            if (ImmortalityTimer <= 0)
            {
                ImmortalityTimer = 0;
                skillController.ActiveSkill = false;
                StaticOptions.Immortality = false;
            }
        }

        if (FeverReverseTimer > 0)
        {
            FillSprite.fillAmount = FeverReverseTimer / snake.FeverReverseTimer;
            FillText.text = FeverReverseTimer.ToString("N1", CultureInfo.CurrentCulture);

            FeverReverseTimer -= Time.deltaTime;
            if (FeverReverseTimer <= 0)
            {
                FillSprite.gameObject.SetActive(false);

                FeverReverseTimer = 0;
            }
        }
    }
}
