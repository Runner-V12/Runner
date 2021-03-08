using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerStartPosition;

    [SerializeField] private int speed = 10;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        player.transform.position = transform.position;
        player.transform.SetParent(transform);
    }

    private void Update()
    {        
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (transform.position.x >= GameController.playerStartPosition.x)
        {
            player.transform.SetParent(null);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
