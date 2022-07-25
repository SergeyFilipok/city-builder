using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour {
    [SerializeField] private Image _image = null;
    [SerializeField] private TMP_Text _name = null;
    [SerializeField] private Button _button = null;

    public event Action Clicked;

    private void Awake() {
        _button.onClick.AddListener(OnButtonClicked);
    }

    public void Assign(BuildingInfo info) {
        _image.sprite = info.icon;
        _name.text = info.name;
    }

    private void OnButtonClicked() {
        Clicked?.Invoke();
    }
}
