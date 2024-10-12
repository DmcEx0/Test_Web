using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerClickHandler
{
    private const string AnimationName = "anim";

    [SerializeField] private SpritesLoader _spritesLoader;
    [SerializeField] private Animator _animator;
    
    private readonly int _animationHash = Animator.StringToHash(AnimationName);

    public void OnPointerClick(PointerEventData eventData) 
    {
        Debug.Log("Click");
        
        _animator.SetBool(_animationHash, true);
        _spritesLoader.LoadSprite();
    }
}