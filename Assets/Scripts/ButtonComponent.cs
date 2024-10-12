using UnityEngine;
using UnityEngine.EventSystems;

namespace TestWeb
{
    public class ButtonComponent : MonoBehaviour, IPointerClickHandler
    {
        private const string AnimationName = "anim";

        [SerializeField] private SpritesLoader _spritesLoader;
        [SerializeField] private Animator _animator;
    
        private readonly int _animationHash = Animator.StringToHash(AnimationName);

        private bool _isPlaying;

        public void OnPointerClick(PointerEventData eventData) 
        {
            if (_isPlaying == true)
            {
                return;
            }
            
            _animator.SetBool(_animationHash, true);
            _spritesLoader.LoadSprite();

            _isPlaying = true;
        }
    }
}