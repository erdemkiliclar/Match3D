﻿using UnityEngine;

namespace Voodoo.Visual.UI.Button
{
    public class ButtonAnimation : MonoBehaviour
    {
        public ButtonHandler buttonHandler;

        public Animator animator;


        public bool isLooping;
        
        private static readonly int loop = Animator.StringToHash("Loop");
        private static readonly int pressed = Animator.StringToHash("Pressed");
        private static readonly int released = Animator.StringToHash("Released");

        public void Start()
        {
            if (buttonHandler != null)
            {
                buttonHandler.OnDown += Pressed;
                buttonHandler.OnUp += Released;
            }

            if (animator != null)
            {
                animator.SetBool(loop, isLooping);
            }

        }

        private void Pressed()
        {
            animator.SetBool(loop, false);
            animator.SetTrigger(pressed);
        }

        private void Released()
        {
            animator.SetTrigger(released);
            animator.SetBool(loop, isLooping);
            
        }

        private void OnDestroy()
        {
            if (buttonHandler == null)
                return;

            buttonHandler.OnDown -= Pressed;
            buttonHandler.OnUp -= Released;
        }
    }
}