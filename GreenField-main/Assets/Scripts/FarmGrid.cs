using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    public int columnLength, rowLength;
    public float xSpace, zSpace;

    public GameObject grass;
    public GameObject[] currentGrid;

    public bool gotGrid;

    public GameObject hitted;
    public GameObject field;
    public GameObject soil;

    private RaycastHit _Hit;

    public bool creatingFields;

    public Texture2D basicCursor, fieldCursor, seedCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject goldSystem;
    public int fieldsPrice;

    public  GameObject[] seeds;

    public TextMeshProUGUI maizeHarvestText;
    public int maizeHarvest;
    public TextMeshProUGUI tomatoesHarvestText;
    public int tomatoesHarvest;
    public TextMeshProUGUI carrotHarvestText;
    public int carrotHarvest;
    public TextMeshProUGUI beetHarvestText;
    public int beetHarvest;
    public TextMeshProUGUI bellHarvestText;
    public int bellHarvest;
    public TextMeshProUGUI melonHarvestText;
    public int melonHarvest;
    public TextMeshProUGUI cabbageHarvestText;
    public int cabbageHarvest;

    public int maizeHarvest2;
    public int tomatoesHarvest2;
    public int carrotHarvest2;
    public int beetHarvest2;
    public int bellHarvest2;
    public int melonHarvest2;
    public int cabbageHarvest2;

    private int totalCropsInBarn;
    public TextMeshProUGUI totalCropsInBarnText;

    void Awake()
    {
        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        //ClearCursor();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < columnLength*rowLength; i++)
        {
            Instantiate(grass, new Vector3(xSpace +(xSpace * (i % columnLength)), 0, zSpace + (zSpace * (i / columnLength))), Quaternion.identity);
        }

        maizeHarvest = 1;
        tomatoesHarvest = 1;
        carrotHarvest = 1;
        beetHarvest = 1;
        bellHarvest = 1;
        melonHarvest = 1;
        cabbageHarvest = 1;

        // for total num of crops in barn
        maizeHarvest2 = 0;
        tomatoesHarvest2 = 0;
        carrotHarvest2 = 0;
        beetHarvest2 = 0;
        bellHarvest2 = 0;
        melonHarvest2 = 0;
        cabbageHarvest2 = 0;

        totalCropsInBarn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gotGrid == false)
        {
            currentGrid = GameObject.FindGameObjectsWithTag("grid");

            gotGrid = true;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out _Hit))
            {
                if(creatingFields == true)
                {
                    if(_Hit.transform.tag == "grid" && goldSystem.GetComponent<GoldSystem>().gold >= fieldsPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(field,hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= fieldsPrice;
                    }
                }

                if(Product.isSowing == true)
                {
                    if(_Hit.transform.tag == "field" && goldSystem.GetComponent<GoldSystem>().gold >= Product.currentProductPrice)
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(seeds[Product.whichSeed],hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= Product.currentProductPrice;
                    }
                }

                //HARVESTING SYSTEM

                if (creatingFields != true && Product.isSowing != true)
                {
                    if (_Hit.transform.tag == "maize")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        maizeHarvestText.text = maizeHarvest.ToString();
                        maizeHarvest++;
                        maizeHarvest2++;
                    }

                    if (_Hit.transform.tag == "tomatoes")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        tomatoesHarvestText.text = tomatoesHarvest.ToString();
                        tomatoesHarvest++;
                        tomatoesHarvest2++;
                    }

                    if (_Hit.transform.tag == "carrot")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        carrotHarvestText.text = carrotHarvest.ToString();
                        carrotHarvest++;
                        carrotHarvest2++;
                    }

                    if (_Hit.transform.tag == "beet")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        beetHarvestText.text = beetHarvest.ToString();
                        beetHarvest++;
                        beetHarvest2++;
                    }

                    if (_Hit.transform.tag == "bell")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        bellHarvestText.text = bellHarvest.ToString();
                        bellHarvest++;
                        bellHarvest2++;
                    }

                    if (_Hit.transform.tag == "melon")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        melonHarvestText.text = melonHarvest.ToString();
                        melonHarvest++;
                        melonHarvest2++;
                    }

                    if (_Hit.transform.tag == "cabbage")
                    {
                        hitted = _Hit.transform.gameObject;
                        Instantiate(soil, hitted.transform.position, Quaternion.identity);
                        Destroy(hitted);

                        cabbageHarvestText.text = cabbageHarvest.ToString();
                        cabbageHarvest++;
                        cabbageHarvest2++;
                    }

                    totalCropsInBarn = maizeHarvest2 + tomatoesHarvest2 + carrotHarvest2 + beetHarvest2 + bellHarvest2 + cabbageHarvest2 + melonHarvest2;
                    totalCropsInBarnText.text = totalCropsInBarn.ToString();

                }
            }
            
        }

        if(creatingFields == true)
        {
            Cursor.SetCursor(fieldCursor, hotSpot, cursorMode);

            Product.isSowing = false;
        }

        if (Shop.beInShop == true)
        {
            creatingFields = false;
            Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
        }

        if (Product.isSowing == true)
        {
            creatingFields = false;
            Cursor.SetCursor(seedCursor, hotSpot, cursorMode);
        }

        if(Input.GetMouseButtonDown(1))
        {
            ClearCursor();
        }
    }


    public void CreateFields()
    {
        creatingFields = true;
    }

    public void ReturnToNormality()
    {
        creatingFields = false;
    }
    

    public void ClearCursor()
    {
        creatingFields = false;
        Product.isSowing = false;

        Cursor.SetCursor(basicCursor, hotSpot, cursorMode);
    }


    // SELLING SYSTEM
    public void SellMaize()
    {
        if (maizeHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 20;
            maizeHarvest--;
            maizeHarvest2--;
            maizeHarvestText.text = maizeHarvest2.ToString();
        }
        else if (maizeHarvest == 1 && maizeHarvest2 < 1)
        {
            print("You do not have maize in barn");
            return;
        }
    }
    public void SellTomatoes()
    {
        if (tomatoesHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 30;
            tomatoesHarvest--;
            tomatoesHarvest2--;
            tomatoesHarvestText.text = tomatoesHarvest2.ToString();
        }
        else if (tomatoesHarvest == 1 && tomatoesHarvest2 < 1)
        {
            print("You do not have tomatoes in barn");
            return;
        }
    }
    public void SellCarrot()
    {
        if (carrotHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 1000;
            carrotHarvest--;
            carrotHarvest2--;
            carrotHarvestText.text = carrotHarvest2.ToString();
        }
        else if (carrotHarvest == 1 && carrotHarvest2 < 1)
        {
            print("You do not have carrot in barn");
            return;
        }
    }
    public void SellBeet()
    {
        if (beetHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 50;
            beetHarvest--;
            beetHarvest2--;
            beetHarvestText.text = beetHarvest2.ToString();
        }
        else if (beetHarvest == 1 && beetHarvest2 < 1)
        {
            print("You do not have beet in barn");
            return;
        }
    }
    public void SellBell()
    {
        if (bellHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 60;
            bellHarvest--;
            bellHarvest2--;
            bellHarvestText.text = bellHarvest2.ToString();
        }
        else if (bellHarvest == 1 && bellHarvest2 < 1)
        {
            print("You do not have bell in barn");
            return;
        }
    }
    public void SellMelon()
    {
        if (melonHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 70;
            melonHarvest--;
            melonHarvest2--;
            melonHarvestText.text = melonHarvest2.ToString();
        }
        else if (melonHarvest == 1 && melonHarvest2 < 1)
        {
            print("You do not have melon in barn");
            return;
        }
    }
    public void SellCabbage()
    {
        if (cabbageHarvest > 1)
        {
            goldSystem.GetComponent<GoldSystem>().gold += 80;
            cabbageHarvest--;
            cabbageHarvest2--;
            cabbageHarvestText.text = cabbageHarvest2.ToString();
        }
        else if (cabbageHarvest == 1 && cabbageHarvest2 < 1)
        {
            print("You do not have cabbage in barn");
            return;
        }
    }
}


