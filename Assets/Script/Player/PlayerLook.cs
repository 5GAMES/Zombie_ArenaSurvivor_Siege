
using System.Collections;

using UnityEngine;
using UnityEngine.UI;


public class PlayerLook : MonoBehaviour
{

    private WeaponController weaponController;
    public Camera _cam;
    [SerializeField] float xRotation = 0f;

    [SerializeField]  private float xSensitivity = 20f;
    [SerializeField]  private float ySensitivity = 20f;

   // [Header("SensitivitySlider")]
    //[SerializeField] private Slider _sensitivitySlider;
    //public float _sensitivity = 0f;
    //public bool _Issensitivity;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // _sensitivitySlider.minValue = 0f;
        // _sensitivitySlider.maxValue = 40f;
        // _sensitivitySlider.value = xSensitivity;

        // _sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);


    }
    private void Update()
    {
        weaponController = FindObjectOfType<WeaponController>();
        //Debug.Log(_sensitivity);

    }
    //public void UpdateSensitivity(float value)
    //{
    //    xSensitivity = value;
    //    ySensitivity = value;
    //    _sensitivitySlider.value = value;

    //}
    //public void UpdateSliderValue(float newValue)
    //{
    //    _sensitivitySlider.value = newValue;
    //}
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -25f, 25f);
        _cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0);

        //weaponController.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);

    }
}
