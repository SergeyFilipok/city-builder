using System.Collections.Generic;

public static class BuildingTextHelper {
    private static readonly Dictionary<BuildingType, string> _typesToString = 
        new Dictionary<BuildingType, string>() { 
            { BuildingType.Dwelling, "Жилое помещение"}, 
            { BuildingType.Selling, "Торговое помещение"}, 
            { BuildingType.Manufacture, "Производство"} 
        };

    public static string BuildingTypeToString(BuildingType buildingType) {
        return _typesToString[buildingType];
    }
}
