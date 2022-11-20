using UnityEngine;
using UnityEngine.UI;

public class OnBuildingUIElement : MonoBehaviour
{
    [Tooltip("Element display prefab")] [SerializeField]
    private Image _prefabElementUI;

    [Tooltip("Set offset from the building")] [SerializeField]
    private Vector3 _offset;

    private Transform _buildingTransform;
    private Image _elementUI;

    protected void Awake()
    {
        _elementUI = Instantiate(_prefabElementUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        _buildingTransform = transform.parent;
    }

    protected void FixedUpdate()
    {
        _elementUI.transform.position =
            GameManager.Instance.MainCamera.WorldToScreenPoint(_buildingTransform.position + _offset);
    }

    public void SetActive(bool active)
    {
        _elementUI.gameObject.SetActive(active);
    }
}