using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _prompText;
 

    public void UpdateText(string prompMessage)
    {
        _prompText.text = prompMessage;
    }
  
    private void Start()
    {
       
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        
    }

}
