using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardChange : MonoBehaviour
{
    public MatchController matchController;
    public GameObject face1;
    public GameObject face2;
    public string cardName;

    private void Start()
    {
        matchController = FindObjectOfType<MatchController>();
        StartCoroutine(MostrarCardsInicial());
    }

    public void OnCardClick()
    {
        if (!face1.activeSelf || matchController.IsProcessing())
            return;

        if (matchController.selectedCard1 == null)
        {
            matchController.selectedCard1 = this;
            ShowFace2();
        }
        else if (matchController.selectedCard2 == null)
        {
            matchController.selectedCard2 = this;
            ShowFace2();
            matchController.MatchCards();
        }
    }
    IEnumerator MostrarCardsInicial()
    {
        yield return new WaitForSeconds(3f);
        ResetCard();
    }

    public void ShowFace2()
    {
        face1.SetActive(false);
        face2.SetActive(true);
    }

    public void ResetCard()
    {
        face1.SetActive(true);
        face2.SetActive(false);
    }

    public string GetCardName()
    {
        cardName = gameObject.name;
        return cardName;
    }
}
