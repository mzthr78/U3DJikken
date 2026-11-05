using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 500f;
    public float gravity = -9.8f;
    public CharacterController controller;

    private Vector3 velocity;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }       

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(h, 0, v));

        velocity.y += gravity * Time.deltaTime;

        controller.Move((moveDirection + velocity) * Time.deltaTime * moveSpeed);
    }
}
