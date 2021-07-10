using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ModeFever : MonoBehaviour
{
    [SerializeField] Image FillSprite;
    [SerializeField] Text FillText;

    [SerializeField] private Snake snake;
    [SerializeField] SnakeMove snakeMove;
    [SerializeField] SkillController skillController;

    private float ImmortalityTimer = 0;
    private float FeverTimer = 0;

    public void Activate()
    {
        snakeMove.UseModeFever();

        FillSprite.gameObject.SetActive(true);
        FillSprite.fillAmount = 1;
        FillText.text = snake.FeverTimer.ToString("N1", CultureInfo.CurrentCulture);

        transform.eulerAngles = new Vector3(0, 0, -90);
        FeverTimer = snake.FeverTimer;

        if (!StaticOptions.Immortality)
        {
            StaticOptions.Immortality = true;
            ImmortalityTimer = FeverTimer + snake.ImmortalityAddTimer;
        }
    }

    private void Update()
    {
        if (ImmortalityTimer > 0)
        {
            ImmortalityTimer -= Time.deltaTime;

            if (ImmortalityTimer <= 0)
            {
                ImmortalityTimer = 0;
                skillController.ActiveSkill = false;
                StaticOptions.Immortality = false;
            }
        }

        if (FeverTimer > 0)
        {
            FillSprite.fillAmount = FeverTimer / snake.FeverTimer;
            FillText.text = FeverTimer.ToString("N1", CultureInfo.CurrentCulture);

            FeverTimer -= Time.deltaTime;
            if (FeverTimer <= 0)
            {
                FillSprite.gameObject.SetActive(false);

                snakeMove.UseModeFever();
                FeverTimer = 0;
            }
        }
    }
}
