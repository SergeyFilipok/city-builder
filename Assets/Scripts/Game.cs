using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private Camera _camera = null;
    [SerializeField] private MapCreator _mapCreator = null;

    private Map _map;

    public Map Map => _map;

    private void Awake() {
        Application.targetFrameRate = 30;
        _map = _mapCreator.CreateMap();
        var center = _mapCreator.GetCenter();
        center.z = _camera.transform.position.z;
        _camera.transform.position = center;
    }
}
