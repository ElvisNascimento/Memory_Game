using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class WebRequest : MonoBehaviour
{
    public SortCards sortCards;
    public string nome= "";
    public int id;
    public RawImage imagem;

    void Start()
    {
        nome =  gameObject.name;
        sortCards = FindObjectOfType<SortCards>();
        StartCoroutine(GetImages(sortCards.imagensRecebidas[id]));
    }

    IEnumerator GetImages(int id)
    {
        string url = "https://rickandmortyapi.com/api/character/avatar/"+id.ToString()+".jpeg";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        imagem.gameObject.SetActive(true);
        imagem.texture = DownloadHandlerTexture.GetContent(www);
    }
}

