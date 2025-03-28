using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinGameBeforeYouLearnMVC : MonoBehaviour
{
    public Button WorkButton;
    public TMP_Text CoinsText;

    public int coins;

    void Start()
    {
        WorkButton.onClick.AddListener(Work);
    }

    // We are handling business logic, data and view logic in the same script
    public void Work()
    {
        coins++;                                      // Data
        CoinsText.text = coins.ToString() + " coins"; // View Logic
    }
}
