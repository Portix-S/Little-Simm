using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int money = 100;

    [SerializeField] TextMeshProUGUI playerMoney;

    public bool Pay(int amount) // Tries to buy something
    {
        if (money - amount >= 0)
        {
            Debug.Log("paying");
            money -= amount;
            playerMoney.text = money.ToString();
            return true;
        }
        else
            return false;
    }
}
