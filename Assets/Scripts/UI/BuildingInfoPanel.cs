using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : PanelBase {
    private const string NameFormat = "Название: {0}";
    private const string TypeFormat = "Тип: {0}";

    [SerializeField] private Image _icon = null;
    [SerializeField] private TMP_Text _name = null;
    [SerializeField] private TMP_Text _type = null;
    [SerializeField] private TMP_Text _description = null;

    public void Assign(Building building) {
        var info = building.Info;
        _icon.sprite = info.icon;
        _name.text = string.Format(NameFormat, info.name);
        var typeStr = BuildingTextHelper.BuildingTypeToString(building.Type);
        _type.text = string.Format(TypeFormat, typeStr);
        _description.text = info.description;
    }
}
