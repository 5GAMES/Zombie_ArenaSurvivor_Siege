using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] GameObject _door;
    bool _doorOpen;
   protected override void Interact()
    {
        _doorOpen = !_doorOpen;
        _door.GetComponent<Animator>().SetBool("IsOpen", _doorOpen);
    }
}
