using TMPro;
using UnityEngine;

public class UITurnCommandLine : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    public void SetText(string commandName)
    {
        _text.text = commandName;
    }
}
