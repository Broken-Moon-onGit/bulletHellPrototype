using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toggleFunctionality : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TMP_Text textfield;
    [SerializeField] private string message;

    private void OnEnable()
    {
        toggle.onValueChanged.AddListener(SendMessage);
    }
    private void OnDisable()
    {
        toggle.onValueChanged.RemoveListener(SendMessage);
    }

    private void SendMessage(bool toggleValue)
    {
        if (toggleValue)
        {
            textfield.SetText(message);
        }
        else
        {
            textfield.SetText(sourceText:"N/A");
        }
    }

    public void ToggleValueThroughScript()
    {
        toggle.isOn = !toggle.isOn;
    }

}
