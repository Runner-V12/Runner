using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D playerRigidbody;

    [SerializeField] private int speed = 10;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player.transform.position = transform.position;
        player.transform.SetParent(transform);
        playerRigidbody.simulated = false;
    }

    private void Update()
    {        
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x >= GameController.playerStartPosition.x)
        {
            player.transform.SetParent(null);
            playerRigidbody.simulated = true;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
