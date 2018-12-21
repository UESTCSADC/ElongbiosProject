using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Button : MonoBehaviour {


	GameManager gameManager;
	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponentInChildren<GameManager> ();
	
	}
	public void Hide(){
		GameObject.Find ("Textm").GetComponentInChildren<Text> ().text = "";
	}


	public void  CourageArm1(){
        gameManager.courageArm1 = PlayerPrefs.GetInt("courageArm1");
        //gameManager.courageArm2 = PlayerPrefs.GetInt("courageArm2");
        gameManager.courageArm = PlayerPrefs.GetInt("courageArm");
        if (gameManager.shi >= 2)
        {
            if (gameManager.courageArm1 == 0)
            {
                gameManager.shi -= 2;
            }
              gameManager.courageArm = 1;
              gameManager.courageArm1 = 1;
          
            PlayerPrefs.SetInt("courageArm1", gameManager.courageArm1);
            PlayerPrefs.SetInt("shi", gameManager.shi);
            PlayerPrefs.SetInt("courageArm", gameManager.courageArm);
        }
        else {
            GameObject.Find("Textm").GetComponentInChildren<Text>().text = "材料不足";
        }

    }


    public void CourageArm2() {
        //gameManager.courageArm1 = PlayerPrefs.GetInt("courageArm1");
        gameManager.courageArm2 = PlayerPrefs.GetInt("courageArm2");
        gameManager.courageArm = PlayerPrefs.GetInt("courageArm");
        // if (gameManager.shi >= 2)
        //  {

        gameManager.courageArm = 2;
        gameManager.courageArm2 = 1;
            //}  
            PlayerPrefs.SetInt("courageArm2", gameManager.courageArm2);
           // PlayerPrefs.SetInt("shi", gameManager.shi);
            PlayerPrefs.SetInt("courageArm", gameManager.courageArm);
       // }

    }


	public void IntelligenceArm1(){
        gameManager.intelligenceArm1 = PlayerPrefs.GetInt("intelligenceArm1");
        gameManager.intelligenceArm2 = PlayerPrefs.GetInt("intelligenceArm2");
        gameManager.intelligenceArm = PlayerPrefs.GetInt("intelligenceArm");
        if (gameManager.quan  >= 2) {
            if (gameManager.intelligenceArm1 == 0)
            {
                gameManager.quan -= 2;
            }
               gameManager.intelligenceArm = 1;
               gameManager.intelligenceArm1 = 1;
          
            PlayerPrefs.SetInt("intelligenceArm1", gameManager.intelligenceArm1);
            PlayerPrefs.SetInt("quan", gameManager.quan);
            PlayerPrefs.SetInt("intelligenceArm", gameManager.intelligenceArm);
        }
   else {
			GameObject.Find ("Textm").GetComponentInChildren<Text> ().text = "材料不足";
		}
   }



	public void IntelligenceArm2(){
        gameManager.intelligenceArm1 = PlayerPrefs.GetInt("intelligenceArm1");
        gameManager.intelligenceArm2 = PlayerPrefs.GetInt("intelligenceArm2");
        gameManager.intelligenceArm = PlayerPrefs.GetInt("intelligenceArm");
       // if (gameManager.intelligenceArm1 == 0 && gameManager.intelligenceArm2 == 0)
      //  {
            gameManager.intelligenceArm = 2;
            gameManager.intelligenceArm2 = 1;
            //gameManager.quan -= 2;
         
       // }
        PlayerPrefs.SetInt("intelligenceArm2", gameManager.intelligenceArm2);
        PlayerPrefs.SetInt("intelligenceArm", gameManager.intelligenceArm);
    }



    public void WishesArm1() {
        gameManager.wishesArm1 = PlayerPrefs.GetInt("wishesArm1");
        gameManager.wishesArm2 = PlayerPrefs.GetInt("wishesArm2");
        gameManager.wishesArm = PlayerPrefs.GetInt("wishesArm");
        if (gameManager.pao >= 2)                                    //nnnnnnnnnnnnnnnnnnnnnnnew
        {
            if (gameManager.wishesArm1 == 0)
            {
                gameManager.pao -= 2;
            }
                gameManager.wishesArm = 1;
                gameManager.wishesArm1 = 1;
            PlayerPrefs.SetInt("wishesArm1", gameManager.wishesArm1);
            PlayerPrefs.SetInt("pao", gameManager.pao);
            PlayerPrefs.SetInt("wishesArm", gameManager.wishesArm);
        }
        else
        {
            GameObject.Find("Textm").GetComponentInChildren<Text>().text = "材料不足";
        }
             
	}

	public void WishesArm2()
    {
        gameManager.wishesArm1 = PlayerPrefs.GetInt("wishesArm1");
        gameManager.wishesArm2 = PlayerPrefs.GetInt("wishesArm2");
        gameManager.wishesArm = PlayerPrefs.GetInt("wishesArm");
       // if (gameManager. >= 2)                                    //nnnnnnnnnnnnnnnnnnnnnnnew
       // {
            
                gameManager.wishesArm = 2;
                gameManager.wishesArm2 = 1;
             
        PlayerPrefs.SetInt("wishesArm2", gameManager.wishesArm2);
        PlayerPrefs.SetInt("wishesArm", gameManager.wishesArm);
        // }
        /*else
        {
            GameObject.Find("Textm").GetComponentInChildren<Text>().text = "材料不足";
        }*/

    }




    // Update is called once per frame
    void Update () {
	
	}
}
