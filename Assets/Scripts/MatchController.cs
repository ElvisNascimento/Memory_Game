using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public CardChange selectedCard1;
    public CardChange selectedCard2;
    public AudioSource audioSource;
    public AudioClip nice;
    public AudioClip erro;

    private bool isProcessing = false;

    private void Start()
    {
        selectedCard1 = null;
        selectedCard2 = null;
    }

    public bool IsProcessing()
    {
        return isProcessing;
    }

    public void MatchCards()
    {
        if (selectedCard1 != null && selectedCard2 != null)
        {
            StartCoroutine(ProcessMatch());
        }
    }

    private IEnumerator ProcessMatch()
    {
        isProcessing = true;
        yield return new WaitForSeconds(1f);

        if (selectedCard1.GetCardName() == selectedCard2.GetCardName())
        {
            audioSource.PlayOneShot(nice);
            Destroy(selectedCard1.gameObject);
            Destroy(selectedCard2.gameObject);
        }
        else
        {
            audioSource.PlayOneShot(erro);
            selectedCard1.ResetCard();
            selectedCard2.ResetCard();
        }

        selectedCard1 = null;
        selectedCard2 = null;
        isProcessing = false;
    }
}

