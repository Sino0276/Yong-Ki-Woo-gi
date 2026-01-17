using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    public void Start()
    {
        coinText.text = Managers.User.Currency.Coin.Value.ToString();

        Managers.User.Currency.Coin.OnValueChange += OnCoinValueChange;
    }

    private void OnCoinValueChange(int oldValue, int newValue)
    {
        coinText.text = newValue.ToString();
    }
}
