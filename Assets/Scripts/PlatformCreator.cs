using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PlatformCreator : MonoBehaviour
{
    public GameObject platform;
    public TMP_Text number;
    public TMP_Text questionText;

    private int CurrentNumber;
    private int DesiredNumber;
    private int[] platformXCoordinates;
    private int[] platformYCoordinates;
    public int platformCount;

    // Start is called before the first frame update
    void Start()
    {
        questionText = GameObject.Find("QuestionText").GetComponent<TextMeshPro>();
        platformCount = 3;
        platformXCoordinates = new int[platformCount];
        platformYCoordinates = new int[platformCount];

        CurrentNumber = 0;
        NumberCreate();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == number.name + "(Clone)")
        {
            foreach (GameObject platform in GameObject.FindGameObjectsWithTag("platforms"))
            {
                Destroy(platform);
            }


            NumberCreate();

        }
    }

    private void NumberCreate()
    {
        CreatePos();


        for (int i = 0; i < platformCount; i++)
        {
            Instantiate(platform, new Vector2(platformXCoordinates[i], platformYCoordinates[i]), Quaternion.identity);

            DesiredNumber = Random.Range(0, 100);
            int OtherNumber = Random.Range(0, 100);

            var DesiredNumberDigitCount = Mathf.Floor(Mathf.Log10(DesiredNumber) + 1);
            number.name = DesiredNumber.ToString();
            number.text = DesiredNumber.ToString();
            number.GetComponent<BoxCollider2D>().size = new Vector2(DesiredNumberDigitCount * 0.4f, 0.5f);
            Instantiate(number, new Vector2(platformXCoordinates[i] + 0.2f, platformYCoordinates[i] + 1), Quaternion.identity);

            questionText.text = OtherNumber.ToString() + " + <color=red>?</color> = " + (DesiredNumber + OtherNumber).ToString(); 
        }
    }

    void CreatePos()
    {
        int counter = 0;
        while (counter != platformCount)
        {
            int x = Random.Range(-10, 10);
            int y = Random.Range(-4, 3);

            if (!platformXCoordinates.Contains(x) && !platformYCoordinates.Contains(y))
            {
                platformXCoordinates[counter] = x;
                platformYCoordinates[counter] = y;

                counter++;
            }
        }

    }
}
