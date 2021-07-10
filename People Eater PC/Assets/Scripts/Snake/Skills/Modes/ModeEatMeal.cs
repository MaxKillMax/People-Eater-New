using UnityEngine;

public class ModeEatMeal : MonoBehaviour
{
    [SerializeField] TriggerEatMeal triggerEat;
    [SerializeField] MeshRenderer DestroyRadius;
    [SerializeField] Material ActivateOn;
    [SerializeField] Material ActivateOff;
    private bool Click = false;

    public void Activate()
    {
        Click = true;
        DestroyRadius.material = ActivateOn;
    }

    private void Update()
    {
        if (Click && Input.GetKeyUp(KeyCode.H))
        {
            Click = false;
            triggerEat.DestroyMeatBalls();
            DestroyRadius.material = ActivateOff;
        }
    }
}
