
using UnityEngine;

public class AssteroidSpawner : MonoBehaviour
{
    public Assteroid AssteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnAmt = 1;

    public float spawnDistance = 15.0f;

    public float trajectoryVariance = 15.0f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn),this.spawnRate, this.spawnRate);
    }

    private void Spawn(){
        for(int i=0 ;i < spawnAmt ; i++){
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            float variance = Random.Range(-this.trajectoryVariance,this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance,Vector3.forward);

            Assteroid asteroid = Instantiate(AssteroidPrefab,spawnPoint,rotation);
            asteroid.size =Random.Range(asteroid.minSize,asteroid.maxSize);
            asteroid.setTrajectory(rotation * -spawnDirection);
        }
    }
}
