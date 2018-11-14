using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Camera _cam;
    [SerializeField] private RenderTexture _rTex;
    [SerializeField] private Transform _camOrigin;
    [SerializeField] [Range(1, 10)] private int _sensitivity;
    private Vector3 _movement;
    private Inventory _inv;
    private int _current;

    void Start()
    {
        _inv = GetComponent<Inventory>();
    }

    void Update()
    {
        if (InputManager.Nums() != 0)
        {
            _current = InputManager.Nums() - 1;
        }
        if (InputManager.Up())
        {
            _movement.z = _moveSpeed;
        }
        if (InputManager.Down())
        {
            _movement.z = -_moveSpeed;
        }
        if (InputManager.Left())
        {
            //_movement.x = -_moveSpeed;
            transform.Rotate(Vector3.up * -_sensitivity);
        }
        if (InputManager.Right())
        {
            //_movement.x = _moveSpeed;
            transform.Rotate(Vector3.up * _sensitivity);
        }
        transform.Translate(Vector3.Normalize(_movement) * _moveSpeed);
        _movement = Vector2.zero;

        if (InputManager.Debug())
        {
            print("You have pressed the debug keys");
            // No actions to test at this moment
        }

        if (InputManager.Use())
        {
            if (!InventoryScreen.inventoryActive && _inv.items.ElementAtOrDefault(_current) != null && _inv.items[_current].Use(1) <= 0)
            {
                _inv.RemoveItem(_current);
                //_inv.RemoveItem(Inventory.items[_current]);
                _current = 0;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Item")
        {
            StartCoroutine(Collect(other));
        }
    }

    private IEnumerator Collect(Collision other)
    {
        _camOrigin.LookAt(other.transform);
        yield return new WaitForEndOfFrame();
        Texture2D tex = new Texture2D(_rTex.width, _rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = _rTex;
        tex.ReadPixels(new Rect(0, 0, _rTex.width, _rTex.height), 0, 0);
        tex.Apply();
        yield return new WaitForEndOfFrame();
        RenderTexture.active = null;
        other.collider.GetComponent<Item>().SetImage(tex);
        _inv.AddItem(other.gameObject.GetComponent<Item>());
        other.gameObject.SetActive(false);
        yield return null;
    }
}
