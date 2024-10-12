using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SpritesLoader : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _sprites;
    [SerializeField] private AssetReference[] _assetReferences;

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
        
        spriteRenderer.sprite = loadOperation.Result;
    }
}