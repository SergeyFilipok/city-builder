using UnityEngine;
using DG.Tweening;
using System;

public class BuildingView : MonoBehaviour {
    private const float MoveTime = 0.1f;

    private bool _firstPlacing = true;
    private Vector3 _selectionScaleOffset = new Vector3(0.1f, 0.1f, 0.1f);
    private IDisposable _selection;

    public Vector3 Position {
        get => transform.position;
        set {
            if (_firstPlacing) {
                OnFirstPlacing(value);
            }
            else {
                SetPosition(value);
            }
        }
    }

    public void Select() {
        _selection = transform.DOScalePingPong(_selectionScaleOffset, 0.5f, 300);
    }

    public void Deselect() {
        _selection.Dispose();
    }

    private void OnFirstPlacing(Vector3 position) {
        _firstPlacing = false;
        transform.position = position;
        var targetScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(targetScale, 0.5f);
    }

    private void SetPosition(Vector3 position) {
        var diatance = Vector3.Distance(transform.position, position);
        var time = MoveTime * diatance;
        transform.DOMove(position, time);
    }

    public Tweener Destroy() {
        transform.DOKill();
        return transform.DOShakePosition(0.5f, 0.1f, 20);
    }
}
