using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Singleton { get; private set; }
    private void Awake()=>Singleton = this;
}
