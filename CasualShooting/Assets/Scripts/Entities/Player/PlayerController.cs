using UnityEngine;

public class PlayerController : Entity
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minX = -3f;
    [SerializeField] private float maxX = 3f;
    [SerializeField] private float scrollSpeed = 4f;

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += moveInput * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;

        Vector3 move = Vector3.forward * scrollSpeed * Time.deltaTime;
        transform.position += move;
        Camera.main.transform.position += move;
    }

    protected override void Die()
    {
        GameManager.Instance.GameOver();
        base.Die();
    }
}
