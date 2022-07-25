using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class BuildingPanel : PanelBase {
    [SerializeField] private RectTransform _rectTransform = null;
    [SerializeField] private BuildingItem _itemPrefab = null;
    [SerializeField] private RectTransform _itemsContainer = null;

    [Inject] private BuildingsConfig _buildingsConfig = null;

    private List<BuildingItem> _items = new List<BuildingItem>();

    public event Action<int> BuildingClicked;

    private void Start() {
        Assign(_buildingsConfig.BuildingInfos);
    }

    private void Assign(IEnumerable<BuildingInfo> infos) {
        if (_items.Count > 0) {
            foreach (var item in _items) {
                Destroy(item);
            }
            _items.Clear();
        }

        foreach (var info in infos) {
            var newItem = Instantiate(_itemPrefab, _itemsContainer);
            newItem.Assign(info);
            newItem.Clicked += () => ItemClicked(newItem);
            _items.Add(newItem);
        }

        UpdatePanelSize();
    }

    private void ItemClicked(BuildingItem item) {
        int itemIndex = _items.IndexOf(item);
        BuildingClicked?.Invoke(itemIndex);
    }

    private void UpdatePanelSize() {
        Observable.NextFrame().Subscribe(_ => {
            var newHeight = Mathf.Abs(_itemsContainer.anchoredPosition.y) + 6 + _itemsContainer.rect.height;
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
        });
    }
}
