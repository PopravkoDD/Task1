using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _buttonTwo;
    [SerializeField] private string _message;
    [SerializeField] private TMP_Text _textField;
    void Start()
    {
        _buttonTwo.onClick.AddListener(SetText);
    }

    private void SetText()
    {
        _textField.text = _message;
    }
}
