using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI textMesh; // Замените на Text, если используете стандартный текст

    public float blinkInterval = 0.1f; // Интервал между миганиями

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // Включаем или выключаем текст
            textMesh.enabled = !textMesh.enabled;

            // Ждем заданный интервал
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
