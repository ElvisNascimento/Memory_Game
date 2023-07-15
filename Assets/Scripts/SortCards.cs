using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCards : MonoBehaviour
{
    public GameObject objetoPai; // O GameObject pai dos novos objetos
    public GameObject[] prefabsOriginais; // Array com os prefabs originais
    public int[] imagensRecebidas;
    private List<GameObject> cartas; // Lista para armazenar as cartas
    

    private void Start()
    {
        cartas = new List<GameObject>();

        // Duplica os prefabs no array
        List<GameObject> prefabsDuplicados = new List<GameObject>();
        foreach (GameObject prefab in prefabsOriginais)
        {
            prefabsDuplicados.Add(prefab);
            prefabsDuplicados.Add(prefab);
        }

        // Embaralha as posições do array
        EmbaralharLista(prefabsDuplicados);

        // Instancia os objetos duplicados dentro do objeto pai
        foreach (GameObject prefab in prefabsDuplicados)
        {
            GameObject novoObjeto = Instantiate(prefab, objetoPai.transform);
            novoObjeto.transform.localPosition = Vector3.zero;
            novoObjeto.transform.localScale = Vector3.one;
            cartas.Add(novoObjeto);
        }

        imagensRecebidas = SortearImagens();
    }

    // Função para embaralhar os elementos de uma lista
    private void EmbaralharLista<T>(List<T> lista)
    {
        int n = lista.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T temp = lista[k];
            lista[k] = lista[n];
            lista[n] = temp;
        }
    }

    private int[] SortearImagens()
    {
        List<int> numerosDasImagens = new List<int>();
        while (numerosDasImagens.Count < 14)
        {
            int randomIndex = Random.Range(1, 827);

            if (!numerosDasImagens.Contains(randomIndex))
            {
                numerosDasImagens.Add(randomIndex);
            }
        }

        // Converter a lista em um array
        int[] numerosSorteados = numerosDasImagens.ToArray();

        return numerosSorteados;
    }

    public void RemoverCarta(GameObject carta)
    {
        Destroy(carta);
        cartas.Remove(carta);
    }
}