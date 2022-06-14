using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxJumlahPoweUp;
    private List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;

    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public int spawnInterval;
    public int resetAllSpawnInterval;
    private float timerDown;
    private float timerReset;
    
    public float Timerreset
    {
        get
        {
            return this.timerReset;
        }
        set
        {
            this.timerReset = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerUpList = new List<GameObject>();
        timerDown = 0;
        timerReset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timerDown += Time.deltaTime;
        timerReset += Time.deltaTime;

        if (timerDown > spawnInterval)
        {
            // generate power up setelah interval 3 detik
            GenerateRandomPowerUp();
            timerDown -= spawnInterval;
        }
        //Debug.Log("<color=green>Timer Up </color>" + timer);

        //reset semua jika lebih dari 9 spawn interval
        if (timerReset > resetAllSpawnInterval)
        {
            //hapus semua power up dan respawn
            RemoveAllPowerUp();
            timerReset -= resetAllSpawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxJumlahPoweUp)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
                position.x > powerUpAreaMax.x ||
                position.y < powerUpAreaMin.y ||
                position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);
        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);
        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0)
        {
            RemovePowerUp(powerUpList[0]);
        }
    }
}
