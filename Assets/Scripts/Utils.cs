using UnityEngine;

public static class Utils
{
    public static (float x, float y) GetEnemySpawnCoordinates(int spawnZoneNumber, Vector2 playerPosition, float cameraXShift, float cameraYShift)
    {
        float x;
        float y;

        switch (spawnZoneNumber)
        {
            case 1:
                {
                    x = Random.Range(playerPosition.x - cameraXShift, playerPosition.x - (cameraXShift / 2));
                    y = Random.Range(playerPosition.y + (cameraYShift / 2), playerPosition.y + cameraYShift);
                    break;
                }
            case 2:
                {
                    x = Random.Range(playerPosition.x - (cameraXShift / 2), playerPosition.x + (cameraXShift / 2));
                    y = Random.Range(playerPosition.y + (cameraYShift / 2), playerPosition.y + cameraYShift);
                    break;
                }
            case 3:
                {
                    x = Random.Range(playerPosition.x + (cameraXShift / 2), playerPosition.x + cameraXShift);
                    y = Random.Range(playerPosition.y + (cameraYShift / 2), playerPosition.y + cameraYShift);
                    break;
                }
            case 4:
                {
                    x = Random.Range(playerPosition.x - cameraXShift, playerPosition.x - (cameraXShift / 2));
                    y = Random.Range(playerPosition.y - (cameraYShift / 2), playerPosition.y + (cameraYShift / 2));
                    break;
                }
            case 5:
                {
                    x = Random.Range(playerPosition.x + (cameraXShift / 2), playerPosition.x + cameraXShift);
                    y = Random.Range(playerPosition.y - (cameraYShift / 2), playerPosition.y + (cameraYShift / 2));
                    break;
                }
            case 6:
                {
                    x = Random.Range(playerPosition.x - cameraXShift, playerPosition.x - (cameraXShift / 2));
                    y = Random.Range(playerPosition.y - cameraYShift, playerPosition.y - (cameraYShift / 2));
                    break;
                }
            case 7:
                {
                    x = Random.Range(playerPosition.x - (cameraXShift / 2), playerPosition.x + (cameraXShift / 2));
                    y = Random.Range(playerPosition.y - cameraYShift, playerPosition.y - (cameraYShift / 2));
                    break;
                }
            case 8:
                {
                    x = Random.Range(playerPosition.x + (cameraXShift / 2), playerPosition.x + cameraXShift);
                    y = Random.Range(playerPosition.y - cameraYShift, playerPosition.y - (cameraYShift / 2));
                    break;
                }
            default:
                {
                    x = Random.Range(playerPosition.x - cameraXShift, playerPosition.x - (cameraXShift / 2));
                    y = Random.Range(playerPosition.y + (cameraYShift / 2), playerPosition.y + cameraYShift);
                    break;
                }
        }

        return (x, y);
    }

    public static EnemyController FindClosest(Transform playerTransform)
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        EnemyController closestEnemy = null;
        EnemyController[] allEnemies = GameObject.FindObjectsOfType<EnemyController>();

        foreach (EnemyController currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - playerTransform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine(playerTransform.position, closestEnemy.transform.position, Color.red);
        return closestEnemy;
    }

    public static Vector3 LerpByDistance(Vector3 A, Vector3 B, float x)
    {
        //  1) Find direction from A to B, magnitude(=length) is 1
        //  2) Move it for x
        //  3) Move it from A by addition A
        Vector3 P = x * Vector3.Normalize(B - A) + A;   // Point from A in the B direction, moved from A by x
        return P;
    }
}
