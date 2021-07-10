using UnityEngine;

public static class StaticControls
{
    static KeyCode Quit;
    static KeyCode Zoom;

    public static void SetNum(string Type, KeyCode key)
    {
        switch (Type)
        {
            case "Quit":
                Quit = key;
                PlayerPrefs.SetString("Quit", key.ToString());
                break;
            case "Zoom":
                Zoom = key;
                PlayerPrefs.SetString("Zoom", key.ToString());
                break;
            default:
                Debug.LogError("Несуществующий тип: " + Type);
                break;
        }
    }

    public static KeyCode GetNum(string Type)
    {
        switch(Type)
        {
            case "Quit":
                return Quit;
            case "Acceleration":
                return KeyCode.W;
            case "Deceleration":
                return KeyCode.S;
            case "Zoom":
                return Zoom;
            case "Ability1":
                return KeyCode.A;
            case "Ability2":
                return KeyCode.D;
            default:
                Debug.LogError("Несуществующий тип: " + Type);
                return KeyCode.None;
        }
    }

    public static string GetAbility(string KeyCode)
    {
        switch(KeyCode)
        {
            case "A":
                return PlayerPrefs.GetString("A");
            case "D":
                return PlayerPrefs.GetString("D");
            default:
                Debug.LogError("Несуществующая кнопка: " + KeyCode);
                return "Wrong";
        }
    }

    public static void SetAbilityA(string key)
    {
        PlayerPrefs.SetString("A", key);
    }

    public static void SetAbilityD(string key)
    {
        PlayerPrefs.SetString("D", key);
    }
}
