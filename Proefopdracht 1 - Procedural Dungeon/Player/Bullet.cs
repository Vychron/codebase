using UnityEngine;
/// <summary>
/// Behaviour of the bullets
/// </summary>
public class Bullet : MonoBehaviour
{
    [SerializeField] private bool _return;

    // Reset the bullet to original state
    void OnEnable()
    {
        _return = false;
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.FindWithTag("Player").GetComponent<BoxCollider>());
        Invoke("Revert", 200f * Time.deltaTime);
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("Bullet");
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (_return)
            transform.LookAt(GameObject.FindWithTag("Player").transform);
        transform.Translate(Vector3.forward / 4 * Time.timeScale);
    }

    void Destruct()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

    // Tells the bullet to turn back to the player
    void Revert()
    {
        Physics.IgnoreCollision(GetComponent<BoxCollider>(), GameObject.FindWithTag("Player").GetComponent<BoxCollider>(), false);
        GetComponent<BoxCollider>().isTrigger = true;
        _return = true;
        GetComponent<MeshRenderer>().sharedMaterial = Resources.Load<Material>("Bullet-Return");
    }

    void OnCollisionEnter(Collision other)
    {
        Revert();
        if (other.collider.tag == "Crate")
            EndScreenUI.crateHits++;
        if (other.collider.tag == "Enemy")
            EndScreenUI.enemyHits++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Destruct();
    }
}
