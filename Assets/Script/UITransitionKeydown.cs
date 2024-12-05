using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UnityFigmaBridge.Runtime.UI
{
    public class UITransitionKeydown : MonoBehaviour
    {
        /// <summary>
        /// The node id to transition to
        /// </summary>
        public string TargetScreenNodeId
        {
            get => m_TargetScreenNodeId;
            set => m_TargetScreenNodeId = value;
        }

        [SerializeField] private string m_TargetScreenNodeId;
        private UITransitionDelay _transitionDelayScript;
        [SerializeField] private string InputType;

        private void Start()
        {
            _transitionDelayScript = GetComponent<UITransitionDelay>();
        }
        private void TransitionToScene()
        {
            var prototypeFlowController =
                   GetComponentInParent<Canvas>().rootCanvas?.GetComponent<PrototypeFlowController>();
            if (prototypeFlowController != null)
                prototypeFlowController.TransitionToScreenById(m_TargetScreenNodeId);
        }

        private void Update()
        {
            if (Input.GetButtonDown(InputType))
            {
                _transitionDelayScript?.KeyPressed();
                TransitionToScene();
            }
        }

    }

}
