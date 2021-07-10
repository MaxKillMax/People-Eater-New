using UnityEngine;

public class ModeEliminateSpikes : MonoBehaviour
{
    [SerializeField] TriggerEliminateSpikes triggerEliminate;
    [SerializeField] MeshRenderer DestroyLine;
    [SerializeField] Material ActivateOn;
    [SerializeField] Material ActivateOff;
    private bool Click = false;

    public void Activate()
    {
        Click = true;
        DestroyLine.material = ActivateOn;
    }

    private void Update()
    {
        if (Click && Input.GetKeyUp(KeyCode.E))
        {
            Click = false;
            triggerEliminate.DestroySpikes();
            DestroyLine.material = ActivateOff;
        }
    }
}
