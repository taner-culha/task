using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasketController : MonoBehaviour
{
    [Header("Caps")]
    [SerializeField] private GameObject baseballCap;
    [SerializeField] private GameObject safetyHelmet;
    [SerializeField] private float capZPosition;
    private Vector3 baseballCapStartPosition;
    private Vector3 safetyHelmetStartPosition;
    [Header("Glasses")]
    [SerializeField] private GameObject sunglasses;
    [SerializeField] private GameObject safetyGoggles;
    [SerializeField] private float glassesZPosition;
    private Vector3 sunglassesStartPosition;
    private Vector3 safetyGogglesStartPosition;
    [Header("HeadPhones")]
    [SerializeField] private GameObject headPhones;
    [SerializeField] private GameObject earDefenders;
    [SerializeField] private float headPhonesZPosition;
    private Vector3 headPhonesStartPosition;
    private Vector3 earDefendersStartPosition;
    [Header("Shoes")]
    [SerializeField] private GameObject sportsShoes;
    [SerializeField] private GameObject workBoots;
    [SerializeField] private float shoesZPosition;
    private Vector3 sportsShoesStartPosition;
    private Vector3 workBootsStartPosition;

    private float gameObjectsXPosition = -2;
    private float gameObjectsYPosition = 1;

    [Header("GUI")]
    [SerializeField] private TextMeshProUGUI basketText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioClip sound;
    [Header("Basket")]
    private int basket;
    private int score;
    private int maxBasketCount = 4;
    private int scoreIncrement = 5;
    private int scoreDecrement = -5;

    private void Start()
    {
        baseballCapStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, capZPosition);
        safetyHelmetStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, capZPosition);
        sunglassesStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, glassesZPosition);
        safetyGogglesStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, glassesZPosition);
        headPhonesStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, headPhonesZPosition);
        earDefendersStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, headPhonesZPosition);
        sportsShoesStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, shoesZPosition);
        workBootsStartPosition = new Vector3(gameObjectsXPosition, gameObjectsYPosition, shoesZPosition);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("baseballCap"))
        {
            Debug.Log("baseballCap collided.");
            safetyHelmet.transform.position = safetyHelmetStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(true);
        }
        else if (collision.gameObject.CompareTag("safetyhelmet"))
        {
            Debug.Log("safetyhelmet collided.");
            baseballCap.transform.position = baseballCapStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(false);
        }
        else if (collision.gameObject.CompareTag("sunglasses"))
        {
            Debug.Log("sunglasses collided.");
            safetyGoggles.transform.position = safetyGogglesStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(true);
        }
        else if (collision.gameObject.CompareTag("safetygoggles"))
        {
            Debug.Log("safetygoggles collided.");
            sunglasses.transform.position = sunglassesStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(false);
        }
        else if (collision.gameObject.CompareTag("headphone"))
        {
            Debug.Log("headphones collided.");
            earDefenders.transform.position = earDefendersStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(true);
        }
        else if (collision.gameObject.CompareTag("eardefenders"))
        {
            Debug.Log("eardefenders collided.");
            headPhones.transform.position = headPhonesStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(false);
        }
        else if (collision.gameObject.CompareTag("sportsshoes"))
        {
            Debug.Log("sportsshoes collided.");
            workBoots.transform.position = workBootsStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(true);
        }
        else if (collision.gameObject.CompareTag("workboots"))
        {
            Debug.Log("workboots collided.");
            sportsShoes.transform.position = sportsShoesStartPosition;
            AudioSource.PlayClipAtPoint(sound, transform.position);
            HandleBasketAndScore(false);
        }
    }

    private void HandleBasketAndScore(bool isAddition)
    {
        if (basket < maxBasketCount)
        {
            if (isAddition)
            {
                basket++;
                score += scoreDecrement;
            }
            else
            {
                basket++;
                score += scoreIncrement;
            }
            basketText.text = basket.ToString();
            scoreText.text = score.ToString();
        }
    }
}