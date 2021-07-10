using UnityEngine;
using UnityEngine.UI;

// Данный скрипт связывается с StaticOptions с меню настроек
public class Options : MonoBehaviour
{
    [SerializeField] Toggle Immortality;
    [SerializeField] Toggle FastQuit;

    private void Start()
    {
        Immortality.isOn = StaticOptions.Immortality;
        FastQuit.isOn = StaticOptions.FastQuit;
    }

    public void SetDifficulty(int i)
    {
        StaticOptions.GetDifficulty(i);
    }

    public void SetChunkCount(int i)
    {
        StaticOptions.GetChunkCount(i);
    }

    public void SetImmortality()
    {
        StaticOptions.GetImmortality(Immortality.isOn);
    }

    public void SetFastQuit()
    {
        StaticOptions.GetFastQuit(FastQuit.isOn);
    }

    public void SetQuality(int i)
    {
        StaticOptions.GetQuality(i);
    }
}
