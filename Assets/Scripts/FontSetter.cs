using TMPro;
using UnityEngine;

[DefaultExecutionOrder(10)]
[RequireComponent(typeof(TMP_Text))]
public class FontSetter : MonoBehaviour
{

    public string fontClass;

    private void OnEnable()
    {
        // Subscribe to the event
        OptionsManager.FontUpdated += SetFont;
        SetFont();
    }

    private void OnDisable()
    {
        // Unsubscribe to prevent memory leaks
        OptionsManager.FontUpdated -= SetFont;
    }

    private void SetFont()
    {

        TMP_Text textComponent = GetComponent<TMP_Text>();
        if (textComponent != null && GameManager.Instance.OptionsManager != null)
        {
            if (GameManager.Instance.OptionsManager != null)
                textComponent.font = GameManager.Instance.OptionsManager.GetFontClass(fontClass);
        }
    }
}
