using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRInteractableHerancy : XRGrabInteractable
{
    public delegate void OnPickInteractable();
    public static event OnPickInteractable onPickInteractable;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        onPickInteractable();
    }
}
