using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnTransform;

    [SerializeField]
    private float coolTime;
    private bool isBulletSpawn;

    private void Start()
    {
        isBulletSpawn = true;
        StartCoroutine(BulletSpawnCoroutine());
    }

    IEnumerator BulletSpawnCoroutine()
    {
        while (isBulletSpawn)
        {
            yield return new WaitForSeconds(coolTime);
            GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);
        }
    }
}
