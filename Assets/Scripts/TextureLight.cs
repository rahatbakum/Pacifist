using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TextureLight : MonoBehaviour
{
    [Header ("Gradient")]
    public float startRadius = 0f;
    public float finishRadius = 512f;
    public Color startColor = Color.white;
    public Color finishColor = Color.white;

    [Header ("Render")]
    public int[] textureSize = new int[2] { 1024, 1024 };
    public float pixelsPerUnit = 100f;
    public int orderInLayer = 0;
    private SpriteRenderer thisSpriteRenderer;
    void Start()
    {
        getSpriteRenderer();
        setSpriteRenderer(createSprite());
    }

    #if UNITY_EDITOR
    [ContextMenu("Update In Editor")]
    void UpdateInEditor()
    {
        setSpriteRenderer(createSprite());
    }
    #endif
    
    Sprite createSprite()
    {
        Sprite resultSprite;
        Texture2D bufferTexture = new Texture2D(textureSize[0], textureSize[1]);
        bufferTexture.filterMode = FilterMode.Bilinear;

        for (int i = 0; i < textureSize[0]; i++)
            for (int j = 0; j < textureSize[1]; j++)
            {
                bufferTexture.SetPixel(i, j, Color.Lerp(startColor, finishColor, getColorValue(i, j)));
            }
        bufferTexture.Apply();

        resultSprite = Sprite.Create(bufferTexture, new Rect(0f, 0f, textureSize[0], textureSize[1]), new Vector2(0.5f, 0.5f), pixelsPerUnit);
        
        return resultSprite;
    }

    void getSpriteRenderer()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        if (!thisSpriteRenderer)
            thisSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
    }

    void setSpriteRenderer(Sprite currentSprite){
        if(!thisSpriteRenderer)
            getSpriteRenderer();
        thisSpriteRenderer.sortingOrder = orderInLayer;
        thisSpriteRenderer.sprite = currentSprite;
    }

    float getColorValue(int x, int y)
    {
        float distanceToCenter = Mathf.Pow(Mathf.Pow(x - textureSize[0] * 0.5f, 2) + Mathf.Pow(y - textureSize[1] * 0.5f, 2), 0.5f);
        return (Mathf.Clamp(distanceToCenter, startRadius, finishRadius) - startRadius) / (finishRadius - startRadius);
    }

}
