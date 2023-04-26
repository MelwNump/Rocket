using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float followSpeed = 2f;
    public float min_Y_Treshold = -2.6f;
    private bool followPlayer;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (target.position.y < (transform.position.y - min_Y_Treshold))
        {
            followPlayer = false;
        }

        if (target.position.y > (transform.position.y - min_Y_Treshold))
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            Vector3 targetPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        }
        
    }
}