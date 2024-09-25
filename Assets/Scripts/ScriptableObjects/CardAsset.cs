using UnityEngine;

[CreateAssetMenu(menuName = "Card/New Card")]
public class CardAsset : ScriptableObject
{
  public int manaCost;
  public int life;
  public int damage;
  public string description;
  public string type;
  public string subType;
  public string name;
  public Sprite characterImage;
  public Sprite heroIdentifierSprite;
  public Sprite cardRaritySprite;
  public Sprite cardRarityOnTable;
  public CardType cardType;
}

public enum CardType
{
  None,
  Upgrade,
  Creature,
  Skill
}