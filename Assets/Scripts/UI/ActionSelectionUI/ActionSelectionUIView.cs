using UnityEngine;

namespace Command.UI
{
    public class ActionSelectionUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private Transform actionButtonContainer;
        [SerializeField] private Vector3 leftAlignedPosition;
        [SerializeField] private Vector3 rightAlignedPosition;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public ActionButtonView AddButton(ActionButtonView actionButtonPrefab) => Instantiate(actionButtonPrefab, actionButtonContainer);

        public void SetActionContainerAlignment(ActionContainerAlignment alignmentToSet)
        {
            switch (alignmentToSet)
            {
                case ActionContainerAlignment.Left:
                    actionButtonContainer.localPosition = leftAlignedPosition;
                    break;
                case ActionContainerAlignment.Right:
                    actionButtonContainer.localPosition = rightAlignedPosition;
                    break;
            }
        }

        public void RemoveButton(ActionButtonView buttonToDestroy) => Destroy(buttonToDestroy.gameObject);
    }

    public enum ActionContainerAlignment
    {
        Left,
        Right
    }
}