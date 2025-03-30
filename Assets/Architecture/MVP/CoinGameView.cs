using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinGameView : MonoBehaviour
{
    [field: SerializeField] public Button WorkButton { get; private set; }
    [field: SerializeField] public TMP_Text CoinsText { get; set; }

    public void UpdateCoins(int coins)
    {
        CoinsText.text = coins.ToString() + " coins";
    }
}
