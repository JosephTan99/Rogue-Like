using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;

    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;
    private Coroutine flashCoroutine;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        if(flashCoroutine != null) StopCoroutine(flashCoroutine);
        flashCoroutine = StartCoroutine(FlashCoroutine());
    }

    private void Update()
    {
        
    }

    private IEnumerator FlashCoroutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.material = originalMaterial;
        flashCoroutine = null;
    }
}
