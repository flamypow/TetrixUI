using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityFigmaBridge.Runtime.UI
{
    public class UITransitionDelay : MonoBehaviour
    {
        /// <summary>
        /// The node id to transition to
        /// </summary>
        public string TargetScreenNodeId
        {
            get => m_TargetScreenNodeId;
            set => m_TargetScreenNodeId = value;
        }

        private bool _keyDown = false;

        [SerializeField] private string m_TargetScreenNodeId;

        [SerializeField] private float delay;

        protected void Start()
        {
            _keyDown = false;
            StartCoroutine(WaitThenTransition());
        }

        private void TransitionToScene()
        {
            if (!_keyDown)
            {
                var prototypeFlowController =
                    GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
                if (prototypeFlowController != null)
                    prototypeFlowController.TransitionToScreenById(m_TargetScreenNodeId);
            }
            
        }

        IEnumerator WaitThenTransition()
        {
            yield return new WaitForSeconds(delay);
            TransitionToScene();
        }

        public void KeyPressed()
        {
            _keyDown = true;
        }


    }

}
