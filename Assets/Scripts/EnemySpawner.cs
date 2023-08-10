using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blueSlimePrefab;

    [SerializeField] private float _blueSlimeSpawnInterval = 1f;
    [SerializeField] private GameObject _player;

    private float _cameraXShift;
    private float _cameraYShift;

    private Color _currentColor = new Color(0, 1f, 0, 1);

    private Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        float size = Camera.main.orthographicSize;   // camera size to set local enemy spawn in the player viewsight

        _cameraXShift = size * 2f;
        _cameraYShift = size;

        _playerTransform = _player.transform;

        StartCoroutine(spawnEnemy(_blueSlimeSpawnInterval, _blueSlimePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        float spawnZoneNumber = Random.Range(1, 8); // 3x3 grid without middle section

        (float x, float y) enemySpawnPosition = Utils.GetEnemySpawnCoordinates((int)spawnZoneNumber, _playerTransform.position, _cameraXShift, _cameraYShift);

        //Debug.Log("Zone " + spawnZoneNumber + " , X " + enemySpawnPosition.x + " Y " + enemySpawnPosition.y + "   (" + playerTransform.position.x + ", " + playerTransform.position.y + ")");

        GameObject newEnemy = Instantiate(enemy, new Vector3(enemySpawnPosition.x, enemySpawnPosition.y, 0), Quaternion.identity);
        EnemyBase blueSlime = newEnemy.AddComponent<Slime>();
        blueSlime.EnemyDamage = 10;
        _currentColor.r += 0.01f;
        newEnemy.GetComponent<SpriteRenderer>().color = _currentColor;

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
