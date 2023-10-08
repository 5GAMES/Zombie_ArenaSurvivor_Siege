using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] float _distance = 3f;
    [SerializeField] LayerMask _mask;
    private PlayerUI _playerUI;
    private PlayerMovement _inputManager;
    private void Start()
    {
        _cam = GetComponent<PlayerLook>()._cam;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        _playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, _distance, _mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                _playerUI.UpdateText(interactable.promptMessage);
                if(_inputManager.OnFoot.interact.triggered)
                {
                  interactable.BaseInteract();
                }
            }
        }
    }
}
