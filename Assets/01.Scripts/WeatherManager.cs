using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] private GameObject rainPrefab;
    [SerializeField] private GameObject snowPrefab;
    GameObject rain, snow;

    private void Start()
    {
        Invoke("RainFall",10f); //10f);
        Invoke("SnowFall", 30f);
        Invoke("StopSnowFall", 60f);
    }

    void RainFall()
    {
        rain = Instantiate(rainPrefab, transform.position, Quaternion.identity);
        rain.transform.localPosition = Vector3.zero;
    }

    void SnowFall()
    {
        Destroy(rain);
        snow = Instantiate(snowPrefab, transform.position, Quaternion.identity);
        snow.transform.localPosition = Vector3.zero;
    }

    void StopSnowFall()
    {
        Destroy(snow);
    }
}
