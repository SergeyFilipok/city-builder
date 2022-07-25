using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceView : MonoBehaviour {
    [SerializeField] private BoxCollider2D _collider = null;

    public Vector3 Position => transform.position;
    public Vector2 Size => _collider.size;

    public event Action Clicked;

    private void OnMouseUp() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Clicked?.Invoke();
    }
}
