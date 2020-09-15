using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyTxt;

    private void Update()
    {
        moneyTxt.text = "$" + playerStats.Money;
    }
}
