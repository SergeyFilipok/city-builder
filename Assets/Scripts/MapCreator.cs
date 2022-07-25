using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour {
    [SerializeField] private Transform _root = null;
    [SerializeField] private PlaceView _placePrefab = null;
    [SerializeField] private int _mapHeight = 10;
    [SerializeField] private int _mapWidth = 20;

    public Map CreateMap() {
        Vector2 size = _placePrefab.Size;
        Vector3 position = Vector3.zero;
        List<Place> places = new List<Place>(_mapHeight * _mapWidth);
        for (int i = 0; i < _mapHeight; i++) {
            for (int j = 0; j < _mapWidth; j++) {
                position.x = size.x * j;
                position.y = size.y * i;
                position.z = 0;
                position += _root.position;
                var view = Instantiate(_placePrefab, position, Quaternion.identity, _root);
                places.Add(new Place(view));
            }
        }
        return new Map(places);
    }

    public Vector3 GetCenter() {
        Vector2 size = _placePrefab.Size;
        Vector3 center = Vector3.zero;
        center.x = size.x * (_mapWidth - 1) * 0.5f;
        center.y = size.y * (_mapHeight - 1) * 0.5f;
        center += _root.position;
        return center;
    }
}
