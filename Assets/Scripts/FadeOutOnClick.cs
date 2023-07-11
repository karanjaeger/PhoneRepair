using UnityEngine;

public class FadeOutOnClick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isFading = false;
    private float fadeSpeed = 0.5f;
    public delegate void SpriteFade();
    public static event SpriteFade OnSpriteFade;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isFading)
        {
            // Reduce the alpha value of the sprite renderer color gradually
            Color color = spriteRenderer.color;
            color.a -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = color;

            // If the alpha value reaches 0, destroy the GameObject
            if (color.a <= 0)
            {
                Destroy(gameObject);
                OnSpriteFade();
            }
        }
    }

    private void OnMouseUp()
    {
        isFading = true;
    }
}
