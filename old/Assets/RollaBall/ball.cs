using UnityEngine;
using UnityEngine.InputSystem;

public class ball : MonoBehaviour
{
    [SerializeField] rollaball gm;
    [SerializeField] Camera camera;
    private Vector3 cameraOffset;

    Vector3 move = Vector3.zero;
    float speed = 5;

    Rigidbody rb;

    void Awake()
    {
        cameraOffset = camera.transform.position - transform.position;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        rb.AddForce(move * speed);
    }

    void LateUpdate()
    {
        camera.transform.position = transform.position + cameraOffset;
    }

    void OnMove(InputValue value)
    {
        move = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            Destroy(other.gameObject);
            gm.DecCount();
        }
    }
}
