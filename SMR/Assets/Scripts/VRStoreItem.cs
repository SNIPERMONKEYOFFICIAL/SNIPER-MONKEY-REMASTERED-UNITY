using UnityEngine;

public class VRStoreItem : MonoBehaviour
{
    public int itemPrice;

    void PurchaseItem()
    {
        if (CurrencyManager.virtualCurrency >= itemPrice)
        {
            CurrencyManager.AddCurrency(-itemPrice);
            Debug.Log("Item purchased!");
            // Add logic here to grant the item to the player
        }
        else
        {
            Debug.Log("Not enough currency!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        PurchaseItem();
    }
}
