using System;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour {
    [SerializeField] private CanvasGroup _canvasGroup = null;
    [SerializeField] private Button _closeButton = null;

    public bool IsShowing => _canvasGroup.alpha > 0.5f;

    public event Action Closed;

    public void Hide() {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show() {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    private void Awake() {
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked() {
        Hide();
        Closed?.Invoke();
    }
}