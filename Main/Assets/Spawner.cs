using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    private static Spawner instance = null;

    public static Spawner GetInstance()
    {
        if (instance == null)
            instance = FindObjectOfType(typeof(Spawner)) as Spawner;

        return instance;
    }

    public GameObject projectile;

    float randX, randY, randZ;

    public static bool projectileActive = false;

    private void LateUpdate()
    {
        if (!projectileActive)
            ResetProjectile();
    }

    public void Notify(GameObject go)
    {
        if (go.CompareTag("Shield"))
            UpdateHud.GetInstance().UpdateScore(10);

        projectileActive = false;
    }

    void ResetProjectile()
    {
        randX = Random.Range(-70, 70);
        randY = Random.Range(-5, 5);
        randZ = Random.Range(-20, 70);
        Vector3 v = new Vector3(randX, randY, randZ);
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(go.transform.position, v) < 30)
        {
            v.x = Random.Range(50, 70);
            v.z = Random.Range(50, 70);
        }

        GameObject.Instantiate(projectile).GetComponent<Transform>().position = v;
        projectileActive = true;
    }
}
