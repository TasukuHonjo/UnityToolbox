using UnityEngine;
using System.Collections;

[CreateAssetMenu(
    fileName = "FadeTransition",
    menuName = "SO/Transition/Fade"
)]
public class FadeTransition : TransitionBehaviour
{
    [Header("フェード時間")]
    [SerializeField]
    private float duration = 0.5f;

    [Header("フェードカラー")]
    [SerializeField]
    private Color color = Color.black;

    [Header("補間カーブ")]
    [SerializeField]
    private AnimationCurve curve =
        AnimationCurve.EaseInOut(
            0f, 0f,
            1f, 1f
        );


    public override IEnumerator PlayIn(
        TransitionContext context)
    {
        if (context.Image != null)
        {
            context.Image.color = color;
        }

        if (context.CanvasGroup == null)
            yield break;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            float t =
                Mathf.Clamp01(timer / duration);

            t = curve.Evaluate(t);

            context.CanvasGroup.alpha = t;

            yield return null;
        }

        context.CanvasGroup.alpha = 1f;
    }


    public override IEnumerator PlayOut(
        TransitionContext context)
    {
        if (context.CanvasGroup == null)
            yield break;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            float t =
                Mathf.Clamp01(timer / duration);

            t = curve.Evaluate(t);

            context.CanvasGroup.alpha = 1f - t;

            yield return null;
        }

        context.CanvasGroup.alpha = 0f;
    }
}