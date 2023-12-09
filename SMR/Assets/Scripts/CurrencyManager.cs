using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static int virtualCurrency = 0;

    public static void AddCurrency(int amount)
    {
        virtualCurrency += amount;
    }
}