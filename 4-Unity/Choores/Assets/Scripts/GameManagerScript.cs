
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public int currentLocation;
    public bool customerASpawned;
    public bool customerBSpawned;
    public int customerALocation = -1;
    public int customerBLocation = -1;
    public bool bathroomDirty;
    public bool newStockArrived;
    public GameObject specialLabel;
    private string specialLocation = "Office";

    public void moveLeft()
    {
        switch (currentLocation)
        {
            case 0:
                currentLocation = 1;
                specialLocation = " ";
                break;
            case 1:
                currentLocation = 2;
                specialLocation = "Changing";
                break;
            case 2:
                currentLocation = 0;
                specialLocation = "Office";
                break;
            case 3:
                currentLocation = 4;
                specialLocation = " ";
                break;
            case 4:
                currentLocation = 0;
                specialLocation = "Office";
                break;

        }
        setSpecial();
    }

    public void moveRight()
    {
        switch (currentLocation)
        {
            case 0:
                currentLocation = 4;
                specialLocation = " ";
                break;
            case 1:
                currentLocation = 0;
                specialLocation = "Office";
                break;
            case 2:
                currentLocation = 1;
                specialLocation = " ";
                break;
            case 3:
                currentLocation = 0;
                specialLocation = "Office";
                break;
            case 4:
                currentLocation = 3;
                specialLocation = " ";
                break;
        }
        setSpecial();
    }

    public void moveBack()
    {
        switch (currentLocation)
        {
            case 0:
                currentLocation = 7;
                specialLocation = " ";
                break;
            case 5:
                currentLocation = 2;
                specialLocation = "Changing";
                break;
            case 6:
                currentLocation = 5;
                specialLocation = "Bathroom";
                break;
            case 7:
                currentLocation = 0;
                specialLocation = "Office";
                break;
            case 8:
                currentLocation = 0;
                specialLocation = "Office";
                break;
            case 9:
                currentLocation = 8;
                specialLocation = "Dock";
                break;
        }
        setSpecial();
    }

    public void enterSpecial()
    {
        switch (currentLocation)
        {
            case 0:
                currentLocation = 8;
                specialLocation = "Dock";
                break;
            case 2:
                currentLocation = 5;
                specialLocation = "Bathroom";
                break;
            case 5:
                currentLocation = 6;
                specialLocation = " ";
                break;
            case 8:
                currentLocation = 9;
                specialLocation = " ";
                break;
        }
        setSpecial();
    }

    public void setSpecial()
    {
        TMP_Text specialLab = specialLabel.GetComponent<TMP_Text>();
        specialLab.text = specialLocation;
        setLocation();
    }

    public void setLocation()
    {

        GameObject mainLab = GameObject.Find("Main");
        GameObject mainALab = GameObject.Find("MainA");
        GameObject mainABLab = GameObject.Find("MainAB");
        GameObject mainBLab = GameObject.Find("MainB");
        GameObject clearLab = GameObject.Find("Clearance");
        GameObject clearALab = GameObject.Find("ClearanceA");
        GameObject clearABLab = GameObject.Find("ClearanceAB");
        GameObject clearBLab = GameObject.Find("ClearanceB");
        GameObject rearLab = GameObject.Find("Rear");
        GameObject rearALab = GameObject.Find("RearA");
        GameObject rearABLab = GameObject.Find("RearAB");
        GameObject rearBLab = GameObject.Find("RearB");
        GameObject shoesLab = GameObject.Find("Shoes");
        GameObject shoesALab = GameObject.Find("ShoesA");
        GameObject shoesABLab = GameObject.Find("ShoesAB");
        GameObject shoesBLab = GameObject.Find("ShoesB");
        GameObject suitsLab = GameObject.Find("Suits");
        GameObject suitsALab = GameObject.Find("SuitsA");
        GameObject suitsABLab = GameObject.Find("SuitsAB");
        GameObject suitsBLab = GameObject.Find("SuitsB");
        GameObject changingLab = GameObject.Find("Changing");
        GameObject changingALab = GameObject.Find("ChangingA");
        GameObject changingABLab = GameObject.Find("ChangingAB");
        GameObject changingBLab = GameObject.Find("ChangingB");
        GameObject bathroomALab = GameObject.Find("BathroomA");
        GameObject bathroomBLab = GameObject.Find("BathroomB");
        GameObject backstoreLab = GameObject.Find("Backstore");
        GameObject officeLab = GameObject.Find("Office");
        GameObject dockALab = GameObject.Find("DockA");
        GameObject dockBLab = GameObject.Find("DockB");

        Image main = mainLab.GetComponent<Image>();
        Image mainA = mainALab.GetComponent<Image>();
        Image mainAB = mainABLab.GetComponent<Image>();
        Image mainB = mainBLab.GetComponent<Image>();
        Image clear = clearLab.GetComponent<Image>();
        Image clearA = clearALab.GetComponent<Image>();
        Image clearAB = clearABLab.GetComponent<Image>();
        Image clearB = clearBLab.GetComponent<Image>();
        Image rear = rearLab.GetComponent<Image>();
        Image rearA = rearALab.GetComponent<Image>();
        Image rearAB = rearABLab.GetComponent<Image>();
        Image rearB = rearBLab.GetComponent<Image>();
        Image shoes = shoesLab.GetComponent<Image>();
        Image shoesA = shoesALab.GetComponent<Image>();
        Image shoesAB = shoesABLab.GetComponent<Image>();
        Image shoesB = shoesBLab.GetComponent<Image>();
        Image suits = suitsLab.GetComponent<Image>();
        Image suitsA = suitsALab.GetComponent<Image>();
        Image suitsAB = suitsABLab.GetComponent<Image>();
        Image suitsB = suitsBLab.GetComponent<Image>();
        Image changing = changingLab.GetComponent<Image>();
        Image changingA = changingALab.GetComponent<Image>();
        Image changingAB = changingABLab.GetComponent<Image>();
        Image changingB = changingBLab.GetComponent<Image>();
        Image bathroomA = bathroomALab.GetComponent<Image>();
        Image bathroomB = bathroomBLab.GetComponent<Image>();
        Image backstore = backstoreLab.GetComponent<Image>();
        Image office = officeLab.GetComponent<Image>();
        Image dockA = dockALab.GetComponent<Image>();
        Image dockB = dockBLab.GetComponent<Image>();

        main.enabled = false;
        mainA.enabled = false;
        mainAB.enabled = false;
        mainB.enabled = false;
        clear.enabled = false;
        clearA.enabled = false;
        clearAB.enabled = false;
        clearB.enabled = false;
        rear.enabled = false;
        rearA.enabled = false;
        rearAB.enabled = false;
        rearB.enabled = false;
        shoes.enabled = false;
        shoesA.enabled = false;
        shoesAB.enabled = false;
        shoesB.enabled = false;
        suits.enabled = false;
        suitsA.enabled = false;
        suitsAB.enabled = false;
        suitsB.enabled = false;
        changing.enabled = false;
        changingA.enabled = false;
        changingAB.enabled = false;
        changingB.enabled = false;
        bathroomA.enabled = false;
        bathroomB.enabled = false;
        backstore.enabled = false;
        office.enabled = false;
        dockA.enabled = false;
        dockB.enabled = false;

        switch (currentLocation)
        {
            case 0:
                if(customerALocation != 0 && customerBLocation != 0)
                {
                    main.enabled = true;
                }
                else if (customerALocation == 0 && customerBLocation != 0)
                {
                    mainA.enabled = true;
                }
                else if (customerALocation == 0 && customerBLocation == 0)
                {
                    mainAB.enabled = true;
                }
                else if (customerALocation != 0 && customerBLocation == 0)
                {
                    mainB.enabled = true;
                }
                break;
            case 1:
                if (customerALocation != 1 && customerBLocation != 1)
                {
                    clear.enabled = true;
                }
                else if (customerALocation == 1 && customerBLocation != 1)
                {
                    clearA.enabled = true;
                }
                else if (customerALocation == 1 && customerBLocation == 1)
                {
                    clearAB.enabled = true;
                }
                else if (customerALocation != 1 && customerBLocation == 1)
                {
                    clearB.enabled = true;
                }
                break;
            case 2:
                if (customerALocation != 2 && customerBLocation != 2)
                {
                    rear.enabled = true;
                }
                else if (customerALocation == 2 && customerBLocation != 2)
                {
                    rearA.enabled = true;
                }
                else if (customerALocation == 2 && customerBLocation == 2)
                {
                    rearAB.enabled = true;
                }
                else if (customerALocation != 2 && customerBLocation == 2)
                {
                    rearB.enabled = true;
                }
                break;
            case 3:
                if (customerALocation != 3 && customerBLocation != 3)
                {
                    shoes.enabled = true;
                }
                else if (customerALocation == 3 && customerBLocation != 3)
                {
                    shoesA.enabled = true;
                }
                else if (customerALocation == 3 && customerBLocation == 3)
                {
                    shoesAB.enabled = true;
                }
                else if (customerALocation != 3 && customerBLocation == 3)
                {
                    shoesB.enabled = true;
                }
                break;
            case 4:
                if (customerALocation != 4 && customerBLocation != 4)
                {
                    suits.enabled = true;
                }
                else if (customerALocation == 4 && customerBLocation != 4)
                {
                    suitsA.enabled = true;
                }
                else if (customerALocation == 4 && customerBLocation == 4)
                {
                    suitsAB.enabled = true;
                }
                else if (customerALocation != 4 && customerBLocation == 4)
                {
                    suitsB.enabled = true;
                }
                break;
            case 5:
                if (customerALocation != 5 && customerBLocation != 5)
                {
                    changing.enabled = true;
                }
                else if (customerALocation == 5 && customerBLocation != 5)
                {
                    changingA.enabled = true;
                }
                else if (customerALocation == 5 && customerBLocation == 5)
                {
                    changingAB.enabled = true;
                }
                else if (customerALocation != 5 && customerBLocation == 5)
                {
                    changingB.enabled = true;
                }
                break;
            case 6:
                if(!bathroomDirty)
                {
                    bathroomA.enabled = true;
                }
                else
                {
                    bathroomB.enabled = true;
                }
                break;
            case 7:
                backstore.enabled = true;
                break;
            case 8:
                office.enabled = true;
                break;
            case 9:
                if (!newStockArrived)
                {
                    dockA.enabled = true;
                } else
                {
                    dockB.enabled = true;
                }
                break;
        }

        buttonVisibility();
    }

    public void buttonVisibility()
    {
        GameObject leftButtonLab = GameObject.Find("LeftButton");
        GameObject leftBtnLab = GameObject.Find("Left");
        GameObject backButtonLab = GameObject.Find("BackButton");
        GameObject backBtnLab = GameObject.Find("Back");
        GameObject specialButtonLab = GameObject.Find("SpecialButton");
        GameObject specialBtnLab = GameObject.Find("Special");
        GameObject rightButtonLab = GameObject.Find("RightButton");
        GameObject rightBtnLab = GameObject.Find("Right");

        Image leftButton = leftButtonLab.GetComponent<Image>();
        TMP_Text left = leftBtnLab.GetComponent<TMP_Text>();
        Image backButton = backButtonLab.GetComponent<Image>();
        TMP_Text back = backBtnLab.GetComponent<TMP_Text>();
        Image specialButton = specialButtonLab.GetComponent<Image>();
        TMP_Text special = specialBtnLab.GetComponent<TMP_Text>();
        Image rightButton = rightButtonLab.GetComponent<Image>();
        TMP_Text right = rightBtnLab.GetComponent<TMP_Text>();

        switch (currentLocation)
        {
            case 0:
                leftButton.enabled = true;
                left.enabled = true;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = true;
                special.enabled = true;
                rightButton.enabled = true;
                right.enabled = true;
                break;
            case 1:
                leftButton.enabled = true;
                left.enabled = true;
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = true;
                right.enabled = true;
                break;
            case 2:
                leftButton.enabled = true;
                left.enabled = true;
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = true;
                special.enabled = true;
                rightButton.enabled = true;
                right.enabled = true;
                break;
            case 3:
                leftButton.enabled = true;
                left.enabled = true;
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = true;
                right.enabled = true;
                break;
            case 4:
                leftButton.enabled = true;
                left.enabled = true;
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = true;
                right.enabled = true;
                break;
            case 5:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = true;
                special.enabled = true;
                rightButton.enabled = false;
                right.enabled = false;
                break;
            case 6:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = false;
                right.enabled = false;
                break;
            case 7:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = false;
                right.enabled = false;
                break;
            case 8:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = true;
                special.enabled = true;
                rightButton.enabled = false;
                right.enabled = false;
                break;
            case 9:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = true;
                back.enabled = true;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = false;
                right.enabled = false;
                break;
        }
    }
}
