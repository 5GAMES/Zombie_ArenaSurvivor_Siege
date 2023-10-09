using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI textMesh; // �������� �� Text, ���� ����������� ����������� �����

    public float blinkInterval = 0.1f; // �������� ����� ���������

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            // �������� ��� ��������� �����
            textMesh.enabled = !textMesh.enabled;

            // ���� �������� ��������
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
