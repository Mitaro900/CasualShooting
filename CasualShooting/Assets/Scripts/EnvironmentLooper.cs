using UnityEngine;

public class EnvironmentLooper : MonoBehaviour
{
    public GameObject ground;
    private float GroundLength; // 배경 한 장의 세로 길이

    private void Start()
    {
        GroundLength = ground.GetComponent<Renderer>().bounds.size.z;
    }

    private void Update()
    {
        if (transform.position.z + GroundLength < Camera.main.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z + GroundLength);
        }
    }
}
