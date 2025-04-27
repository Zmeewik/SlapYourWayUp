using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Воспроизвести анимацию по имени
    public void PlayAnimation(string animationName)
    {
        if (animator == null)
        {
            Debug.LogWarning("Animator not found!");
            return;
        }

        animator.Play(animationName);
    }
}
