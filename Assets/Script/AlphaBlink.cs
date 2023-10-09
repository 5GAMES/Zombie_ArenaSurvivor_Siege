using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaBlink : MonoBehaviour
{
    private Image image;
    public float blinkSpeed = 1.0f;
    private bool isFadingOut = false;

    void Start()
    {
        image = GetComponent<Image>();
        // ��������� �������
        InvokeRepeating("ToggleAlpha", 0, blinkSpeed);
    }

    void ToggleAlpha()
    {
        // ���� �����-�������� ��������� �� 0 ��� 1, ������ �����������
        if (image.color.a <= 0 || image.color.a >= 1)
        {
            isFadingOut = !isFadingOut;
        }

        // �������� �����-�������� � ����������� �� �����������
        if (isFadingOut)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - 0.1f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + 0.1f);
        }
    }
}
