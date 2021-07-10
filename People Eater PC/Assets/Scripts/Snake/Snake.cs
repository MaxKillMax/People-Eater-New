using UnityEngine;
using System.Globalization;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [SerializeField] Text DistanceText;
    [SerializeField] Text CrystalsText;
    [SerializeField] Text LengthText;

    private int length;
    private int crystals;
    private float distance;

    private int sumLength;
    private int sumCrystals;

    private float HardcoreMultiply = 1;

    private float speed = 200;
    private float slower = 100;
    private float faster = 200;
    private float attackDamage = 700;
    private float feverTimer = 5;
    private float feverReverseTimer = 5;
    private float immortalityAddTimer = 0.5f;
    private float speedTimerSlower = 60;
    private float turnSlower = 5;
    private float zoneScale = 1.0f;
    private float eliminateSpikeZoneScale = 1;
    private float eliminateSpikeZoneLength = 20;
    private float eatMealZoneScale = 10;
    private float rabidBoost = 3;
    private float rabidTimer = 5;
    private float tranquilityTimer = 20;

    private int feverCost = 9;
    private int feverReverseCost = 6;
    private int tailGrowingCost = 2;
    private int foodForChildrenCost = 8;
    private int eliminateSpikeCost = 3;
    private int eatMealCost = 10;
    private int rabidCost = 4;
    private int tranquilityCost = 8;

    public int Length { get { return length; } set { length = value; LengthText.text = length.ToString("N0", CultureInfo.CurrentCulture); } }
    public int Crystals { get { return crystals; } set { crystals = value; CrystalsText.text = crystals.ToString("N0", CultureInfo.CurrentCulture); } }
    public float Distance { get { return distance; } set { distance = value; DistanceText.text = distance.ToString("N0", CultureInfo.CurrentCulture); } }
    public int SumLength { get { return sumLength; } set { sumLength = value; } }
    public int SumCrystals { get { return sumCrystals; } set { sumCrystals = value; } }

    public float Speed { get { return speed; } set { speed = value; } }
    public float Slower { get { return slower; } set { slower = value; } }
    public float Faster { get { return faster; } set { faster = value; } }
    public float AttackDamage { get { return attackDamage; } set { attackDamage = value; } }
    public float FeverTimer { get { return feverTimer; } set { feverTimer = value; } }
    public float FeverReverseTimer { get { return feverReverseTimer; } set { feverReverseTimer = value; } }
    public float ImmortalityAddTimer { get { return immortalityAddTimer; } set { immortalityAddTimer = value; } }
    public float SpeedTimerSlower { get { return speedTimerSlower; } set { speedTimerSlower = value; } }
    public float TurnSlower { get { return turnSlower; } set { turnSlower = value; } }
    public float ZoneScale { get { return zoneScale; } set { zoneScale = value; GetComponentInChildren<Zone>().SetScale(); } }
    public float EliminateSpikeZoneScale { get { return eliminateSpikeZoneScale; } set { eliminateSpikeZoneScale = value; GetComponentInChildren<TriggerEliminateSpikes>().SetScale(); } }
    public float EliminateSpikeZoneLength { get { return eliminateSpikeZoneLength; } set { eliminateSpikeZoneLength = value; GetComponentInChildren<TriggerEliminateSpikes>().SetScale(2); } }
    public float EatMealZoneScale { get { return eatMealZoneScale; } set { eatMealZoneScale = value; GetComponentInChildren<TriggerEatMeal>().SetScale(); } }
    public float RabidBoost { get { return rabidBoost; } set { rabidBoost = value; } }
    public float RabidTimer { get { return rabidTimer; } set { rabidTimer = value; } }
    public float TranquilityTimer { get { return tranquilityTimer; } set { tranquilityTimer = value; } }

    public int FeverCost { get { return feverCost; } set { feverCost = value; } }
    public int FeverReverseCost { get { return feverReverseCost; } set { feverReverseCost = value; } }
    public int TailGrowingCost { get { return tailGrowingCost; } set { tailGrowingCost = value; } }
    public int FoodForChildrenCost { get { return foodForChildrenCost; } set { foodForChildrenCost = value; } }
    public int EliminateSpikeCost { get { return eliminateSpikeCost; } set { eliminateSpikeCost = value; } }
    public int EatMealCost { get { return eatMealCost; } set { eatMealCost = value; } }
    public int RabidCost { get { return rabidCost; } set { rabidCost = value; } }
    public int TranquilityCost { get { return tranquilityCost; } set { tranquilityCost = value; } }

    public void SetMultiply(float Number)
    {
        HardcoreMultiply = 1 + Number;
    }

    public int GetScore()
    {
        return (int)((sumCrystals * 6 + sumLength * 30 + distance) * HardcoreMultiply);
    }

    public int[] GetStats()
    {
        int[] Stats = new int[] { sumLength, sumCrystals, (int)distance };
        return Stats;
    }
}
