using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Deck/New Deck")]
public class DeckAsset : ScriptableObject
{
   public List<CardAsset> cards = new List<CardAsset>();
}
