using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuMagazin : MonoBehaviour
{
    public GameObject[] objectsToNavigate; // Массив объектов для навигации
    public int currentIndex = 0;
    public bool IscurrentIndexActive;// Текущий индекс в массиве
    [SerializeField] private TextMeshProUGUI _textprice;
    [SerializeField] private TextMeshProUGUI _textName;
    private string[] names = { "ПМ" , "TEC-9" , "SMG1", "SMG2", "AK-47", "Mk41", "Mk14-Dra" };
    public int[] prices;

    [SerializeField] private TextMeshProUGUI _textBuy;    
    
    
    
    private void Start()
    {

       
        _textName.text = names[0];
        
    }
    private void Update()
    {
        ScrollingShoop();
        
    }
    public void ScrollingShoop()
    {
        
            if (currentIndex >= 0 && currentIndex < prices.Length)
            {

             if (prices[currentIndex] > 0)
             {
                _textprice.fontSize = 36;
                _textprice.text = prices[currentIndex].ToString();
                _textBuy.text = "Купить";

            }
             else
             {
                _textprice.fontSize = 21;
                _textprice.text = "Предмет уже куплен";
                _textBuy.text = "Взять";
             }
              
              _textName.text = names[currentIndex];
            }    
           
        
    }
  
    public void currentActive()
    {


        objectsToNavigate = GameObject.FindGameObjectsWithTag("Weapon");
        for (int i = 0; i < objectsToNavigate.Length; i++)
        {
            if(currentIndex == i)
            {
                objectsToNavigate[i].SetActive(true);
            }
            else
            {
                objectsToNavigate[i].SetActive(false);
            }
            
            
        }

        //Debug.Log(objectsToNavigate[0]);




    }
    private void SetActiveObject(int index)
    {
        
        if (objectsToNavigate.Length == 0) return;

        objectsToNavigate[currentIndex].SetActive(false);

        if (index < 0)
        {
            currentIndex = objectsToNavigate.Length - 1;
        }
        else if (index >= objectsToNavigate.Length)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex = index;
        }

        objectsToNavigate[currentIndex].SetActive(true);
    }

    public void Next()
    {
        
        SetActiveObject(currentIndex + 1);
    }

    public void Previous()
    {
        
        SetActiveObject(currentIndex - 1);
    }


    
    
    



}
