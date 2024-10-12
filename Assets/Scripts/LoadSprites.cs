using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LoadSprites : MonoBehaviour
{
    private GameObject[] _spriteRenderer;
    private string[] strings;

    private void Start()
    {
        
    }

    private IEnumerator LoadSprite(SpriteRenderer spriteRenderer, int number) {
        var task = Addressables.LoadAssetAsync<Sprite>(strings[number]);
        yield return task;
        spriteRenderer.sprite = task.Result;
    }
    
    private async UniTask LoadSpriteAsync(SpriteRenderer spriteRenderer, int number)
    {
        var loadOperation = Addressables.LoadAssetAsync<Sprite>(strings[number]);

        await loadOperation.Task;
        
        spriteRenderer.sprite = loadOperation.Result;
    }

    public void Load()
    {
        for (int i = 0; i < _spriteRenderer.Length; i++)
        {
            StartCoroutine(LoadSprite(_spriteRenderer[i].GetComponent<SpriteRenderer>(), i));
        }
    }
}