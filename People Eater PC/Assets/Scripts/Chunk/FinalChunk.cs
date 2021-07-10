using UnityEngine;

public class FinalChunk : MonoBehaviour
{
    private GameManagment gameManagment;
    public void GetInformation(GameManagment gameManagment)
    {
        this.gameManagment = gameManagment;
    }

    public void SetFinal()
    {
        gameManagment.OpenFinalWindow();
    }
}
