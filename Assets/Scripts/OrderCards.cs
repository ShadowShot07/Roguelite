using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using Random = System.Random;

public class OrderCards : MonoBehaviour
{
	private Random _random = new();
	
	//Deck info, should move into initializer script?
	[SerializeField] private DeckAsset deck;
	[SerializeField] private GameObject baseCard;

	[SerializeField] private List<CardAsset> finalDeck = new List<CardAsset>();
	private List<GameObject> items = new List<GameObject>();
   	[SerializeField] private Transform startLocation;  
	[SerializeField] private Transform cardPanel; 
	public float howManyAdded; // How many cards I added so far
	[SerializeField] private float gapBetweenCards = 60f;
	[SerializeField] private float animationDuration;

	[Header("General Card Config")] //Move to separate class?
	[SerializeField] private int cardsInHand = 5;

	private void Start()
   	{
	    InstantiateCards();
	    
   		howManyAdded = 0.0f;
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			howManyAdded = 0;
			for (int i = 0; i < cardPanel.transform.childCount; i++)
			{
				Destroy(cardPanel.transform.GetChild(i).gameObject); //Move cards to deck list and add the new spawned cards
			}
			
			InstantiateCards();
		}
	}

	private void InstantiateCards()
	{
		finalDeck = deck.cards.OrderBy(x => _random.Next()).ToList(); //Shuffle deck

		for (int i = 0; i < finalDeck.Count; i++)
		{
			if (i >= cardsInHand)
			{
				break;
			}
			
			GameObject cardObject = Instantiate(baseCard, cardPanel);
			Card card = cardObject.GetComponent<Card>();
			card.Initialize(finalDeck[i]);
			items.Add(cardObject);
		}
		
		StartCoroutine(FitCards());
	}
    
    private IEnumerator FitCards()
   	{
	    while (items.Count > 0)
	    {
		    GameObject img = items [0];

		    Transform imgTransform = img.transform;
		    imgTransform.position = startLocation.position; //relocating my card to the Start Position
		    Vector3 newPos = imgTransform.position + new Vector3 (( howManyAdded*gapBetweenCards), 0, 0);
		    img.transform.DOMove(newPos, animationDuration);
		    yield return new WaitForSeconds(0);
		    img.transform.SetParent (cardPanel); //Setting ym card parent to be the Hand Panel
   
		    items.RemoveAt (0);
		    howManyAdded++;   
	    }
    }
}
