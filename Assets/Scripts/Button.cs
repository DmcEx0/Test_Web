using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    private const string AnimationName = "anim";

    [SerializeField] private LoadSprites _loadSprites;
    [SerializeField] private Animator _animator;
    
    private readonly int _animationHash = Animator.StringToHash(AnimationName);

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Click");
        
        _animator.SetBool(_animationHash, true);
        _loadSprites.load();
    }
}
