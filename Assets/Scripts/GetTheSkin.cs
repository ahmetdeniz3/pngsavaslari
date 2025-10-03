using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.WSA;

public class GetTheSkin : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public List<Sprite>sprites=new List<Sprite>();


    void Start()
    {
        _renderer=GetComponent<SpriteRenderer>();
        ResmiYukleVeAyarla();
    }

    void ResmiYukleVeAyarla()
    {
        shuffle(sprites);
        _renderer.sprite=sprites[0];
        sprites.Remove(sprites[0]);
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
