using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration of the fade-out effect
    public float delayBeforeFade = 3.0f; // Delay before starting the fade-out
    private float fadeTimer = 0.0f;
    private bool isFading = false;

    private Text textComponent; // Reference to the Text component

    void Start()
    {
        textComponent = this.gameObject.GetComponent<Text>();

        Invoke("StartFade", delayBeforeFade);
    }

    void StartFade()
    {
        isFading = true;
    }

    void Update()
    {
        if (isFading)
        {
            fadeTimer += Time.deltaTime;
            float alpha = 1.0f - (fadeTimer / fadeDuration);
            Color textColor = textComponent.color;
            textColor.a = Mathf.Clamp01(alpha);
            textComponent.color = textColor;

            if (fadeTimer >= fadeDuration)
            {
                // Fade-out completed
                isFading = false;
                // Optionally, you can perform some action after the fade-out
                this.gameObject.SetActive(false);
            }
        }
    }
}
