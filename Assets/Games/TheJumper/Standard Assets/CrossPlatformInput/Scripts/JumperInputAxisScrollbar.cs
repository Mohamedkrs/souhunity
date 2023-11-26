using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class JumperInputAxisScrollbar : MonoBehaviour
    {
        public string axis;

	    void Update() { }

	    public void HandleInput(float value)
        {
            JumperCrossPlatformInputManager.SetAxis(axis, (value*2f) - 1f);
        }
    }
}
