using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransitionController : MonoBehaviour
{
    [Header("Transition")]
    [SerializeField]
    private TransitionBehaviour transition;

    [Header("Transition UI")]
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image transitionImage;


    private TransitionContext context;


    public TransitionBehaviour Transition
    {
        get => transition;
    }


    private void Awake()
    {
        context = new TransitionContext(
            canvasGroup,
            transitionImage
        );
    }


    private IEnumerator Start()
    {
        // SceneLoader‚©‚çTransition‚ğó‚¯æ‚é
        if (SceneLoader.NextTransition != null)
        {
            transition =
                SceneLoader.NextTransition;
        }

        // Context‚ğì‚è’¼‚·
        context = new TransitionContext(
            canvasGroup,
            transitionImage
        );

        // Transition‚ª‚ ‚éê‡‚Ì‚İOut
        if (transition != null)
        {
            yield return StartCoroutine(
                PlayOut()
            );
        }
    }


    public IEnumerator PlayIn()
    {
        if (transition == null)
            yield break;

        yield return StartCoroutine(
            transition.PlayIn(context)
        );
    }


    public IEnumerator PlayOut()
    {
        if (transition == null)
            yield break;

        yield return StartCoroutine(
            transition.PlayOut(context)
        );
    }


    public void SetTransition(
        TransitionBehaviour newTransition)
    {
        transition = newTransition;
    }
}