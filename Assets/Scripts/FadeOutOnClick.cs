using UnityEngine;

public class FadeOutOnClick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isFading = false;
    private float fadeSpeed = 1f;
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
            
            Color color = spriteRenderer.color;
            color.a -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = color;

   
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
