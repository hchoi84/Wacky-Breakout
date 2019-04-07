using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab = default;

    private Vector2 spawnLocation = Vector2.zero;
    private float spawnTimer;
    private Timer timer;
    private bool spawnLocationOverlaps = true;

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        timer.Run();
    }

    private void Update()
    {
        // spawn new balls every 5 to 10 seconds
        if (timer.Finished)
        {
            SpawnNewBall();
            spawnTimer = Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
            timer.Duration = spawnTimer;
            timer.Run();
        }
    }

    public void SpawnNewBall()
    {
        Vector2 spawnLocation = new Vector2(
                Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
                Random.Range(0, ScreenUtils.ScreenTop));

        float radius = ballPrefab.GetComponent<CircleCollider2D>().radius;

        Debug.Log(Physics2D.OverlapCircle(spawnLocation, radius));
        while (Physics2D.OverlapCircle(spawnLocation, radius))
        {
            spawnLocation = new Vector2(
                 Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
                 Random.Range(0, ScreenUtils.ScreenTop));
        }

        Instantiate(ballPrefab, spawnLocation, Quaternion.identity);
    }
}
