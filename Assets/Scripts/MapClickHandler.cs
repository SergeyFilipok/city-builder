using UniRx;
using UnityEngine;
using Zenject;

public class MapClickHandler : MonoBehaviour {
    [SerializeField] private Game _game = null;
    [SerializeField] private BuildingPanel _buildingPanel = null;
    [SerializeField] private BuildingActionsPanel _buildingActionsPanel = null;
    [SerializeField] private BuildingInfoPanel _buildingInfoPanel = null;

    [Inject] private BuildingsConfig _buildingsConfig = null;

    private Place _cachedPlace;
    private Building _lastSelectedBuilding;
    private PanelBase _currentPanel;
    private bool _replacing = false;

    private void Awake() {
        _buildingPanel.BuildingClicked += OnBuildingClicked;
        _buildingActionsPanel.InfoActionSelected += ShowBuildingInfo;
        _buildingActionsPanel.ReplaceActionSelected += ActivateReplaceMode;
        _buildingActionsPanel.RemoveActionSelected += RemoveBuilding;
        _buildingActionsPanel.Closed += OnCurrentPanelClosed;
        _buildingInfoPanel.Closed += OnCurrentPanelClosed;
    }

    private void Start() {
        _game.Map.PlaceClicked += OnClick;
    }

    private void OnBuildingClicked(int buildingIndex) {
        _buildingPanel.Hide();
        var buildingCreator = _buildingsConfig.GetCreator(buildingIndex);
        _game.Map.CreateBuilding(buildingCreator, _cachedPlace);
    }

    private void OnClick(Place place) {
        if ((_currentPanel != null && _currentPanel.IsShowing) || _replacing) return;

        _cachedPlace = place;

        if (_game.Map.IsEmpty(_cachedPlace, out _lastSelectedBuilding)) {
            _buildingPanel.Show();
            _currentPanel = _buildingPanel;
        }
        else {
            _lastSelectedBuilding.Select();
            _buildingActionsPanel.Assign(_lastSelectedBuilding.Info);
            _buildingActionsPanel.Show();
            _currentPanel = _buildingActionsPanel;
        }
    }

    private void ShowBuildingInfo() {
        _buildingActionsPanel.Hide();
        _buildingInfoPanel.Assign(_lastSelectedBuilding);
        _buildingInfoPanel.Show();
        _currentPanel = _buildingInfoPanel;
    }

    private void ActivateReplaceMode() {
        _buildingActionsPanel.Hide();
        _replacing = true;
        Observable.FromEvent<Place>(h => _game.Map.PlaceClicked += h, h => _game.Map.PlaceClicked -= h)
            .First()
            .Subscribe(p => {
                _replacing = false;
                _lastSelectedBuilding.Deselect();
                _game.Map.ReplaceBuilding(_cachedPlace, p);
            });
    }

    private void RemoveBuilding() {
        _lastSelectedBuilding.Deselect();
        _buildingActionsPanel.Hide();
        _game.Map.RemoveBuilding(_cachedPlace);
    }


    private void OnCurrentPanelClosed() {
        _lastSelectedBuilding.Deselect();
    }
}
