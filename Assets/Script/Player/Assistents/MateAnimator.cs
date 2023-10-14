using UnityEngine;

[RequireComponent(typeof(Mate))]
public class MateAnimator : MonoBehaviour
{
    private Mate _link;
    [SerializeField] private Animator _anim;
    private void Start()
    {
        _link = GetComponent<Mate>();
        _link.OnMove += () => _anim.SetBool("Run", true);
        _link.OnTargetFounded += () => _anim.SetBool("Attack", true);
        _link.OnTargetLoss += () => _anim.SetBool("Attack", false);
        _link.OnStay += () => _anim.SetBool("Run", false);
        
    }
}
