﻿using UnityEngine;
using System.Collections;

namespace Tumba.UI
{
    public class ButtonCascade : ButtonUI
    {
        [SerializeField] GameObject all; //Main gameObject to show/hidew
        [SerializeField] AnimationClip enterAnim;
        CascadeList cascadeList;

        public void Enter(CascadeList cascadeList)
        {
            this.cascadeList = cascadeList;
            if (anim == null)
                Debug.LogError("No anim for cascade button");
            else
                anim.Play(enterAnim.name);
        }
        public override void OnClick()
        {
            cascadeList.OnButtonCascadePressed(this);
            base.OnClick();
        }
        protected override void OnDestroyed()
        {
            cascadeList = null;
        }
        public void SetAllActive(bool isOn)
        {
            if(all != null)
                all.gameObject.SetActive(isOn);
        }
    }
}
