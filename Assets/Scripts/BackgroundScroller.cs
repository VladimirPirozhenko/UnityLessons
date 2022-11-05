using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private Vector2 velocity;
    private Renderer textureRenderer;
    void Start()
    {
        textureRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(velocity.x * Time.time, velocity.y * Time.time);
        textureRenderer.material.mainTextureOffset = textureOffset;
        //textureRenderer.material.SetTextureOffset("_MainTex", textureOffset);
    }
}
