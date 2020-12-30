using System.Collections;
using Tayx.Graphy;
using UnityEngine;
using UnityEngine.Scripting;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        private bool _graphy = false;
        
        public void Start()
        {
            if (!Application.isEditor)
                GarbageCollector.GCMode = GarbageCollector.Mode.Manual;
        }

        public void ToggleGraphy()
        {
            if (!_graphy)
                GraphyManager.Instance.Enable();
            else
                GraphyManager.Instance.Disable();

            _graphy = !_graphy;
        }

        public void SetFPS30()
        {
            Application.targetFrameRate = 30;
        }
        
        public void SetFPS45()
        {
            Application.targetFrameRate = 45;
        }
        
        public void SetFPS60()
        {
            Application.targetFrameRate = 60;
        }
        
        public void SetFPS120()
        {
            Application.targetFrameRate = 120;
        }
    }
}