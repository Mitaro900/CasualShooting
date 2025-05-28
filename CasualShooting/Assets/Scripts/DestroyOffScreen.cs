using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private bool isActive = false;

    private void Start()
    {
        Invoke(nameof(Activate), 5f);
    }

    void Update()
    {
        if (!isActive)
            return;
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Activate()
    {
        isActive = true;
    }
}
