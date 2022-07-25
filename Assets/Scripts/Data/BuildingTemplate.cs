using System;
using UnityEngine;

[Serializable, CreateAssetMenu(fileName = "Building Template", menuName = "Configs/Building Template")]
public class BuildingTemplate : ScriptableObject, IBuildingCreator {
    [SerializeField] BuildingInfo _buildingInfo = default;
    [SerializeField] private BuildingView _viewPrefab = null;
    [SerializeField] private BuildingCreator _creator = null;

    public BuildingInfo Info { get => _buildingInfo; }

    public Building Create() {
        var viewInstance = Instantiate(_viewPrefab);
        return _creator.Create(_buildingInfo, viewInstance);
    }
}
