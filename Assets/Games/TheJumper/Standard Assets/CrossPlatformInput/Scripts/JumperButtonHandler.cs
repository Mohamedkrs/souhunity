using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class JumperButtonHandler : MonoBehaviour
    {

        public string Name;

        void OnEnable()
        {

        }

        public void SetDownState()
        {
            JumperCrossPlatformInputManager.SetButtonDown(Name);
        }


        public void SetUpState()
        {
            JumperCrossPlatformInputManager.SetButtonUp(Name);
        }


        public void SetAxisPositiveState()
        {
            JumperCrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            JumperCrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            JumperCrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
