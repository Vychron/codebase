using UnityEngine;
/// <summary>
/// Health management of a crate
/// </summary>
public class CrateHealth : MonoBehaviour
{
    [SerializeField] private int _health;

    // Update is called once per frame
    void Update()
    {
        if (_health < 1)
        {
            EndScreenUI.crates++;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bullet")
        {
            _health--;
            GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("Crate-Damaged");
        }
    }
}
