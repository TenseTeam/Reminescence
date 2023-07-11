using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Factory 
{
    /// <summary>
    /// factory method for create a new event manager
    /// </summary>
    /// <returns></returns>
    public static EventManager CreateEvenetManager()
    {
        return new EventManager();
    }
    
    public static GameObject CreateHighlightSprite(SpriteRenderer spriteRenderer, Color highlightColor, float highlightWidth)
    {
        Material spriteMaterial = spriteRenderer.material;

        // Create a new material for the highlight effect
        Material highlightMaterial = new Material(Shader.Find("Sprites/Default"));

        // Create a new object with a SpriteRenderer component to display the highlight
        GameObject highlightObject = new GameObject("Highlight");
        SpriteRenderer highlightRenderer = highlightObject.AddComponent<SpriteRenderer>();
        highlightRenderer.sprite = spriteRenderer.sprite;
        highlightRenderer.material = highlightMaterial;

        // Update the position and scale of the highlight object to match the sprite
        highlightRenderer.transform.position = spriteRenderer.transform.position;
        highlightRenderer.transform.parent = spriteRenderer.transform;
        highlightRenderer.transform.rotation = spriteRenderer.transform.rotation;
        highlightRenderer.transform.localScale = spriteRenderer.transform.localScale + Vector3.one * highlightWidth;

        highlightRenderer.sortingOrder = 1;
        // Set the color of the highlight
        highlightMaterial.color = highlightColor;

        // Copy the other parameters from the original sprite material to the highlight material
        highlightMaterial.mainTexture = spriteMaterial.mainTexture;
        highlightMaterial.mainTextureOffset = spriteMaterial.mainTextureOffset;
        highlightMaterial.mainTextureScale = spriteMaterial.mainTextureScale;

        return highlightObject;
    }
}
