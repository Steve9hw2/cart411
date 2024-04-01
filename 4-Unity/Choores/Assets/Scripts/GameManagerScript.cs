
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private string menuScene = "Menu";
    [SerializeField] private string endScene = "End";
    // LOCATION
    public int currentLocation;
    private int storedLocation;

    // CUSTOMER SPAWNING
    public bool customerASpawned;
    public bool customerBSpawned;
    public int customerALocation = -1;
    public int customerBLocation = -1;

    // GAMEPLAY BOOLS
    public bool talking;
    public bool bathroomDirty;
    public bool newStockArrived;
    public bool dayEnded;
    public int dayNumber;
    private bool guideAoverride;
    private bool guideBoverride;
    private bool bathroomInUse;
    private string bathroomUser;
    private bool isMusicPlaying;
    private bool dayEndMusicPlaying;

    // SPECIAL BUTTON
    public GameObject specialLabel;
    private string specialLocation = "Office";

    // TIMER FUNCTIONS
    public float dayLength;
    public float newCustomerCheck;
    public float busyworkEventCheck;
    public float bathroomTime;
    private float customerAbathroomTime;
    private float customerBbathroomTime;

    // CUSTOMER VARIABLES
    public float minimumPatience;
    public float maximumPatience;
    public float minimumAgreeability;
    public float maximumAgreeability;
    public float minimumOpinion;
    public float maximumOpinion;
    public float minimumBudget;
    public float maximumBudget;
    private string[] names = new string[]{"Liam","Noah","Oliver","James","Elijah","William","Henry","Lucas","Benjamin","Theodore","Mateo","Levi","Sebastian","Daniel","Jack","Michael","Alexander","Owen","Asher","Samuel","Ethan","Leo","Jackson","Mason","Ezra","John","Hudson","Luca","Aiden","Joseph","David","Jacob","Logan","Luke","Julian","Gabriel","Grayson","Wyatt","Matthew","Maverick","Derrick","Dylan","Isaac","Elias","Anthony","Thomas","Jayden","Carter","Santiago","Ezekiel","Charles"};

    // CUSTOMER DIALOG
    private string[] dWantSuit = new string[] { "I'm looking for a new suit.", "You guys have suits, right?", "I need some formalwear.", "I need something clean.", "I need a jacket and pants.", "Show me your best suits.", "I need a suit to start with."};
    private string[] dWantPant = new string[] { "I need some pants.", "I need a bottom to go with a shirt I have.", "Do you have chinos?", "I need some light pants for when I go out.", "Do you guys have normal pants?", "I really like those Bockers pants you guys sell.", "Take me to your pants."};
    private string[] dWantShoes = new string[] { "I need a nice pair of shoes.", "Where are your dress shoes?", "I could use a new pair of dress shoes.", "My shoes are pretty beat up, so I need new ones.", "Do you guys have Mockports?", "My girlfriend says the shoes I have aren't clean enough.", "I'd like to buy some new shoes." };
    private string[] dWantSales = new string[] { "Show me your sales.", "What's your best price?", "I wanna see the specials!", "Is this your best price?", "I don't want to spend a lot of money.", "Wheres the 70% off stuff?", "I heard there's a Clearance section?"};
    private string[] dWantBathroom = new string[] {"I need to use your bathroom.", "Are your bathrooms public?", "Do you guys have a restroom?", "I've been looking for a bathroom for ages!", "Please tell me there's a bathroom.", "Can I use the bathroom?"};
    private string[] dRevealBudget = new string[] {"I'm working with about ", "I don't want to spend anymore than ", "Show me what you've got under ", "Please tell me it won't cost more than ", "I really don't wanna spend more than ", "I've budgeted about ", "Let's say for now... "};
    private string[] dRevealName = new string[] {"I'm ", "My name is ", "Oh sorry, I'm ", "Thank you! I'm ", "I should introduce myself, I'm "};
    private string[] dTalkWeather = new string[] {"The weather outside really is something.", "It's such a nice day outside.", "It feels like forever since the sun's been out.", "It's hard to have a bad day with such nice weather.", "I'm just glad it's not raining.", "It's pretty nice out, yeah.", "I suppose it has gotten rather clear out." };
    private string[] dTalkNews = new string[] {"That thing that happened was crazy.", "Have you heard the news, recently?", "It sounds like strange stuff is happening.", "You can't always take the news at face value.", "I don't really watch the news.", "Did that really happen? It sounds a little farfetched." };
    private string[] dTalkSports = new string[] {"Our team won their game last night!", "It sounds like the local team won their game last night.", "Were you watching the game last night?", "It's a shame our team lost last night.", "What a game last night...", "Oh, I don't watch sports. How did it go?", "Hm? Mhm." };
    private string[] dTalkOccasion = new string[] {"It's not everyday you get married!", "I'm so happy for my sibling.", "I can't believe it's already prom season.", "Man, I never have to wear stuff like this.", "I don't really have a choice but to be there.", "The event's in a few months.", "I need this stuff for tomorrow."};
    private string[] dTalkAwkward = new string[] {"Ah... erm... yeah.", "Mmm....", ".....Sure.", "...I suppose so.", "....." };
    private string[] dTalkFrustrated = new string[] {"...","I really just want to be out of here.","Nothing agaisnt you, but this stuff's a ripoff.", "Why am I even here right now.", "...ugh."};
    private string[] dOpenToSuit = new string[] {"Yeah, I could probably use a new suit.","Sure, let's see what kinda suits you got.", "Oh, what suits do you have?", "You make a good point. Show me your suits.", "How expensive are your suits?" };
    private string[] dOpenToPants = new string[] {"I didn't realize you had pants besides slacks.","Oh yeah, I'm due for some casual pants.","...I probably should get more pants.","Where are your pants?","Do you have any deals on pants right now?" };
    private string[] dOpenToShoes = new string[] { "You're right... I could use some shoes.", "You got any deals on shoes for me?", "The shoes you've got seem real nice.","I'm lacking some good shoes, actually.","...Do you guys have shoes?"};
    private string[] dOpenToSales = new string[] { "Sure, I may as well take a look at the sales.","You said up to how much off??", "Oh, so that's where the deals are.","Do you have anything good on sale?","I'll take a look at your clearance section."};
    private string[] dOpenToTons = new string[] { "I could use plenty more.","That's all? Here I was thinking it'd cost more!","At that price, you may as well show me what else you have.", "I'll be needing a lot more than that!", "We've hardly even dented my budget!" };
    private string[] dOpenToNone = new string[] { "...No thank you.","That'll be alright, thanks.","I'll be alright with this.","Nah, I don't need anything else.","Where do I go to pay?"};
    private string[] dEndSaleHappy = new string[] {"Thanks for your help!","Have a nice rest of your day!","Thank you very much!"};
    private string[] dEndSaleBad = new string[] {"I'm not buying this.","No way are you making me pay for this.","I'm out of here."};

    // CUSTOMER A LOGIC
    private float customerApatience;
    private float customerAagreeability;
    private float customerAopinion;
    private float customerAbudget;
    private bool customerAbudgetRevealed;
    private string wantIsA;
    private bool customerAwantRevealed;
    private string customerAname;
    private bool customerAnameRevealed;
    private float customerAcart;
    private string customerAdialog;
    private bool customerAshoppingOver;
    private bool customerAcheckedOut;

    // CUSTOMER B LOGIC
    private float customerBpatience;
    private float customerBagreeability;
    private float customerBopinion;
    private float customerBbudget;
    private bool customerBbudgetRevealed;
    private string wantIsB;
    private bool customerBwantRevealed;
    private string customerBname;
    private bool customerBnameRevealed;
    private float customerBcart;
    private string customerBdialog;
    private bool customerBshoppingOver;
    private bool customerBcheckedOut;

    // STORE STATS
    private float salesDaily;
    private int numOfSales;
    private float salesWTD;
    private int surveyResponses = 0;
    private float surveyScoreTotal = 0;
    private float surveyScoreAvg = 0;
    private int currentItems = 0;
    private int totalItems = 0;
    private float dailyDPT = 0;
    private int surveyNPS9 = 0;
    private int surveyNPS10 = 0;
    private int surveyNPS0 = 0;
    private int surveyNPSm1 = 0;
    private float netPromoterScore = 0;

    private void Start()
    {
        dayLength = 100;
        buttonVisibility();
        exitTalk();
    }
    private void Update()
    {
        GameObject sliderLab = GameObject.Find("TimeSlider");
        GameObject converseButtonALab = GameObject.Find("ConverseButtonA");
        Image converseBtnA = converseButtonALab.GetComponent<Image>();
        GameObject converseButtonATxtLab = GameObject.Find("ConverseA");
        TMP_Text converseA = converseButtonATxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonALab = GameObject.Find("ClarifyButtonA");
        Image clarifyBtnA = clarifyButtonALab.GetComponent<Image>();
        GameObject clarifyALab = GameObject.Find("ClarifyA");
        TMP_Text clarifyA = clarifyALab.GetComponent<TMP_Text>();
        GameObject guideToButtonALab = GameObject.Find("GuideButtonA");
        Image guideToBtnA = guideToButtonALab.GetComponent<Image>();
        GameObject guideToButtonATxtLab = GameObject.Find("GuideA");
        TMP_Text guideA = guideToButtonATxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonALab = GameObject.Find("SuggestButtonA");
        Image suggestBtnA = suggestButtonALab.GetComponent<Image>();
        GameObject suggestButtonATxtLab = GameObject.Find("SuggestA");
        TMP_Text suggestA = suggestButtonATxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonALab = GameObject.Find("CheckoutButtonA");
        Image checkoutBtnA = checkoutButtonALab.GetComponent<Image>();
        GameObject checkoutButtonATxtLab = GameObject.Find("CheckoutA");
        TMP_Text checkoutA = checkoutButtonATxtLab.GetComponent<TMP_Text>();

        GameObject converseButtonBLab = GameObject.Find("ConverseButtonB");
        Image converseBtnB = converseButtonBLab.GetComponent<Image>();
        GameObject converseButtonBTxtLab = GameObject.Find("ConverseB");
        TMP_Text converseB = converseButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonBLab = GameObject.Find("ClarifyButtonB");
        Image clarifyBtnB = clarifyButtonBLab.GetComponent<Image>();
        GameObject clarifyBLab = GameObject.Find("ClarifyB");
        TMP_Text clarifyB = clarifyBLab.GetComponent<TMP_Text>();
        GameObject guideToButtonBLab = GameObject.Find("GuideButtonB");
        Image guideToBtnB = guideToButtonBLab.GetComponent<Image>();
        GameObject guideToButtonBTxtLab = GameObject.Find("GuideB");
        TMP_Text guideB = guideToButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonBLab = GameObject.Find("SuggestButtonB");
        Image suggestBtnB = suggestButtonBLab.GetComponent<Image>();
        GameObject suggestButtonBTxtLab = GameObject.Find("SuggestB");
        TMP_Text suggestB = suggestButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonBLab = GameObject.Find("CheckoutButtonB");
        Image checkoutBtnB = checkoutButtonBLab.GetComponent<Image>();
        GameObject checkoutButtonBTxtLab = GameObject.Find("CheckoutB");
        TMP_Text checkoutB = checkoutButtonBTxtLab.GetComponent<TMP_Text>();

        GameObject warnToiletLabel = GameObject.Find("WarnBathroom");
        Image warnToilet = warnToiletLabel.GetComponent<Image>();
        GameObject warnStockLabel = GameObject.Find("WarnStock");
        Image warnStock = warnStockLabel.GetComponent<Image>();

        GameObject cleanButtonLabel = GameObject.Find("CleanButton");
        Image cleanButton = cleanButtonLabel.GetComponent<Image>();
        GameObject cleanLabel = GameObject.Find("Clean");
        TMP_Text clean = cleanLabel.GetComponent<TMP_Text>();

        GameObject receiveButtonLabel = GameObject.Find("ReceiveButton");
        Image receiveButton = receiveButtonLabel.GetComponent<Image>();
        GameObject receiveLabel = GameObject.Find("Receive");
        TMP_Text receive = receiveLabel.GetComponent<TMP_Text>();

        GameObject musicDay1Label = GameObject.Find("MusicDay1");
        AudioSource musicDay1 = musicDay1Label.GetComponent<AudioSource>();
        GameObject musicDay2Label = GameObject.Find("MusicDay2");
        AudioSource musicDay2 = musicDay2Label.GetComponent<AudioSource>();
        GameObject musicDay3Label = GameObject.Find("MusicDay3");
        AudioSource musicDay3 = musicDay3Label.GetComponent<AudioSource>();
        GameObject musicDay4Label = GameObject.Find("MusicDay4");
        AudioSource musicDay4 = musicDay4Label.GetComponent<AudioSource>();
        GameObject musicDay5Label = GameObject.Find("MusicDay5");
        AudioSource musicDay5 = musicDay5Label.GetComponent<AudioSource>();
        GameObject musicDay6Label = GameObject.Find("MusicDay6");
        AudioSource musicDay6 = musicDay6Label.GetComponent<AudioSource>();
        GameObject musicDay7Label = GameObject.Find("MusicDay7");
        AudioSource musicDay7 = musicDay7Label.GetComponent<AudioSource>();
        GameObject musicDayEndLabel = GameObject.Find("MusicDayEnd");
        AudioSource musicDayEnd = musicDayEndLabel.GetComponent<AudioSource>();

        if (bathroomDirty)
        {
            warnToilet.enabled = true;
            if(currentLocation == 6)
            {
                cleanButton.enabled = true;
                clean.enabled = true;
            }
            else
            {
                cleanButton.enabled = false;
                clean.enabled = false;
            }
        }
        else
        {
            warnToilet.enabled = false;
            cleanButton.enabled = false;
            clean.enabled = false;
        }
        if (newStockArrived)
        {
            warnStock.enabled = true;
            if(currentLocation == 9)
            {
                receiveButton.enabled = true;
                receive.enabled = true;
            } 
            else
            {
                receiveButton.enabled = false;
                receive.enabled = false;
            }
        }
        else
        {
            warnStock.enabled = false;
            receiveButton.enabled = false;
            receive.enabled = false;
        }

        if (dayLength > 0)
        {
            if (!isMusicPlaying)
            {
                switch (dayNumber)
                {
                    case 1:
                        musicDay1.Play();
                        musicDay2.Stop();
                        musicDay3.Stop();
                        musicDay4.Stop();
                        musicDay5.Stop();
                        musicDay6.Stop();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 2:
                        musicDay1.Stop();
                        musicDay2.Play();
                        musicDay3.Stop();
                        musicDay4.Stop();
                        musicDay5.Stop();
                        musicDay6.Stop();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 3:
                        musicDay1.Stop();
                        musicDay2.Stop();
                        musicDay3.Play();
                        musicDay4.Stop();
                        musicDay5.Stop();
                        musicDay6.Stop();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 4:
                        musicDay1.Stop();
                        musicDay2.Stop();
                        musicDay3.Stop();
                        musicDay4.Play();
                        musicDay5.Stop();
                        musicDay6.Stop();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 5:
                        musicDay1.Stop();
                        musicDay2.Stop();
                        musicDay3.Stop();
                        musicDay4.Stop();
                        musicDay5.Play();
                        musicDay6.Stop();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 6:
                        musicDay1.Stop();
                        musicDay2.Stop();
                        musicDay3.Stop();
                        musicDay4.Stop();
                        musicDay5.Stop();
                        musicDay6.Play();
                        musicDay7.Stop();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                    case 7:
                        musicDay1.Stop();
                        musicDay2.Stop();
                        musicDay3.Stop();
                        musicDay4.Stop();
                        musicDay5.Stop();
                        musicDay6.Stop();
                        musicDay7.Play();
                        musicDayEnd.Stop();
                        isMusicPlaying = true;
                        break;
                }
            }
            
            if (!talking)
            {
                dayLength -= Time.deltaTime;
                sliderLab.GetComponent<Slider>().value = dayLength;
                newCustomerCheck -= Time.deltaTime;
                busyworkEventCheck -= Time.deltaTime;
            }
            if(newCustomerCheck <= 0)
            {
                if (!customerBSpawned && customerASpawned)
                {
                    customerBSpawned = true;
                    customerBLocation = 0;
                    generateCustomerB();
                    setLocation();
                }
                if (!customerASpawned)
                        {
                            customerASpawned = true;
                            customerALocation = 0;
                            generateCustomerA();
                            setLocation();
                }      
                newCustomerCheck = 5;
            }
            if(busyworkEventCheck <= 0)
            {
                if (!newStockArrived)
                {
                    newStockArrived = true;
                }
                busyworkEventCheck = 20;
            }
        }
        if(dayLength <= 0)
        {
            Debug.Log("Time expired!");
            currentLocation = 8;
            resetCustomerA();
            resetCustomerB();
            dayEnded = true;
            if (!dayEndMusicPlaying)
            {
                salesWTD += salesDaily;
                isMusicPlaying = false;
                dayEndMusicPlaying = true;
                musicDay1.Stop();
                musicDay2.Stop();
                musicDay3.Stop();
                musicDay4.Stop();
                musicDay5.Stop();
                musicDay6.Stop();
                musicDay7.Stop();
                musicDayEnd.Play();
            }
        }

        GameObject eodStatsLabel = GameObject.Find("EODStats");
        Image eodStats = eodStatsLabel.GetComponent<Image>();
        GameObject statsLabelLabel = GameObject.Find("StatsLabel");
        TMP_Text statsLabel = statsLabelLabel.GetComponent<TMP_Text>();
        GameObject dptLabelLabel = GameObject.Find("DPTLabel");
        TMP_Text dptLabel = dptLabelLabel.GetComponent<TMP_Text>();
        GameObject notLabelLabel = GameObject.Find("NumOfTransactionsLabel");
        TMP_Text notLabel = notLabelLabel.GetComponent<TMP_Text>();
        GameObject salesLabelLabel = GameObject.Find("SalesLabel");
        TMP_Text salesLabel = salesLabelLabel.GetComponent<TMP_Text>();
        GameObject surveyResponsesLabel = GameObject.Find("SurveyResponses");
        TMP_Text surveyResponseNo = surveyResponsesLabel.GetComponent<TMP_Text>();
        GameObject npsLabelLabel = GameObject.Find("NPSLabel");
        TMP_Text npsLabel = npsLabelLabel.GetComponent<TMP_Text>();
        GameObject wtdLabelLabel = GameObject.Find("WTDLabel");
        TMP_Text wtdLabel = wtdLabelLabel.GetComponent<TMP_Text>();
        GameObject continueButtonLabel = GameObject.Find("ContinueButton");
        Image continueButton = continueButtonLabel.GetComponent<Image>();
        GameObject continueTxtLabel = GameObject.Find("Continue");
        TMP_Text continueTxt = continueTxtLabel.GetComponent<TMP_Text>();
        GameObject quitButtonLabel = GameObject.Find("QuitButton");
        Image quitButton = quitButtonLabel.GetComponent<Image>();
        GameObject quitTxtLabel = GameObject.Find("Quit");
        TMP_Text quitTxt = quitTxtLabel.GetComponent<TMP_Text>();

        GameObject backButtonLab = GameObject.Find("BackButton");
        GameObject backBtnLab = GameObject.Find("Back");
        GameObject specialButtonLab = GameObject.Find("SpecialButton");
        GameObject specialBtnLab = GameObject.Find("Special");
        Image backButton = backButtonLab.GetComponent<Image>();
        TMP_Text back = backBtnLab.GetComponent<TMP_Text>();
        Image specialButton = specialButtonLab.GetComponent<Image>();
        TMP_Text special = specialBtnLab.GetComponent<TMP_Text>();

        switch (dayEnded)
        {
            case false:
                eodStats.enabled = false;
                statsLabel.enabled = false;
                dptLabel.enabled = false;
                notLabel.enabled = false;
                salesLabel.enabled = false;
                surveyResponseNo.enabled = false;
                npsLabel.enabled = false;
                wtdLabel.enabled = false;
                continueButton.enabled = false;
                continueTxt.enabled = false;
                quitButton.enabled = false;
                quitTxt.enabled = false;
                break;
            case true:
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = false;
                special.enabled = false;

                eodStats.enabled = true;
                statsLabel.enabled = true;

                dptLabel.enabled = true;
                if(numOfSales > 0)
                {
                dailyDPT = salesDaily / numOfSales;
                dailyDPT = Mathf.Round(dailyDPT * 100.0f) * 0.01f;
                }
                dptLabel.text = "dpt: "+dailyDPT.ToString();

                notLabel.enabled = true;
                notLabel.text = "transactions: "+numOfSales.ToString();

                salesLabel.enabled = true;
                salesLabel.text = "sales: " + salesDaily;

                surveyResponseNo.enabled = true;
                surveyResponseNo.text = "survey responses: " + surveyResponses;

                if (surveyResponses > 0)
                {
                    calculateNPS();
                }
                else
                {
                    netPromoterScore = 0;
                }

                npsLabel.enabled = true;
                npsLabel.text = "net promoter score: " + netPromoterScore;

                wtdLabel.enabled = true;
                wtdLabel.text = "weekly sales: " + salesWTD;

                continueButton.enabled = true;
                continueTxt.enabled = true;
                quitButton.enabled = true;
                quitTxt.enabled = true;
                break;
        }

        checkGuidingA();
        checkGuidingB();

        if (customerAbudgetRevealed && customerAwantRevealed)
        {
            clarifyBtnA.enabled = false;
            clarifyA.enabled = false;
        }

        if (customerBbudgetRevealed && customerBwantRevealed)
        {
            clarifyBtnB.enabled = false;
            clarifyB.enabled = false;
        }

        if (!bathroomInUse)
        {
            customerAbathroomTime = 0;
            customerBbathroomTime = 0;
        } else if(customerAbathroomTime > 0)
        {
            customerAbathroomTime -= Time.deltaTime;
        } else if (customerBbathroomTime > 0)
        {
            customerBbathroomTime -= Time.deltaTime;
        }
        if (customerAbathroomTime <= 0 && bathroomInUse && bathroomUser == "A") {
            int r = UnityEngine.Random.Range(1, 3);
            if (r == 1)
            {
                bathroomDirty = true;
            }
            bathroomInUse = false;
            customerAbathroomTime = 0;
            customerALocation = 5;
            bathroomUser = " ";
            if (wantIsA == "Bathroom")
            {
                wantIsA = "Sales";
            }
        } else if (customerBbathroomTime <= 0 && bathroomInUse && bathroomUser == "B")
        {
            int r = UnityEngine.Random.Range(1, 3);
            if (r == 1)
            {
                bathroomDirty = true;
            }
            bathroomInUse = false;
            customerBbathroomTime = 0;
            customerBLocation = 5;
            bathroomUser = " ";
            if(wantIsB == "Bathroom")
            {
                wantIsB = "Sales";
            }
        }

        if (customerAshoppingOver)
        {
            guideToBtnA.enabled = false;
            guideA.enabled = false;
            suggestBtnA.enabled = false;
            suggestA.enabled = false;
        }
        if (customerBshoppingOver)
        {
            guideToBtnB.enabled = false;
            guideB.enabled = false;
            suggestBtnB.enabled = false;
            suggestB.enabled = false;
        }

        if (customerAcheckedOut)
        {
            guideToBtnA.enabled = false;
            guideA.enabled = false;
            clarifyBtnA.enabled = false;
            clarifyA.enabled = false;
            suggestBtnA.enabled = false;
            suggestA.enabled = false;
            converseBtnA.enabled = false;
            converseA.enabled = false;
            checkoutBtnA.enabled = false;
            checkoutA.enabled = false;
        }

        if (customerBcheckedOut)
        {
            guideToBtnB.enabled = false;
            guideB.enabled = false;
            clarifyBtnB.enabled = false;
            clarifyB.enabled = false;
            suggestBtnB.enabled = false;
            suggestB.enabled = false;
            converseBtnB.enabled = false;
            converseB.enabled = false;
            checkoutBtnB.enabled = false;
            checkoutB.enabled = false;
        }

    }

    public void generateCustomerA()
    {
        int wantVal = UnityEngine.Random.Range(1,9);
        switch (wantVal)
        {
            case 1: case 2:
                wantIsA = "Suits";
                break;
            case 3: case 4:
                wantIsA = "Pants";
                break;
            case 5: case 6:
                wantIsA = "Shoes";
                break;
            case 7: 
                wantIsA = "Sales";
                break;
            case 8: case 9:
                wantIsA = "Bathroom";
                break;
        }
        customerApatience = UnityEngine.Random.Range(minimumPatience, maximumPatience);

        customerAagreeability = UnityEngine.Random.Range(minimumAgreeability, maximumAgreeability);

        customerAopinion = UnityEngine.Random.Range(minimumOpinion, maximumOpinion);
        customerAbudget = UnityEngine.Random.Range(minimumBudget, maximumBudget);
        customerAbudget = Mathf.Round(customerAbudget * 100.0f) * 0.01f;
        customerAname = names[UnityEngine.Random.Range(0,names.Length)];
        customerAnameRevealed = false;
        customerAbudgetRevealed = false;
        customerAwantRevealed = false;
}

    public void generateCustomerB()
    {
        int wantVal = UnityEngine.Random.Range(1, 9);
        switch (wantVal)
        {
            case 1:
            case 2:
                wantIsB = "Suits";
                break;
            case 3:
            case 4:
                wantIsB = "Pants";
                break;
            case 5:
            case 6:
                wantIsB = "Shoes";
                break;
            case 7:
           
                wantIsB = "Sales";
                break;
            case 8:
            case 9:
                wantIsB = "Bathroom";
                break;
        }
        customerBpatience = UnityEngine.Random.Range(minimumPatience, maximumPatience);

        customerBagreeability = UnityEngine.Random.Range(minimumAgreeability, maximumAgreeability);

        customerBopinion = UnityEngine.Random.Range(minimumOpinion, maximumOpinion);
        customerBbudget = UnityEngine.Random.Range(minimumBudget, maximumBudget);
        customerBbudget = Mathf.Round(customerAbudget * 100.0f) * 0.01f;
        customerBname = names[UnityEngine.Random.Range(0, names.Length)];
        customerBnameRevealed = false;
        customerBbudgetRevealed = false;
        customerBwantRevealed = false;
    }

    private void checkGuidingA()
    {
        GameObject converseButtonALab = GameObject.Find("ConverseButtonA");
        Image converseBtnA = converseButtonALab.GetComponent<Image>();
        GameObject converseButtonATxtLab = GameObject.Find("ConverseA");
        TMP_Text converseA = converseButtonATxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonALab = GameObject.Find("ClarifyButtonA");
        Image clarifyBtnA = clarifyButtonALab.GetComponent<Image>();
        GameObject clarifyButtonATxtLab = GameObject.Find("ClarifyA");
        TMP_Text clarifyA = clarifyButtonATxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonALab = GameObject.Find("GuideButtonA");
        Image guideToBtnA = guideToButtonALab.GetComponent<Image>();
        GameObject guideToButtonATxtLab = GameObject.Find("GuideA");
        TMP_Text guideA = guideToButtonATxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonALab = GameObject.Find("SuggestButtonA");
        Image suggestBtnA = suggestButtonALab.GetComponent<Image>();
        GameObject suggestButtonATxtLab = GameObject.Find("SuggestA");
        TMP_Text suggestA = suggestButtonATxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonALab = GameObject.Find("CheckoutButtonA");
        Image checkoutBtnA = checkoutButtonALab.GetComponent<Image>();
        GameObject checkoutButtonATxtLab = GameObject.Find("CheckoutA");
        TMP_Text checkoutA = checkoutButtonATxtLab.GetComponent<TMP_Text>();

        GameObject toSuitsABtnLab = GameObject.Find("GuideToSuitsA");
        Image toSuitsABtn = toSuitsABtnLab.GetComponent<Image>();
        GameObject toSuitsATxt = GameObject.Find("ToSuitsA");
        TMP_Text toSuitsA = toSuitsATxt.GetComponent<TMP_Text>();
        GameObject toPantsABtnLab = GameObject.Find("GuideToPantsA");
        Image toPantsABtn = toPantsABtnLab.GetComponent<Image>();
        GameObject toPantsATxt = GameObject.Find("ToPantsA");
        TMP_Text toPantsA = toPantsATxt.GetComponent<TMP_Text>();
        GameObject toShoesABtnLab = GameObject.Find("GuideToShoesA");
        Image toShoesABtn = toShoesABtnLab.GetComponent<Image>();
        GameObject toShoesATxt = GameObject.Find("ToShoesA");
        TMP_Text toShoesA = toShoesATxt.GetComponent<TMP_Text>();
        GameObject toSalesABtnLab = GameObject.Find("GuideToSalesA");
        Image toSalesABtn = toSalesABtnLab.GetComponent<Image>();
        GameObject toSalesATxt = GameObject.Find("ToSalesA");
        TMP_Text toSalesA = toSalesATxt.GetComponent<TMP_Text>();
        GameObject toBathABtnLab = GameObject.Find("GuideToBathA");
        Image toBathABtn = toBathABtnLab.GetComponent<Image>();
        GameObject toBathATxt = GameObject.Find("ToBathA");
        TMP_Text toBathA = toBathATxt.GetComponent<TMP_Text>();

        if (guideAoverride)
        {
            converseBtnA.enabled = false;
            converseA.enabled = false;
            clarifyBtnA.enabled = false;
            clarifyA.enabled = false;
            guideToBtnA.enabled = false;
            guideA.enabled = false;
            suggestBtnA.enabled = false;
            suggestA.enabled = false;
            checkoutBtnA.enabled = false;
            checkoutA.enabled = false;

            toSuitsABtn.enabled = true;
            toSuitsA.enabled = true;
            toPantsABtn.enabled = true;
            toPantsA.enabled = true;
            toShoesABtn.enabled = true;
            toShoesA.enabled = true;
            toSalesABtn.enabled = true;
            toSalesA.enabled = true;
            if (!bathroomInUse)
            {
            toBathABtn.enabled = true;
            toBathA.enabled = true;
            }
        }
        else
        {
            toSuitsABtn.enabled = false;
            toSuitsA.enabled = false;
            toPantsABtn.enabled = false;
            toPantsA.enabled = false;
            toShoesABtn.enabled = false;
            toShoesA.enabled = false;
            toSalesABtn.enabled = false;
            toSalesA.enabled = false;
            toBathABtn.enabled = false;
            toBathA.enabled = false;
        }
    }

    public void talkA()
    {
        storedLocation = currentLocation;
        currentLocation = -2;
        GameObject converseButtonALab = GameObject.Find("ConverseButtonA");
        Image converseBtnA = converseButtonALab.GetComponent<Image>();
        GameObject converseButtonATxtLab = GameObject.Find("ConverseA");
        TMP_Text converseA = converseButtonATxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonALab = GameObject.Find("ClarifyButtonA");
        Image clarifyBtnA = clarifyButtonALab.GetComponent<Image>();
        GameObject clarifyButtonATxtLab = GameObject.Find("ClarifyA");
        TMP_Text clarifyA = clarifyButtonATxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonALab = GameObject.Find("GuideButtonA");
        Image guideToBtnA = guideToButtonALab.GetComponent<Image>();
        GameObject guideToButtonATxtLab = GameObject.Find("GuideA");
        TMP_Text guideA = guideToButtonATxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonALab = GameObject.Find("SuggestButtonA");
        Image suggestBtnA = suggestButtonALab.GetComponent<Image>();
        GameObject suggestButtonATxtLab = GameObject.Find("SuggestA");
        TMP_Text suggestA = suggestButtonATxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonALab = GameObject.Find("CheckoutButtonA");
        Image checkoutBtnA = checkoutButtonALab.GetComponent<Image>();
        GameObject checkoutButtonATxtLab = GameObject.Find("CheckoutA");
        TMP_Text checkoutA = checkoutButtonATxtLab.GetComponent<TMP_Text>();

        GameObject DialogBoxALab = GameObject.Find("DialogBoxA");
        Image DialogBoxA = DialogBoxALab.GetComponent<Image>();
        GameObject DialogALab = GameObject.Find("DialogA");
        TMP_Text DialogA = DialogALab.GetComponent<TMP_Text>();
        GameObject InfoboxALab = GameObject.Find("InfoboxA");
        Image InfoboxA = InfoboxALab.GetComponent<Image>();
        GameObject NameboxALab = GameObject.Find("NameboxA");
        Image NameboxA = NameboxALab.GetComponent<Image>();
        GameObject NameAObjLab = GameObject.Find("NameA");
        TMP_Text NameAObj = NameAObjLab.GetComponent<TMP_Text>();
        GameObject WantsAObjLab = GameObject.Find("WantsA");
        TMP_Text WantsAObj = WantsAObjLab.GetComponent<TMP_Text>();
        GameObject BudgetAObjLab = GameObject.Find("BudgetA");
        TMP_Text BudgetAObj = BudgetAObjLab.GetComponent<TMP_Text>();
        GameObject CartValAObjLab = GameObject.Find("CartValA");
        TMP_Text CartValAObj = CartValAObjLab.GetComponent<TMP_Text>();

        DialogBoxA.enabled = true;
        DialogA.enabled = true;
        InfoboxA.enabled = true;
        NameboxA.enabled = true;
        NameAObj.enabled = true;
        WantsAObj.enabled = true;
        BudgetAObj.enabled = true;
        CartValAObj.enabled = true;

        converseBtnA.enabled = true;
        converseA.enabled = true;
        if(!customerAwantRevealed || !customerAbudgetRevealed)
        {
            clarifyBtnA.enabled = true;
            clarifyA.enabled = true;
        }
        guideToBtnA.enabled = true;
        guideA.enabled = true;
        suggestBtnA.enabled = true;
        suggestA.enabled = true;
        checkoutBtnA.enabled = true;
        checkoutA.enabled = true;

        GameObject talkToALab = GameObject.Find("CustomerA");
        Image talkToA = talkToALab.GetComponent<Image>();
        talkToA.enabled = true;
        GameObject talkBackALab = GameObject.Find("TalkBackButtonA");
        Image talkBackA = talkBackALab.GetComponent<Image>();
        GameObject talkBackATextLab = GameObject.Find("TalkBackA");
        TMP_Text talkBackAtext = talkBackATextLab.GetComponent<TMP_Text>();
        talkBackA.enabled = true;
        talkBackAtext.enabled = true;
        talking = true;
        buttonVisibility();
    }

    private void updateDialogA(string val)
    {
        GameObject DialogALab = GameObject.Find("DialogA");
        TMP_Text DialogA = DialogALab.GetComponent<TMP_Text>();
        DialogA.text = val;
    }

    public void converseA()
    {
        GameObject NameAObjLab = GameObject.Find("NameA");
        TMP_Text NameAObj = NameAObjLab.GetComponent<TMP_Text>();

        if (!customerAnameRevealed)
        {
            customerAdialog = dRevealName[UnityEngine.Random.Range(0, dRevealName.Length)]+customerAname+".";
            customerAnameRevealed = true;
            NameAObj.text = customerAname;
        }
        else if (customerAnameRevealed)
        {
            if (customerAagreeability >= 5)
            {
                int topic = UnityEngine.Random.Range(1, 4);
                switch (topic)
                {
                    case 1:
                        customerAdialog = dTalkWeather[UnityEngine.Random.Range(0, dTalkWeather.Length)];
                        customerAagreeability--;
                        customerAopinion++;
                        break;
                    case 2:
                        customerAdialog = dTalkNews[UnityEngine.Random.Range(0, dTalkNews.Length)];
                        customerAagreeability--;
                        customerAopinion++;
                        break;
                    case 3:
                        customerAdialog = dTalkSports[UnityEngine.Random.Range(0, dTalkSports.Length)];
                        customerAagreeability--;
                        customerAopinion++;
                        break;
                    case 4:
                        customerAdialog = dTalkOccasion[UnityEngine.Random.Range(0, dTalkOccasion.Length)];
                        customerAagreeability--;
                        customerAopinion++;
                        break;
                }
            }
            if (customerAagreeability < 5 && customerAagreeability > 1)
            {
                customerAdialog = dTalkAwkward[UnityEngine.Random.Range(0, dTalkAwkward.Length)];
                customerAagreeability--;
            }
            if(customerAagreeability <= 1)
            {
                customerAdialog = dTalkFrustrated[UnityEngine.Random.Range(0, dTalkFrustrated.Length)];
                customerAagreeability--;
                customerAopinion--;
            }
        }
        updateDialogA(customerAdialog);
    }

    public void clarifyA()
    {
        GameObject clarifyButtonALab = GameObject.Find("ClarifyButtonA");
        Image clarifyBtnA = clarifyButtonALab.GetComponent<Image>();
        GameObject clarifyButtonATxtLab = GameObject.Find("ClarifyA");
        TMP_Text clarifyA = clarifyButtonATxtLab.GetComponent<TMP_Text>();

        GameObject WantsAObjLab = GameObject.Find("WantsA");
        TMP_Text WantsAObj = WantsAObjLab.GetComponent<TMP_Text>();
        GameObject BudgetAObjLab = GameObject.Find("BudgetA");
        TMP_Text BudgetAObj = BudgetAObjLab.GetComponent<TMP_Text>();

        if (!customerAbudgetRevealed)
        {
            customerAbudgetRevealed = true;
            customerAdialog = dRevealBudget[UnityEngine.Random.Range(0, dRevealBudget.Length)] + "$" + customerAbudget + ".";
            updateDialogA(customerAdialog);
            BudgetAObj.text = "Budget: $"+customerAbudget.ToString();
            return;
        }
        if (customerAbudgetRevealed)
        {
            customerAwantRevealed = true;
            switch (wantIsA)
            {
                case "Suits":
                    WantsAObj.text = "Wants: Suits";
                    customerAdialog = dWantSuit[UnityEngine.Random.Range(0, dWantSuit.Length)];
                    break;
                case "Pants":
                    WantsAObj.text = "Wants: Pants";
                    customerAdialog = dWantPant[UnityEngine.Random.Range(0, dWantPant.Length)];
                    break;
                case "Shoes":
                    WantsAObj.text = "Wants: Shoes";
                    customerAdialog = dWantShoes[UnityEngine.Random.Range(0, dWantShoes.Length)];
                    break;
                case "Sales":
                    WantsAObj.text = "Wants: Sales";
                    customerAdialog = dWantSales[UnityEngine.Random.Range(0, dWantSales.Length)];
                    break;
                case "Bathroom":
                    WantsAObj.text = "Wants: Bathroom";
                    customerAdialog = dWantBathroom[UnityEngine.Random.Range(0, dWantBathroom.Length)];
                    break;
            }
            updateDialogA(customerAdialog);
            return;
        }
        if(customerAwantRevealed && customerAbudgetRevealed)
        {
            customerAdialog = dTalkAwkward[UnityEngine.Random.Range(0, dTalkAwkward.Length)];
            clarifyBtnA.enabled = false;
            clarifyA.enabled = false;
        }
    }

    public void guideToA()
    {
        guideAoverride = true;
    }

    public void suggestA()
    {
        GameObject WantsAObjLab = GameObject.Find("WantsA");
        TMP_Text WantsAObj = WantsAObjLab.GetComponent<TMP_Text>();

        GameObject CartValAObjLab = GameObject.Find("CartValA");
        TMP_Text CartValAObj = CartValAObjLab.GetComponent<TMP_Text>();

        guideAoverride = false;
        switch (wantIsA)
        {
            case "Suits":
                if(customerALocation == 4)
                {
                    if (customerAbudget >= 1500)
                    {
                        customerAdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(600, 1200);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                    else
                    {
                        customerAdialog = dOpenToSuit[UnityEngine.Random.Range(0, dOpenToSuit.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(300, 700);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                }
                break;
            case "Pants":
                if(customerALocation == 2)
                {
                    if (customerAbudget >= 1500)
                    {
                        customerAdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(220, 500);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                    else
                    {
                        customerAdialog = dOpenToPants[UnityEngine.Random.Range(0, dOpenToPants.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(40, 170);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                }
                break;
            case "Shoes":
                if(customerALocation == 3)
                {
                    if (customerAbudget >= 1500)
                    {
                        customerAdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(200, 500);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                    else
                    {
                        customerAdialog = dOpenToShoes[UnityEngine.Random.Range(0, dOpenToShoes.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(60, 160);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                }
                break;
            case "Sales":
                if(customerALocation == 1)
                {
                    if (customerAbudget >= 1500)
                    {
                        customerAdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(300, 600);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        wantIsA = " ";
                        currentItems++;
                    }
                    else
                    {
                        customerAdialog = dOpenToSales[UnityEngine.Random.Range(0, dOpenToSales.Length)];
                        updateDialogA(customerAdialog);
                        float priceraw = UnityEngine.Random.Range(5, 300);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerAcart += price;
                        CartValAObj.text = "Cart: $" + customerAcart;
                        currentItems++;
                        wantIsA = " ";
                    }
                }
                break;
            case " ":
                if (customerApatience >= 5)
                {
                    int r = UnityEngine.Random.Range(1, 4);
                    switch (r)
                    {
                        case 1:
                            customerAdialog = dOpenToSuit[UnityEngine.Random.Range(0, dOpenToSuit.Length)];
                            updateDialogA(customerAdialog);
                            wantIsA = "Suits";
                            WantsAObj.text = "Wants: Suits";
                            break;
                        case 2:
                            customerAdialog = dOpenToPants[UnityEngine.Random.Range(0, dOpenToPants.Length)];
                            updateDialogA(customerAdialog);
                            wantIsA = "Pants";
                            WantsAObj.text = "Wants: Pants";
                            break;
                        case 3:
                            customerAdialog = dOpenToShoes[UnityEngine.Random.Range(0, dOpenToShoes.Length)];
                            updateDialogA(customerAdialog);
                            wantIsA = "Shoes";
                            WantsAObj.text = "Wants: Shoes";
                            break;
                        case 4:
                            customerAdialog = dOpenToSales[UnityEngine.Random.Range(0, dOpenToSales.Length)];
                            updateDialogA(customerAdialog);
                            wantIsA = "Sales";
                            WantsAObj.text = "Wants: Sales";
                            break;
                    }
                    customerApatience--;
                }
                else
                {
                    customerAdialog = dOpenToNone[UnityEngine.Random.Range(0, dOpenToNone.Length)];
                    updateDialogA(customerAdialog);
                    customerAshoppingOver = true;
                }
                break;
        }
    }

    public void checkoutA()
    {

        // SURVEY
        int b = 0;
        int s = 0;
        int pr = 0;
        int o = 0;
        if (bathroomDirty)
        {
            b = 0;
        }
        else
        {
            b = 1;
        }
        if (newStockArrived)
        {
            s = 0;
        } else
        {
            s = 1;
        } 
        if(customerAcart <= customerAbudget)
        {
            pr = 3;
        }
        else if(customerAcart >= customerAbudget * 1.1 && customerAcart < customerAbudget * 1.25)
        {
            pr = 2;
        } 
        else if (customerAcart >= customerAbudget * 1.25 && customerAcart < customerAbudget * 1.5)
        {
            pr = 1;
        } 
        else if (customerAcart >= customerAbudget * 1.5)
        {
            pr = 0;
        }
        o = (int)customerAopinion / 2;
        int surveyScore = b + s + pr + o;
        int r = UnityEngine.Random.Range(0, 10);
        if(surveyScore < 6)
        {
            if (r > 5)
            {
                surveyResponses += 1;
                surveyScoreTotal += surveyScore;
                surveyScoreAvg = surveyScoreTotal / surveyResponses;
                switch (surveyScore)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        surveyNPSm1++;
                        break;
                    case 7:
                    case 8:
                        surveyNPS0++;
                        break;
                    case 9:
                        surveyNPS9++;
                        break;
                    case 10:
                        surveyNPS10++;
                        break;
                }
                calculateNPS();
            }
        }
        else
        {
            if(r > 8)
            {
                surveyResponses += 1;
                surveyScoreTotal += surveyScore;
                surveyScoreAvg = surveyScoreTotal / surveyResponses;
                switch (surveyScore)
                {
                    case 0: case 1: case 2: case 3: case 4: case 5: case 6:
                        surveyNPSm1++;
                        break;
                    case 7: case 8:
                        surveyNPS0++;
                        break;
                    case 9:
                        surveyNPS9++;
                    break;
                    case 10:
                        surveyNPS10++;
                     break;
                }
                calculateNPS();

            }
        }
 

     if(customerApatience > 1 && customerAagreeability > 1)
        {
            salesDaily += customerAcart;
       //     salesWTD += salesDaily;
            numOfSales += 1;
            totalItems += currentItems;
            customerAdialog = dEndSaleHappy[UnityEngine.Random.Range(0, dEndSaleHappy.Length)];
            customerAcheckedOut = true;
        }
        else
        {
            customerAdialog = dEndSaleBad[UnityEngine.Random.Range(0, dEndSaleBad.Length)];
            customerAcheckedOut = true;
        }
        updateDialogA(customerAdialog);

}

    private void resetCustomerA()
    {
        GameObject NameAObjLab = GameObject.Find("NameA");
        TMP_Text NameAObj = NameAObjLab.GetComponent<TMP_Text>();
        GameObject WantsAObjLab = GameObject.Find("WantsA");
        TMP_Text WantsAObj = WantsAObjLab.GetComponent<TMP_Text>();
        GameObject BudgetAObjLab = GameObject.Find("BudgetA");
        TMP_Text BudgetAObj = BudgetAObjLab.GetComponent<TMP_Text>();
        GameObject CartValAObjLab = GameObject.Find("CartValA");
        TMP_Text CartValAObj = CartValAObjLab.GetComponent<TMP_Text>();

        customerApatience = 0;
        customerAagreeability = 0;
        customerAopinion = 0;
        customerAbudget = 0;
        customerAbudgetRevealed = false;
        wantIsA = "";
        customerAwantRevealed = false;
        customerAname = ""; 
        customerAnameRevealed = false;
        customerAcart = 0;
        customerAdialog = "hello i am customer would like purchase many thing.";
        NameAObj.text = "???";
        WantsAObj.text = "Wants: ???";
        BudgetAObj.text = "Budget: ???";
        CartValAObj.text = "Cart: 0$";
        updateDialogA(customerAdialog);
        customerAshoppingOver = false;
        customerASpawned = false;
        customerALocation = -1;
        customerAcheckedOut = false;
        setLocation();
}

    public void guideToSuitsA()
    {
        dayLength -= 5;
        customerALocation = 4;
        exitTalk();
        currentLocation = 4;
        setLocation();
    }

    public void guideToPantsA()
    {
        dayLength -= 5;
        customerALocation = 2;
        exitTalk();
        currentLocation = 2;
        setLocation();
        specialLocation = "Changing";
        setSpecial();
    }

    public void guideToShoesA()
    {
        dayLength -= 5;
        customerALocation = 3;
        exitTalk();
        currentLocation = 3;
        setLocation();
    }

    public void guideToSalesA()
    {
        dayLength -= 5;
        customerALocation = 1;
        exitTalk();
        currentLocation = 1;
        setLocation();
    }

    public void guideToBathA()
    {
        GameObject specialButtonLab = GameObject.Find("SpecialButton");
        GameObject specialBtnLab = GameObject.Find("Special");
        Image specialButton = specialButtonLab.GetComponent<Image>();
        TMP_Text specialBtn = specialBtnLab.GetComponent<TMP_Text>();
        dayLength -= 5;
        customerALocation = -6;
        exitTalk();
        currentLocation = 5;
        setLocation();
        specialButton.enabled = false;
        specialBtn.enabled = false;
        bathroomInUse = true;
        customerAbathroomTime = bathroomTime;
        bathroomUser = "A";
    }

    private void checkGuidingB()
    {
        GameObject converseButtonBLab = GameObject.Find("ConverseButtonB");
        Image converseBtnB = converseButtonBLab.GetComponent<Image>();
        GameObject converseButtonBTxtLab = GameObject.Find("ConverseB");
        TMP_Text converseB = converseButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonBLab = GameObject.Find("ClarifyButtonB");
        Image clarifyBtnB = clarifyButtonBLab.GetComponent<Image>();
        GameObject clarifyButtonBTxtLab = GameObject.Find("ClarifyB");
        TMP_Text clarifyB = clarifyButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonBLab = GameObject.Find("GuideButtonB");
        Image guideToBtnB = guideToButtonBLab.GetComponent<Image>();
        GameObject guideToButtonBTxtLab = GameObject.Find("GuideB");
        TMP_Text guideB = guideToButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonBLab = GameObject.Find("SuggestButtonB");
        Image suggestBtnB = suggestButtonBLab.GetComponent<Image>();
        GameObject suggestButtonBTxtLab = GameObject.Find("SuggestB");
        TMP_Text suggestB = suggestButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonBLab = GameObject.Find("CheckoutButtonB");
        Image checkoutBtnB = checkoutButtonBLab.GetComponent<Image>();
        GameObject checkoutButtonBTxtLab = GameObject.Find("CheckoutB");
        TMP_Text checkoutB = checkoutButtonBTxtLab.GetComponent<TMP_Text>();

        GameObject toSuitsBBtnLab = GameObject.Find("GuideToSuitsB");
        Image toSuitsBBtn = toSuitsBBtnLab.GetComponent<Image>();
        GameObject toSuitsBTxt = GameObject.Find("ToSuitsB");
        TMP_Text toSuitsB = toSuitsBTxt.GetComponent<TMP_Text>();
        GameObject toPantsBBtnLab = GameObject.Find("GuideToPantsB");
        Image toPantsBBtn = toPantsBBtnLab.GetComponent<Image>();
        GameObject toPantsBTxt = GameObject.Find("ToPantsB");
        TMP_Text toPantsB = toPantsBTxt.GetComponent<TMP_Text>();
        GameObject toShoesBBtnLab = GameObject.Find("GuideToShoesB");
        Image toShoesBBtn = toShoesBBtnLab.GetComponent<Image>();
        GameObject toShoesBTxt = GameObject.Find("ToShoesB");
        TMP_Text toShoesB = toShoesBTxt.GetComponent<TMP_Text>();
        GameObject toSalesBBtnLab = GameObject.Find("GuideToSalesB");
        Image toSalesBBtn = toSalesBBtnLab.GetComponent<Image>();
        GameObject toSalesBTxt = GameObject.Find("ToSalesB");
        TMP_Text toSalesB = toSalesBTxt.GetComponent<TMP_Text>();
        GameObject toBathBBtnLab = GameObject.Find("GuideToBathB");
        Image toBathBBtn = toBathBBtnLab.GetComponent<Image>();
        GameObject toBathBTxt = GameObject.Find("ToBathB");
        TMP_Text toBathB = toBathBTxt.GetComponent<TMP_Text>();

        if (guideBoverride)
        {
            converseBtnB.enabled = false;
            converseB.enabled = false;
            clarifyBtnB.enabled = false;
            clarifyB.enabled = false;
            guideToBtnB.enabled = false;
            guideB.enabled = false;
            suggestBtnB.enabled = false;
            suggestB.enabled = false;
            checkoutBtnB.enabled = false;
            checkoutB.enabled = false;

            toSuitsBBtn.enabled = true;
            toSuitsB.enabled = true;
            toPantsBBtn.enabled = true;
            toPantsB.enabled = true;
            toShoesBBtn.enabled = true;
            toShoesB.enabled = true;
            toSalesBBtn.enabled = true;
            toSalesB.enabled = true;
            if (!bathroomInUse)
            {
                toBathBBtn.enabled = true;
                toBathB.enabled = true;
            }
        }
        else
        {
            toSuitsBBtn.enabled = false;
            toSuitsB.enabled = false;
            toPantsBBtn.enabled = false;
            toPantsB.enabled = false;
            toShoesBBtn.enabled = false;
            toShoesB.enabled = false;
            toSalesBBtn.enabled = false;
            toSalesB.enabled = false;
            toBathBBtn.enabled = false;
            toBathB.enabled = false;
        }
    }

    public void talkB()
    {
        storedLocation = currentLocation;
        currentLocation = -2;
        GameObject converseButtonBLab = GameObject.Find("ConverseButtonB");
        Image converseBtnB = converseButtonBLab.GetComponent<Image>();
        GameObject converseButtonBTxtLab = GameObject.Find("ConverseB");
        TMP_Text converseB = converseButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonBLab = GameObject.Find("ClarifyButtonB");
        Image clarifyBtnB = clarifyButtonBLab.GetComponent<Image>();
        GameObject clarifyButtonBTxtLab = GameObject.Find("ClarifyB");
        TMP_Text clarifyB = clarifyButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonBLab = GameObject.Find("GuideButtonB");
        Image guideToBtnB = guideToButtonBLab.GetComponent<Image>();
        GameObject guideToButtonBTxtLab = GameObject.Find("GuideB");
        TMP_Text guideB = guideToButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonBLab = GameObject.Find("SuggestButtonB");
        Image suggestBtnB = suggestButtonBLab.GetComponent<Image>();
        GameObject suggestButtonBTxtLab = GameObject.Find("SuggestB");
        TMP_Text suggestB = suggestButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonBLab = GameObject.Find("CheckoutButtonB");
        Image checkoutBtnB = checkoutButtonBLab.GetComponent<Image>();
        GameObject checkoutButtonBTxtLab = GameObject.Find("CheckoutB");
        TMP_Text checkoutB = checkoutButtonBTxtLab.GetComponent<TMP_Text>();

        GameObject DialogBoxBLab = GameObject.Find("DialogBoxB");
        Image DialogBoxB = DialogBoxBLab.GetComponent<Image>();
        GameObject DialogBLab = GameObject.Find("DialogB");
        TMP_Text DialogB = DialogBLab.GetComponent<TMP_Text>();
        GameObject InfoboxBLab = GameObject.Find("InfoboxB");
        Image InfoboxB = InfoboxBLab.GetComponent<Image>();
        GameObject NameboxBLab = GameObject.Find("NameboxB");
        Image NameboxB = NameboxBLab.GetComponent<Image>();
        GameObject NameBObjLab = GameObject.Find("NameB");
        TMP_Text NameBObj = NameBObjLab.GetComponent<TMP_Text>();
        GameObject WantsBObjLab = GameObject.Find("WantsB");
        TMP_Text WantsBObj = WantsBObjLab.GetComponent<TMP_Text>();
        GameObject BudgetBObjLab = GameObject.Find("BudgetB");
        TMP_Text BudgetBObj = BudgetBObjLab.GetComponent<TMP_Text>();
        GameObject CartValBObjLab = GameObject.Find("CartValB");
        TMP_Text CartValBObj = CartValBObjLab.GetComponent<TMP_Text>();

        DialogBoxB.enabled = true;
        DialogB.enabled = true;
        InfoboxB.enabled = true;
        NameboxB.enabled = true;
        NameBObj.enabled = true;
        WantsBObj.enabled = true;
        BudgetBObj.enabled = true;
        CartValBObj.enabled = true;

        converseBtnB.enabled = true;
        converseB.enabled = true;
        if (!customerBwantRevealed || !customerBbudgetRevealed)
        {
            clarifyBtnB.enabled = true;
            clarifyB.enabled = true;
        }
        guideToBtnB.enabled = true;
        guideB.enabled = true;
        suggestBtnB.enabled = true;
        suggestB.enabled = true;
        checkoutBtnB.enabled = true;
        checkoutB.enabled = true;

        GameObject talkToBLab = GameObject.Find("CustomerB");
        Image talkToB = talkToBLab.GetComponent<Image>();
        talkToB.enabled = true;
        GameObject talkBackBLab = GameObject.Find("TalkBackButtonB");
        Image talkBackB = talkBackBLab.GetComponent<Image>();
        GameObject talkBackBTextLab = GameObject.Find("TalkBackB");
        TMP_Text talkBackBtext = talkBackBTextLab.GetComponent<TMP_Text>();
        talkBackB.enabled = true;
        talkBackBtext.enabled = true;
        talking = true;
        buttonVisibility();
    }

    private void updateDialogB(string val)
    {
        GameObject DialogBLab = GameObject.Find("DialogB");
        TMP_Text DialogB = DialogBLab.GetComponent<TMP_Text>();
        DialogB.text = val;
    }

    public void converseB()
    {
        GameObject NameBObjLab = GameObject.Find("NameB");
        TMP_Text NameBObj = NameBObjLab.GetComponent<TMP_Text>();

        if (!customerBnameRevealed)
        {
            customerBdialog = dRevealName[UnityEngine.Random.Range(0, dRevealName.Length)] + customerBname + ".";
            customerBnameRevealed = true;
            NameBObj.text = customerBname;
        }
        else if (customerBnameRevealed)
        {
            if (customerBagreeability >= 5)
            {
                int topic = UnityEngine.Random.Range(1, 4);
                switch (topic)
                {
                    case 1:
                        customerBdialog = dTalkWeather[UnityEngine.Random.Range(0, dTalkWeather.Length)];
                        customerBagreeability--;
                        customerBopinion++;
                        break;
                    case 2:
                        customerBdialog = dTalkNews[UnityEngine.Random.Range(0, dTalkNews.Length)];
                        customerBagreeability--;
                        customerBopinion++;
                        break;
                    case 3:
                        customerBdialog = dTalkSports[UnityEngine.Random.Range(0, dTalkSports.Length)];
                        customerBagreeability--;
                        customerBopinion++;
                        break;
                    case 4:
                        customerBdialog = dTalkOccasion[UnityEngine.Random.Range(0, dTalkOccasion.Length)];
                        customerBagreeability--;
                        customerBopinion++;
                        break;
                }
            }
            if (customerBagreeability < 5 && customerBagreeability > 1)
            {
                customerBdialog = dTalkAwkward[UnityEngine.Random.Range(0, dTalkAwkward.Length)];
                customerBagreeability--;
            }
            if (customerBagreeability <= 1)
            {
                customerBdialog = dTalkFrustrated[UnityEngine.Random.Range(0, dTalkFrustrated.Length)];
                customerBagreeability--;
                customerBopinion--;
            }
        }
        updateDialogB(customerBdialog);
    }

    public void clarifyB()
    {
        GameObject clarifyButtonBLab = GameObject.Find("ClarifyButtonB");
        Image clarifyBtnB = clarifyButtonBLab.GetComponent<Image>();
        GameObject clarifyButtonBTxtLab = GameObject.Find("ClarifyB");
        TMP_Text clarifyB = clarifyButtonBTxtLab.GetComponent<TMP_Text>();

        GameObject WantsBObjLab = GameObject.Find("WantsB");
        TMP_Text WantsBObj = WantsBObjLab.GetComponent<TMP_Text>();
        GameObject BudgetBObjLab = GameObject.Find("BudgetB");
        TMP_Text BudgetBObj = BudgetBObjLab.GetComponent<TMP_Text>();

        if (!customerBbudgetRevealed)
        {
            customerBbudgetRevealed = true;
            customerBdialog = dRevealBudget[UnityEngine.Random.Range(0, dRevealBudget.Length)] + "$" + customerBbudget + ".";
            updateDialogB(customerBdialog);
            BudgetBObj.text = "Budget: $" + customerBbudget.ToString();
            return;
        }
        if (customerBbudgetRevealed)
        {
            customerBwantRevealed = true;
            switch (wantIsB)
            {
                case "Suits":
                    WantsBObj.text = "Wants: Suits";
                    customerBdialog = dWantSuit[UnityEngine.Random.Range(0, dWantSuit.Length)];
                    break;
                case "Pants":
                    WantsBObj.text = "Wants: Pants";
                    customerBdialog = dWantPant[UnityEngine.Random.Range(0, dWantPant.Length)];
                    break;
                case "Shoes":
                    WantsBObj.text = "Wants: Shoes";
                    customerBdialog = dWantShoes[UnityEngine.Random.Range(0, dWantShoes.Length)];
                    break;
                case "Sales":
                    WantsBObj.text = "Wants: Sales";
                    customerBdialog = dWantSales[UnityEngine.Random.Range(0, dWantSales.Length)];
                    break;
                case "Bathroom":
                    WantsBObj.text = "Wants: Bathroom";
                    customerBdialog = dWantBathroom[UnityEngine.Random.Range(0, dWantBathroom.Length)];
                    break;
            }
            updateDialogB(customerBdialog);
            return;
        }
        if (customerBwantRevealed && customerBbudgetRevealed)
        {
            customerBdialog = dTalkAwkward[UnityEngine.Random.Range(0, dTalkAwkward.Length)];
            clarifyBtnB.enabled = false;
            clarifyB.enabled = false;
        }
    }

    public void guideToB()
    {
        guideBoverride = true;
    }

    public void suggestB()
    {
        GameObject WantsBObjLab = GameObject.Find("WantsB");
        TMP_Text WantsBObj = WantsBObjLab.GetComponent<TMP_Text>();

        GameObject CartValBObjLab = GameObject.Find("CartValB");
        TMP_Text CartValBObj = CartValBObjLab.GetComponent<TMP_Text>();

        guideBoverride = false;
        switch (wantIsB)
        {
            case "Suits":
                if (customerBLocation == 4)
                {
                    if (customerBbudget >= 1500)
                    {
                        customerBdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(600, 1200);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                    else
                    {
                        customerBdialog = dOpenToSuit[UnityEngine.Random.Range(0, dOpenToSuit.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(300, 700);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                }
                break;
            case "Pants":
                if (customerBLocation == 2)
                {
                    if (customerBbudget >= 1500)
                    {
                        customerBdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(220, 500);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                    else
                    {
                        customerBdialog = dOpenToPants[UnityEngine.Random.Range(0, dOpenToPants.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(40, 170);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                }
                break;
            case "Shoes":
                if (customerBLocation == 3)
                {
                    if (customerBbudget >= 1500)
                    {
                        customerBdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(200, 500);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                    else
                    {
                        customerBdialog = dOpenToShoes[UnityEngine.Random.Range(0, dOpenToShoes.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(60, 160);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                }
                break;
            case "Sales":
                if (customerBLocation == 1)
                {
                    if (customerBbudget >= 1500)
                    {
                        customerBdialog = dOpenToTons[UnityEngine.Random.Range(0, dOpenToTons.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(300, 600);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                    else
                    {
                        customerBdialog = dOpenToSales[UnityEngine.Random.Range(0, dOpenToSales.Length)];
                        updateDialogB(customerBdialog);
                        float priceraw = UnityEngine.Random.Range(5, 300);
                        float price = Mathf.Round(priceraw * 100.0f) * 0.01f;
                        customerBcart += price;
                        currentItems++;
                        CartValBObj.text = "Cart: $" + customerBcart;
                        wantIsB = " ";
                    }
                }
                break;
            case " ":
                if (customerBpatience >= 5)
                {
                    int r = UnityEngine.Random.Range(1, 4);
                    switch (r)
                    {
                        case 1:
                            customerBdialog = dOpenToSuit[UnityEngine.Random.Range(0, dOpenToSuit.Length)];
                            updateDialogB(customerBdialog);
                            wantIsB = "Suits";
                            WantsBObj.text = "Wants: Suits";
                            break;
                        case 2:
                            customerBdialog = dOpenToPants[UnityEngine.Random.Range(0, dOpenToPants.Length)];
                            updateDialogB(customerBdialog);
                            wantIsB = "Pants";
                            WantsBObj.text = "Wants: Pants";
                            break;
                        case 3:
                            customerBdialog = dOpenToShoes[UnityEngine.Random.Range(0, dOpenToShoes.Length)];
                            updateDialogB(customerBdialog);
                            wantIsB = "Shoes";
                            WantsBObj.text = "Wants: Shoes";
                            break;
                        case 4:
                            customerBdialog = dOpenToSales[UnityEngine.Random.Range(0, dOpenToSales.Length)];
                            updateDialogB(customerBdialog);
                            wantIsB = "Sales";
                            WantsBObj.text = "Wants: Sales";
                            break;
                    }
                    customerBpatience--;
                }
                else
                {
                    customerBdialog = dOpenToNone[UnityEngine.Random.Range(0, dOpenToNone.Length)];
                    updateDialogB(customerBdialog);
                    customerBshoppingOver = true;
                }
                break;
        }
    }

    public void checkoutB()
    {

        // SURVEY
        int b = 0;
        int s = 0;
        int pr = 0;
        int o = 0;
        if (bathroomDirty)
        {
            b = 0;
        }
        else
        {
            b = 1;
        }
        if (newStockArrived)
        {
            s = 0;
        }
        else
        {
            s = 1;
        }
        if (customerBcart <= customerBbudget)
        {
            pr = 3;
        }
        else if (customerBcart >= customerBbudget * 1.1 && customerBcart < customerBbudget * 1.25)
        {
            pr = 2;
        }
        else if (customerBcart >= customerBbudget * 1.25 && customerBcart < customerBbudget * 1.5)
        {
            pr = 1;
        }
        else if (customerBcart >= customerBbudget * 1.5)
        {
            pr = 0;
        }
        o = (int)customerBopinion / 2;
        int surveyScore = b + s + pr + o;
        int r = UnityEngine.Random.Range(0, 10);
        if (surveyScore < 6)
        {
            if (r > 5)
            {
                surveyResponses += 1;
                surveyScoreTotal += surveyScore;
                surveyScoreAvg = surveyScoreTotal / surveyResponses;
                switch (surveyScore)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        surveyNPSm1++;
                        break;
                    case 7:
                    case 8:
                        surveyNPS0++;
                        break;
                    case 9:
                        surveyNPS9++;
                        break;
                    case 10:
                        surveyNPS10++;
                        break;
                }
                calculateNPS();
            }
        }
        else
        {
            if (r > 8)
            {
                surveyResponses += 1;
                surveyScoreTotal += surveyScore;
                surveyScoreAvg = surveyScoreTotal / surveyResponses;
                switch (surveyScore)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        surveyNPSm1++;
                        break;
                    case 7:
                    case 8:
                        surveyNPS0++;
                        break;
                    case 9:
                        surveyNPS9++;
                        break;
                    case 10:
                        surveyNPS10++;
                        break;
                }
                calculateNPS();

            }
        }


        if (customerBpatience > 1 && customerBagreeability > 1)
        {
            salesDaily += customerBcart;
        //    salesWTD += salesDaily;
            numOfSales += 1;
            totalItems += currentItems;
            customerBdialog = dEndSaleHappy[UnityEngine.Random.Range(0, dEndSaleHappy.Length)];
            customerBcheckedOut = true;
        }
        else
        {
            customerBdialog = dEndSaleBad[UnityEngine.Random.Range(0, dEndSaleBad.Length)];
            customerBcheckedOut = true;
        }
        updateDialogB(customerBdialog);

    }

    private void resetCustomerB()
    {
        GameObject NameBObjLab = GameObject.Find("NameB");
        TMP_Text NameBObj = NameBObjLab.GetComponent<TMP_Text>();
        GameObject WantsBObjLab = GameObject.Find("WantsB");
        TMP_Text WantsBObj = WantsBObjLab.GetComponent<TMP_Text>();
        GameObject BudgetBObjLab = GameObject.Find("BudgetB");
        TMP_Text BudgetBObj = BudgetBObjLab.GetComponent<TMP_Text>();
        GameObject CartValBObjLab = GameObject.Find("CartValB");
        TMP_Text CartValBObj = CartValBObjLab.GetComponent<TMP_Text>();

        customerBpatience = 0;
        customerBagreeability = 0;
        customerBopinion = 0;
        customerBbudget = 0;
        customerBbudgetRevealed = false;
        wantIsB = "";
        customerBwantRevealed = false;
        customerBname = "";
        customerBnameRevealed = false;
        customerBcart = 0;
        customerBdialog = "hello i am customer would like purchase many thing.";
        NameBObj.text = "???";
        WantsBObj.text = "Wants: ???";
        BudgetBObj.text = "Budget: ???";
        CartValBObj.text = "Cart: 0$";
        updateDialogB(customerBdialog);
        customerBshoppingOver = false;
        customerBSpawned = false;
        customerBLocation = -1;
        customerBcheckedOut = false;
        setLocation();
    }

    public void guideToSuitsB()
    {
        dayLength -= 5;
        customerBLocation = 4;
        exitTalk();
        currentLocation = 4;
        setLocation();
    }

    public void guideToPantsB()
    {
        dayLength -= 5;
        customerBLocation = 2;
        exitTalk();
        currentLocation = 2;
        setLocation();
        specialLocation = "Changing";
        setSpecial();
    }

    public void guideToShoesB()
    {
        dayLength -= 5;
        customerBLocation = 3;
        exitTalk();
        currentLocation = 3;
        setLocation();
    }

    public void guideToSalesB()
    {
        dayLength -= 5;
        customerBLocation = 1;
        exitTalk();
        currentLocation = 1;
        setLocation();
    }

    public void guideToBathB()
    {
        GameObject specialButtonLab = GameObject.Find("SpecialButton");
        GameObject specialBtnLab = GameObject.Find("Special");
        Image specialButton = specialButtonLab.GetComponent<Image>();
        TMP_Text specialBtn = specialBtnLab.GetComponent<TMP_Text>();
        dayLength -= 5;
        customerBLocation = -6;
        exitTalk();
        currentLocation = 5;
        setLocation();
        specialButton.enabled = false;
        specialBtn.enabled = false;
        bathroomInUse = true;
        customerBbathroomTime = bathroomTime;
        bathroomUser = "B";
    }

    private void calculateNPS()
    {
        int sumScore = surveyNPSm1 * -1 + surveyNPS0 * 0 + surveyNPS9 * 9 + surveyNPS10 * 10;
        netPromoterScore = sumScore / surveyResponses;
    }

    public void exitTalk()
    {
        currentLocation = storedLocation;

        GameObject converseButtonALab = GameObject.Find("ConverseButtonA");
        Image converseBtnA = converseButtonALab.GetComponent<Image>();
        GameObject converseButtonATxtLab = GameObject.Find("ConverseA");
        TMP_Text converseA = converseButtonATxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonALab = GameObject.Find("ClarifyButtonA");
        Image clarifyBtnA = clarifyButtonALab.GetComponent<Image>();
        GameObject clarifyButtonATxtLab = GameObject.Find("ClarifyA");
        TMP_Text clarifyA = clarifyButtonATxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonALab = GameObject.Find("GuideButtonA");
        Image guideToBtnA = guideToButtonALab.GetComponent<Image>();
        GameObject guideToButtonATxtLab = GameObject.Find("GuideA");
        TMP_Text guideA = guideToButtonATxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonALab = GameObject.Find("SuggestButtonA");
        Image suggestBtnA = suggestButtonALab.GetComponent<Image>();
        GameObject suggestButtonATxtLab = GameObject.Find("SuggestA");
        TMP_Text suggestA = suggestButtonATxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonALab = GameObject.Find("CheckoutButtonA");
        Image checkoutBtnA = checkoutButtonALab.GetComponent<Image>();
        GameObject checkoutButtonATxtLab = GameObject.Find("CheckoutA");
        TMP_Text checkoutA = checkoutButtonATxtLab.GetComponent<TMP_Text>();

        converseBtnA.enabled = false;
        converseA.enabled = false;
        clarifyBtnA.enabled = false;
        clarifyA.enabled = false;
        guideToBtnA.enabled = false;
        guideA.enabled = false;
        suggestBtnA.enabled = false;
        suggestA.enabled = false;
        checkoutBtnA.enabled = false;
        checkoutA.enabled = false;

        GameObject converseButtonBLab = GameObject.Find("ConverseButtonB");
        Image converseBtnB = converseButtonBLab.GetComponent<Image>();
        GameObject converseButtonBTxtLab = GameObject.Find("ConverseB");
        TMP_Text converseB = converseButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject clarifyButtonBLab = GameObject.Find("ClarifyButtonB");
        Image clarifyBtnB = clarifyButtonBLab.GetComponent<Image>();
        GameObject clarifyButtonBTxtLab = GameObject.Find("ClarifyB");
        TMP_Text clarifyB = clarifyButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject guideToButtonBLab = GameObject.Find("GuideButtonB");
        Image guideToBtnB = guideToButtonBLab.GetComponent<Image>();
        GameObject guideToButtonBTxtLab = GameObject.Find("GuideB");
        TMP_Text guideB = guideToButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject suggestButtonBLab = GameObject.Find("SuggestButtonB");
        Image suggestBtnB = suggestButtonBLab.GetComponent<Image>();
        GameObject suggestButtonBTxtLab = GameObject.Find("SuggestB");
        TMP_Text suggestB = suggestButtonBTxtLab.GetComponent<TMP_Text>();
        GameObject checkoutButtonBLab = GameObject.Find("CheckoutButtonB");
        Image checkoutBtnB = checkoutButtonBLab.GetComponent<Image>();
        GameObject checkoutButtonBTxtLab = GameObject.Find("CheckoutB");
        TMP_Text checkoutB = checkoutButtonBTxtLab.GetComponent<TMP_Text>();

        converseBtnB.enabled = false;
        converseB.enabled = false;
        clarifyBtnB.enabled = false;
        clarifyB.enabled = false;
        guideToBtnB.enabled = false;
        guideB.enabled = false;
        suggestBtnB.enabled = false;
        suggestB.enabled = false;
        checkoutBtnB.enabled = false;
        checkoutB.enabled = false;

        // talk to A
        GameObject talkToALab = GameObject.Find("CustomerA");
        Image talkToA = talkToALab.GetComponent<Image>();
        talkToA.enabled = false;
        GameObject talkToBLab = GameObject.Find("CustomerB");
        Image talkToB = talkToBLab.GetComponent<Image>();
        talkToB.enabled = false;
        GameObject talkBackALab = GameObject.Find("TalkBackButtonA");
        Image talkBackA = talkBackALab.GetComponent<Image>();
        GameObject talkBackATextLab = GameObject.Find("TalkBackA");
        TMP_Text talkBackAtext = talkBackATextLab.GetComponent<TMP_Text>();
        talkBackA.enabled = false;
        talkBackAtext.enabled = false;

        GameObject DialogBoxALab = GameObject.Find("DialogBoxA");
        Image DialogBoxA = DialogBoxALab.GetComponent<Image>();
        GameObject DialogALab = GameObject.Find("DialogA");
        TMP_Text DialogA = DialogALab.GetComponent<TMP_Text>();
        GameObject InfoboxALab = GameObject.Find("InfoboxA");
        Image InfoboxA = InfoboxALab.GetComponent<Image>();
        GameObject NameboxALab = GameObject.Find("NameboxA");
        Image NameboxA = NameboxALab.GetComponent<Image>();
        GameObject NameAObjLab = GameObject.Find("NameA");
        TMP_Text NameAObj = NameAObjLab.GetComponent<TMP_Text>();
        GameObject WantsAObjLab = GameObject.Find("WantsA");
        TMP_Text WantsAObj = WantsAObjLab.GetComponent<TMP_Text>();
        GameObject BudgetAObjLab = GameObject.Find("BudgetA");
        TMP_Text BudgetAObj = BudgetAObjLab.GetComponent<TMP_Text>();
        GameObject CartValAObjLab = GameObject.Find("CartValA");
        TMP_Text CartValAObj = CartValAObjLab.GetComponent<TMP_Text>();

        DialogBoxA.enabled = false;
        DialogA.enabled = false;
        InfoboxA.enabled = false;
        NameboxA.enabled = false;
        NameAObj.enabled = false;
        WantsAObj.enabled = false;
        BudgetAObj.enabled = false;
        CartValAObj.enabled = false;

        // talk to B
        GameObject talkBackBLab = GameObject.Find("TalkBackButtonB");
        Image talkBackB = talkBackBLab.GetComponent<Image>();
        GameObject talkBackBTextLab = GameObject.Find("TalkBackB");
        TMP_Text talkBackBtext = talkBackBTextLab.GetComponent<TMP_Text>();
        talkBackB.enabled = false;
        talkBackBtext.enabled = false;

        GameObject DialogBoxBLab = GameObject.Find("DialogBoxB");
        Image DialogBoxB = DialogBoxBLab.GetComponent<Image>();
        GameObject DialogBLab = GameObject.Find("DialogB");
        TMP_Text DialogB = DialogBLab.GetComponent<TMP_Text>();
        GameObject InfoboxBLab = GameObject.Find("InfoboxB");
        Image InfoboxB = InfoboxBLab.GetComponent<Image>();
        GameObject NameboxBLab = GameObject.Find("NameboxB");
        Image NameboxB = NameboxBLab.GetComponent<Image>();
        GameObject NameBObjLab = GameObject.Find("NameB");
        TMP_Text NameBObj = NameBObjLab.GetComponent<TMP_Text>();
        GameObject WantsBObjLab = GameObject.Find("WantsB");
        TMP_Text WantsBObj = WantsBObjLab.GetComponent<TMP_Text>();
        GameObject BudgetBObjLab = GameObject.Find("BudgetB");
        TMP_Text BudgetBObj = BudgetBObjLab.GetComponent<TMP_Text>();
        GameObject CartValBObjLab = GameObject.Find("CartValB");
        TMP_Text CartValBObj = CartValBObjLab.GetComponent<TMP_Text>();

        DialogBoxB.enabled = false;
        DialogB.enabled = false;
        InfoboxB.enabled = false;
        NameboxB.enabled = false;
        NameBObj.enabled = false;
        WantsBObj.enabled = false;
        BudgetBObj.enabled = false;
        CartValBObj.enabled = false;

        if (customerAcheckedOut)
        {
            resetCustomerA();
        }


        if (customerBcheckedOut)
        {
            resetCustomerB();
        }

        talking = false;
        guideAoverride = false;
        guideBoverride = false;
        buttonVisibility();
    }

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
        GameObject talkALab = GameObject.Find("TalkButtonA");
        GameObject talkAtextLab = GameObject.Find("TalkA");
        GameObject talkBLab = GameObject.Find("TalkButtonB");
        GameObject talkBtextLab = GameObject.Find("TalkB");

        Image leftButton = leftButtonLab.GetComponent<Image>();
        TMP_Text left = leftBtnLab.GetComponent<TMP_Text>();
        Image backButton = backButtonLab.GetComponent<Image>();
        TMP_Text back = backBtnLab.GetComponent<TMP_Text>();
        Image specialButton = specialButtonLab.GetComponent<Image>();
        TMP_Text special = specialBtnLab.GetComponent<TMP_Text>();
        Image rightButton = rightButtonLab.GetComponent<Image>();
        TMP_Text right = rightBtnLab.GetComponent<TMP_Text>();
        Image talkbuttonA = talkALab.GetComponent<Image>();
        TMP_Text talkA = talkAtextLab.GetComponent<TMP_Text>();
        Image talkbuttonB = talkBLab.GetComponent<Image>();
        TMP_Text talkB = talkBtextLab.GetComponent<TMP_Text>();

        switch (currentLocation)
        {
            case -2:
                leftButton.enabled = false;
                left.enabled = false;
                backButton.enabled = false;
                back.enabled = false;
                specialButton.enabled = false;
                special.enabled = false;
                rightButton.enabled = false;
                right.enabled = false;
                break;
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
                if (!bathroomInUse)
                {
                    specialButton.enabled = true;
                    special.enabled = true;
                }
                else
                {
                    specialButton.enabled = false;
                    special.enabled = false;
                }
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

        if(currentLocation == customerALocation)
        {
            talkA.enabled = true;
            talkbuttonA.enabled = true;
        }
        else
        {
            talkA.enabled = false;
            talkbuttonA.enabled = false;
        }
        if(currentLocation == customerBLocation)
        {
            talkB.enabled = true;
            talkbuttonB.enabled = true;
        }
        else
        {
            talkB.enabled = false;
            talkbuttonB.enabled = false;
        }


    }

    public void cleanBathroom()
    {
        bathroomDirty = false;
        dayLength = dayLength - 20;
        setLocation();
    }

    public void receiveStock()
    {
        newStockArrived = false;
        dayLength = dayLength - 20;
        setLocation();
    }
    public void quitToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void newDay()
    {
        GameObject dayTextLabel = GameObject.Find("DayText");
        TMP_Text dayText = dayTextLabel.GetComponent<TMP_Text>();

        TMP_Text specialLab = specialLabel.GetComponent<TMP_Text>();

        if(dayNumber == 7)
        {
            SceneManager.LoadScene(endScene);
        }

        dailyDPT = 0;
        totalItems = 0;
        salesDaily = 0;
        numOfSales = 0;
        currentLocation = 0;
        dayEnded = false;
        dayLength = 100;
        newCustomerCheck = 5;
        busyworkEventCheck = 20;
        setLocation();
        dayNumber++;
        dayText.text = "DAY " + dayNumber;
        specialLab.text = "Office";
        isMusicPlaying = false;
        dayEndMusicPlaying = false;
    }
}