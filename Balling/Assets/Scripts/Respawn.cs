using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Respawn")]
    [SerializeField] private float fallLimitY = -10f;
    [SerializeField] private Transform respawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (respawnPoint == null)
            Debug.LogError("RespawnPoint NO asignado");
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            RespawnPoint();
        }
    }

    private void RespawnPoint()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.position;
    }

    private void DoRespawn()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPoint.position;

        Disappear.ResetAll();
    }
}
