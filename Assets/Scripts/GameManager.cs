using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Character;
    public int spawnSayý = 2;
    public List<GameObject> SpawnPoints = new List<GameObject>();
    public GameObject prefab;
    private void Start()
    {
        shuffle(SpawnPoints);
        for (int i = 0; i <spawnSayý ; i++)
        {
            Character = i;
            Instantiate(prefab,SpawnPoints[i].transform.position,Quaternion.identity);
        }
    }
    void shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = UnityEngine.Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
}
