using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVision : MonoBehaviour
{
    public bool centered = false;

    private void OnBecameInvisible()
    {
        centered = false;
    }
}
