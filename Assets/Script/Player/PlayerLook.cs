
using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class PlayerLook : MonoBehaviour
{
    public Camera _cam;
    [SerializeField] private Slider _sensitivitySlider;
    [SerializeField] float xRotation = 0f;
     public float xSensitivity = 20f;
    [SerializeField] private float ySensitivity = 20f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

         _sensitivitySlider.minValue = 0f;
        _sensitivitySlider.maxValue = 40f;
        _sensitivitySlider.value = xSensitivity;

        _sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    public void UpdateSensitivity(float value)
    {
        xSensitivity = value;
        ySensitivity = value;
        _sensitivitySlider.value = value;
    }
    public void UpdateSliderValue(float newValue) =>
       _sensitivitySlider.value = newValue;

    public void ProcessLook(Vector2 input)
    {
        xRotation -= input.y * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);
        _cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * input.x * Time.deltaTime * xSensitivity);
    }
}
