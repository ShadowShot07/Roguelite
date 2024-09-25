using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   [Header("Card visual properties")] 
   [SerializeField] private CardAsset asset;
   [SerializeField] private Image image = null;
   [SerializeField] private Image heroTypeImage = null;
   [SerializeField] private Image rarityImage = null;
   [SerializeField] private TextMeshProUGUI cardName;
   [SerializeField] private TextMeshProUGUI typeText;
   [SerializeField] private TextMeshProUGUI subTypeText;
   [SerializeField] private TextMeshProUGUI descriptionText = null;
   [SerializeField] private TextMeshProUGUI manaCostText = null;
   [SerializeField] private TextMeshProUGUI damageLifeText = null;
   
   public void Initialize(CardAsset cardAsset)
   {
      asset = cardAsset;
      image.sprite = cardAsset.characterImage;
      rarityImage.sprite = cardAsset.cardRaritySprite;
      heroTypeImage.sprite = cardAsset.heroIdentifierSprite;
      descriptionText.text = cardAsset.description;
      manaCostText.text = cardAsset.manaCost.ToString();
      cardName.text = cardAsset.name;
      typeText.text = cardAsset.type;
      subTypeText.text = cardAsset.subType;
      damageLifeText.text = $"{cardAsset.life}/{cardAsset.damage}";
   }
}
