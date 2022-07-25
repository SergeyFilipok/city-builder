using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Buildings", menuName = "Configs/Buildings")]
public class BuildingsConfig : ScriptableObject {
    [SerializeField] private BuildingTemplate[] _buildingTemplates = new BuildingTemplate[0];

    public IEnumerable<BuildingInfo> BuildingInfos => _buildingTemplates.Select(t => t.Info);

    public IBuildingCreator GetCreator(int index) {
        return _buildingTemplates[index];
    }
}
