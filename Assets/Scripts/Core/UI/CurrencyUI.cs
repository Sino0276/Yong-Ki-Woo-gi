using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    public void FixedUpdate()
    {
        coinText.text = Managers.User.Currency.Coin.ToString();
    }
}
