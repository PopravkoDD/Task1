using TMPro;
using UnityEngine;

public class DropdownController : MonoBehaviour
{
    [SerializeField] private TMP_Text message;
    [SerializeField] private string firstMessage;
    [SerializeField] private string secondMessage;
    [SerializeField] private string thirdMessage;

    public void SetMessage(int index)
    {
        switch (index)
        {
            case 0: message.text = firstMessage;
                break;
            case 1: message.text = secondMessage;
                break;
            case 2: message.text = thirdMessage;
                break;
        }
    }

}
