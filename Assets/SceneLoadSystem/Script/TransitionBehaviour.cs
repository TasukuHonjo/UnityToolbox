using UnityEngine;
using System.Collections;

public abstract class TransitionBehaviour : ScriptableObject
{
    /// <summary>
    /// ‰æ–Ê‚ð•¢‚¤
    /// </summary>
    public abstract IEnumerator PlayIn(
        TransitionContext context
    );

    /// <summary>
    /// ‰æ–Ê‚ðŠJ‚­
    /// </summary>
    public abstract IEnumerator PlayOut(
        TransitionContext context
    );
}