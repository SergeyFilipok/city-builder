using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingActionsPanel : PanelBase {
    [SerializeField] private TMP_Text _buildingName = null;
    [SerializeField] private Button _infoButton = null;
    [SerializeField] private Button _replaceButton = null;
    [SerializeField] private Button _removeButton = null;

    public event Action InfoActionSelected;
    public event Action ReplaceActionSelected;
    public event Action RemoveActionSelected;

    public void Assign(BuildingInfo info) {
        _buildingName.text = info.name;
    }

    private void Start() {
        _infoButton.onClick.AddListener(OnInfoClicked);
        _replaceButton.onClick.AddListener(OnReplaceClicked);
        _removeButton.onClick.AddListener(OnRemoveClicked);
    }

    private void OnInfoClicked() {
        InfoActionSelected?.Invoke();
    }

    private void OnReplaceClicked() {
        ReplaceActionSelected?.Invoke();
    }

    private void OnRemoveClicked() {
        RemoveActionSelected?.Invoke();
    }
}
