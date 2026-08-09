using UnityEngine;
using System.Collections;

[CreateAssetMenu(
    fileName = "VerticalStretchTransition",
    menuName = "SO/Transition/VerticalStretch"
)]
public class VerticalStretchTransition : TransitionBehaviour
{
    [Header("アニメーション時間")]
    [SerializeField]
    private float duration = 0.6f;

    [Header("カラー")]
    [SerializeField]
    private Color color = Color.black;

    [Header("In用カーブ")]
    [SerializeField]
    private AnimationCurve stretchCurve =
        new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(0.55f, 0.7f),
            new Keyframe(0.8f, 1.05f),
            new Keyframe(1f, 1f)
        );

    [Header("Out用カーブ")]
    [SerializeField]
    private AnimationCurve outCurve =
        new AnimationCurve(
            new Keyframe(0f, 1f),
            new Keyframe(0.2f, 1.05f),
            new Keyframe(0.45f, 0.7f),
            new Keyframe(1f, 0f)
        );


    public override IEnumerator PlayIn(
        TransitionContext context)
    {
        if (context.Image == null)
            yield break;

        RectTransform rect =
            context.Image.rectTransform;

        context.Image.color = color;

        // 開始状態
        // 横幅は100%
        // 縦幅は0%
        rect.localScale =
            new Vector3(
                1f,
                0f,
                1f
            );

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            float t =
                Mathf.Clamp01(
                    timer / duration
                );

            float y =
                stretchCurve.Evaluate(t);

            // Xは常に1
            rect.localScale =
                new Vector3(
                    1f,
                    y,
                    1f
                );

            yield return null;
        }

        // 完了
        rect.localScale =
            new Vector3(
                1f,
                1f,
                1f
            );
    }


    public override IEnumerator PlayOut(
        TransitionContext context)
    {
        if (context.Image == null)
            yield break;

        RectTransform rect =
            context.Image.rectTransform;

        // 開始状態
        rect.localScale =
            new Vector3(
                1f,
                1f,
                1f
            );

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;

            float t =
                Mathf.Clamp01(
                    timer / duration
                );

            float y =
                outCurve.Evaluate(t);

            // Xは常に1
            rect.localScale =
                new Vector3(
                    1f,
                    y,
                    1f
                );

            yield return null;
        }

        // 完全に消える
        rect.localScale =
            new Vector3(
                1f,
                0f,
                1f
            );
    }
}