using UnityEngine;
using UnityEngine.UI;

public class TransitionContext
{
    public CanvasGroup CanvasGroup { get; }
    public Image Image { get; }

    public TransitionContext(
        CanvasGroup canvasGroup,
        Image image)
    {
        CanvasGroup = canvasGroup;
        Image = image;
    }
}