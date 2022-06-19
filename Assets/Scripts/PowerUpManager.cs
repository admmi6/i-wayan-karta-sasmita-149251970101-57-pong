using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Collections;

public class PowerUpManager : MonoBehaviour
{
    public int maxJumlahPoweUp;

    // ball speed up
    private List<GameObject> powerUpList;
    public List<GameObject> powerUpTemplateList;
    // paddle scale up
    private List<GameObject> paddleScaleUpList;
    public List<GameObject> paddleScaleUpTemplateList;
    // paddle speed up
    private List<GameObject> paddleSpeedUpList;
    public List<GameObject> paddleSpeedUpTemplateList;

    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    // reset time
    //[HideInInspector]
    public int spawnInterval;
    private int resetAllSpawnInterval;
   
    //timer
    private float timerShowSpawn;
    private float timerResetAllSpawn;
        
    // Start is called before the first frame update
    void Start()
    {
        powerUpList = new List<GameObject>();
        paddleScaleUpList = new List<GameObject>();
        paddleSpeedUpList = new List<GameObject>();

        timerShowSpawn = 0;
        timerResetAllSpawn = 0;

        resetAllSpawnInterval = spawnInterval * 3;
    }

    // Update is called once per frame
    void Update()
    {
        // SPAWN INTERVAL
        timerShowSpawn += Time.deltaTime;
        timerResetAllSpawn += Time.deltaTime;

        if (timerShowSpawn > spawnInterval)
        {
            GenerateRandomPowerUp();

            //GenerateRandomScaleUpPaddle();
            //GenerateRandomSpeedUpPaddle();

            timerShowSpawn -= spawnInterval;
        }

        if (timerResetAllSpawn > resetAllSpawnInterval)
        {
            RemoveAllPowerUp();

            //RemoveAllScaleUpPaddle();
            //RemoveAllSpeedUpPaddle();

            timerResetAllSpawn -= resetAllSpawnInterval;
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

        if (position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x || position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
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




















    // BARU GENERATE SCALE UP PADDLE
    public void GenerateRandomScaleUpPaddle()
    {
        GenerateRandomScaleUpPaddle(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }
    private void GenerateRandomScaleUpPaddle(Vector2 position)
    {
        if(paddleScaleUpList.Count >= maxJumlahPoweUp)
        {
            return;
        }

        if(position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x || position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndexScaleUp = Random.Range(0, paddleScaleUpTemplateList.Count);
        GameObject scaleUp = Instantiate(paddleScaleUpTemplateList[randomIndexScaleUp], new Vector3(position.x, position.y, paddleScaleUpTemplateList[randomIndexScaleUp].transform.position.z), Quaternion.identity, spawnArea);
        scaleUp.SetActive(true);
        paddleScaleUpList.Add(scaleUp);
    }
    public void RemoveScaleUpPaddle(GameObject scaleUp)
    {
        paddleScaleUpList.Remove(scaleUp);
        Destroy(scaleUp);
    }
    public void RemoveAllScaleUpPaddle()
    {
        while (paddleScaleUpList.Count > 0)
        {
            RemoveScaleUpPaddle(paddleScaleUpList[0]);
        }
    }


    // GENERATE RANDOM SPEEED UP PADDLE
    public void GenerateRandomSpeedUpPaddle()
    {
        GenerateRandomSpeedUpPaddle(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }
    public void GenerateRandomSpeedUpPaddle(Vector2 position)
    {
        if(paddleSpeedUpList.Count > maxJumlahPoweUp)
        {
            return;
        }
        if(position.x < powerUpAreaMin.x || position.x > powerUpAreaMax.x || position.y < powerUpAreaMin.y || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndexSpeedUp = Random.Range(0, paddleSpeedUpTemplateList.Count);
        GameObject speedUp = Instantiate(paddleSpeedUpTemplateList[randomIndexSpeedUp], new Vector3(position.x, position.y, paddleSpeedUpTemplateList[randomIndexSpeedUp].transform.position.z), Quaternion.identity, spawnArea);
        speedUp.SetActive(true);
        paddleSpeedUpList.Add(speedUp);
    }
    public void RemoveSpeedUpPaddle(GameObject speedUp)
    {
        paddleSpeedUpList.Remove(speedUp);
        Destroy(speedUp);
    }
    public void RemoveAllSpeedUpPaddle()
    {
        while(paddleSpeedUpList.Count > 0)
        {
            RemoveSpeedUpPaddle(paddleSpeedUpList[0]);
        }
    }

}
