using System;
using System.Collections.Generic;
using UnityEngine;

public class Place {
    private PlaceView _view;

    public Vector3 Position => _view.Position;

    public event Action Clicked;

    public Place(PlaceView view) {
        _view = view;
        _view.Clicked += () => Clicked?.Invoke();
    }

    public class PlaceEqualityComparer : IEqualityComparer<Place> {
        public bool Equals(Place x, Place y) {
            return x.Position.Equals(y.Position);
        }

        public int GetHashCode(Place obj) {
            return obj.Position.GetHashCode();
        }
    }
}
