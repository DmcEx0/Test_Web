using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace TestWeb
{
    public class SpritesLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _sprites;
        [SerializeField] private AssetReference[] _assetReferences;

        private List<AsyncOperationHandle> _operationHandles;

        private void Start()
        {
            _operationHandles = new();
        }

        private void OnDestroy()
        {
            foreach (var operationHandle in _operationHandles)
            {
                Addressables.Release(operationHandle);
            }
        }

        public void LoadSprite()
        {

            for (int i = 0; i < _sprites.Length; i++)
            {
                LoadSpriteAsync(_sprites[i], i).Forget();
            }
        }
    
        private async UniTask LoadSpriteAsync(SpriteRenderer spriteRenderer, int number)
        {
            var loadOperation = Addressables.LoadAssetAsync<Sprite>(_assetReferences[number]);
            await loadOperation.ToUniTask();
        
            _operationHandles.Add(loadOperation);
        
            spriteRenderer.sprite = loadOperation.Result;
        }
    }
}