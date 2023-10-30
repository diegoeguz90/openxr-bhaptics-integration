using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;
using System;

public class BHapticsManager : MonoBehaviour
{
    public void SelectEvent()
    {
        BhapticsLibrary.Play(BhapticsEvent.GRAB_INTERACTABLE);
    }

    public void UnselectEvent()
    {
        BhapticsLibrary.Play(BhapticsEvent.RELEASE_INTERACTABLE);
    }
}
