using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject blueSlimePrefab;

    [SerializeField] private float blueSlimeSpawnInterval = 1f;
    [SerializeField] private GameObject player;

    private float cameraXShift;
    private float cameraYShift;

    private Color currentColor = new Color(0, 1f, 0, 1);

    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        float size = Camera.main.orthographicSize;   // camera size to set local enemy spawn in the player viewsight

        cameraXShift = size * 2f;
        cameraYShift = size;

        playerTransform = player.transform;

        StartCoroutine(spawnEnemy(blueSlimeSpawnInterval, blueSlimePrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        float spawnZoneNumber = Random.Range(1, 8); // 3x3 grid without middle section

        (float x, float y) enemySpawnPosition = Utils.GetEnemySpawnCoordinates((int)spawnZoneNumber, playerTransform.position, cameraXShift, cameraYShift);

        //Debug.Log("Zone " + spawnZoneNumber + " , X " + enemySpawnPosition.x + " Y " + enemySpawnPosition.y + "   (" + playerTransform.position.x + ", " + playerTransform.position.y + ")");

        GameObject newEnemy = Instantiate(enemy, new Vector3(enemySpawnPosition.x, enemySpawnPosition.y, 0), Quaternion.identity);
        EnemyBase blueSlime = newEnemy.AddComponent<Slime>();
        blueSlime.EnemyDamage = 10;
        currentColor.r += 0.01f;
        newEnemy.GetComponent<SpriteRenderer>().color = currentColor;

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
