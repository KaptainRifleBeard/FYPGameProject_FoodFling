using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CatDogSpawn : MonoBehaviour
{
    public List<Transform> catSpawnPoints;
    public List<Transform> dogSpawnPoints;
    public GameObject catPrefab;
    public GameObject dogPrefab;
    int catORdog;
    int rSpawn;
    public static bool canSpawn;
    public static bool catCanSpawn;
    public static bool dogCanSpawn;

    public int spawnInt = 1;
    public int spawnTime = 20;

    int count;
    bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
        if (PhotonNetwork.IsMasterClient)
        {
            if (count < 1 && spawn == false) //make sure it wont run in both build, only for masterclient
            {
                if (count < 1)
                {
                    if (spawnInt == 1)
                    {
                        StartCoroutine(Spawn(spawnTime));
                        count++;
                    }
                    else if (spawnInt == 2)
                    {
                        StartCoroutine(Spawn2(spawnTime));
                        count++;

                    }
                    else if (spawnInt == 3)
                    {
                        StartCoroutine(Spawn3(spawnTime));
                        count++;

                    }
                    else
                    {
                        StartCoroutine(Spawn(spawnTime));
                        count++;
                    }

                }
                if (count == 1)
                {
                    spawn = false;
                }
            }


        }


    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            if (canSpawn)
            {
                if (count < 1 && spawn == false) //make sure it wont run in both build, only for masterclient
                {
                    if (count < 1)
                    {
                        if (spawnInt == 1)
                        {
                            StartCoroutine(Spawn(spawnTime));
                            canSpawn = false;

                            count++;
                        }
                        else if (spawnInt == 2)
                        {
                            StartCoroutine(Spawn2(spawnTime));
                            canSpawn = false;

                            count++;
                        }
                        else if (spawnInt == 3)
                        {
                            StartCoroutine(Spawn3(spawnTime));
                            canSpawn = false;

                            count++;
                        }
                        else
                        {
                            StartCoroutine(Spawn(spawnTime));
                            canSpawn = false;

                            count++;
                        }
                    }
                    if (count == 1)
                    {
                        spawn = false;
                    }
                }



            }
        }
      

    }

    public IEnumerator Spawn(int sec)
    {
        yield return new WaitForSeconds(sec);

        catORdog = Random.Range(0, 2);

        if (catORdog == 0)
        {
            PhotonNetwork.Instantiate(catPrefab.name, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
            //Instantiate(catPrefab, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
        }
        else if (catORdog == 1)
        {
            PhotonNetwork.Instantiate(dogPrefab.name, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
            //Instantiate(dogPrefab, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
        }
        count = 0;
        spawn = false;
    }

    //spawn terbalik
    public IEnumerator Spawn2(int sec)
    {
        yield return new WaitForSeconds(sec);

        catORdog = Random.Range(0, 2);

        if (catORdog == 0)
        {
            PhotonNetwork.Instantiate(catPrefab.name, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
            //Instantiate(catPrefab, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
        }
        else if (catORdog == 1)
        {
            PhotonNetwork.Instantiate(dogPrefab.name, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
            //Instantiate(dogPrefab, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
        }
        count = 0;
        spawn = false;
    }

    //spawn species randomly
    public IEnumerator Spawn3(int sec)
    {
        yield return new WaitForSeconds(sec);

        catORdog = Random.Range(0, 2);
        rSpawn = Random.Range(0, 2);

        if (catORdog == 0)
        {
            if (rSpawn == 0)
            {
                PhotonNetwork.Instantiate(catPrefab.name, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
                //Instantiate(catPrefab, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
            }
            else if (rSpawn == 1)
            {
                PhotonNetwork.Instantiate(catPrefab.name, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
                //Instantiate(catPrefab, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
            }
        }
        else if (catORdog == 1)
        {
            if (rSpawn == 0)
            {
                PhotonNetwork.Instantiate(dogPrefab.name, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
                //Instantiate(dogPrefab, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
            }
            else if (rSpawn == 1)
            {
                PhotonNetwork.Instantiate(dogPrefab.name, dogSpawnPoints[Random.Range(0, dogSpawnPoints.Count)].transform.position, Quaternion.identity);
                //Instantiate(dogPrefab, catSpawnPoints[Random.Range(0, catSpawnPoints.Count)].transform.position, Quaternion.identity);
            }

        }
        count = 0;
        spawn = false;
    }
}
