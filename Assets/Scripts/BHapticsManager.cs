using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;
using System;

public class BHapticsManager : MonoBehaviour
{
    public void TestEvent()
    {
        BhapticsLibrary.Play(BhapticsEvent.PICK_INTERACTABLE_LEFT);
        BhapticsLibrary.Play(BhapticsEvent.PICK_INTERACTABLE_RIGHT);
    }

    public void PingDevices()
    {
        var connectedDevices = BhapticsLibrary.GetConnectedDevices(PositionType.Vest);
        for (int i = 0; i < connectedDevices.Count; ++i)
        {
            BhapticsLibrary.Ping(connectedDevices[i]);
        }
    }
}
