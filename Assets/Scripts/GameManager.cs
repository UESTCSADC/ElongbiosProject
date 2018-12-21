using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManager: MonoBehaviour {

	//GameObject k;
	public int courage, intelligence, wishes,number,shi,quan,pao,text,courageArm,intelligenceArm,wishesArm,start;
	int courage1, intelligence1, wishes1,number1,shi1,quan1,pao1;
	Text words;
    public int courageArm1, intelligenceArm1, wishesArm1, courageArm2, intelligenceArm2, wishesArm2;
    public AudioClip tostart;
    AudioSource tostartSound;

    void Start(){
        tostartSound = gameObject.AddComponent<AudioSource>();
        tostartSound.clip = tostart;
        //start = PlayerPrefs.GetInt("start");
        /*if (start == 0)
       {
            //k = GameObject.GetComponentInChildren<Text> ();
            courage = 1;
            intelligence =1;
            wishes = 1;
            number = 0;
            shi = 0;
            quan =0;
            pao = 0;
            courageArm1 = intelligenceArm1 = wishesArm1 = courageArm2 = intelligenceArm2 = wishesArm2 = 0;
            PlayerPrefs.SetInt("text", 0);
            courage1 = courage;
            intelligence1 = intelligence;
            wishes1 = wishes;
            number1 = number;
            shi1 = shi;
            quan1 = quan;
            pao1 = pao;
            start = 1;
            PlayerPrefs.SetInt("start",start);
        }
        else
        {*/
        courage = PlayerPrefs.GetInt("courage");
            intelligence = PlayerPrefs.GetInt("intelligence");
            wishes = PlayerPrefs.GetInt("wishes");
            number = PlayerPrefs.GetInt("number");
            shi =  PlayerPrefs.GetInt ("shi");
            quan = PlayerPrefs.GetInt("quan");
            pao = PlayerPrefs.GetInt("pao");
            courageArm = PlayerPrefs.GetInt("courageArm");
            courageArm1 = PlayerPrefs.GetInt("courageArm1");
            courageArm2=PlayerPrefs.GetInt("courageArm2");
            intelligenceArm = PlayerPrefs.GetInt("intelligenceArm");
            intelligenceArm1 = PlayerPrefs.GetInt("intelligenceArm1");
            intelligenceArm2= PlayerPrefs.GetInt("intelligenceArm2");
            wishesArm = PlayerPrefs.GetInt("wishesArm");
            wishesArm1 =PlayerPrefs.GetInt("wishesArm1");
            wishesArm2=PlayerPrefs.GetInt("wishesArm2"); 
            PlayerPrefs.SetInt("text", 0);
            courage1 = courage;
            intelligence1 = intelligence;
            wishes1 = wishes;
            number1 = number;
            shi1 = shi;
            quan1 = quan;
            pao1 = pao;
       // }

	}
	public void OnStartGame(int sceneToLoad){
        //int sceneToLoad = 1;
        tostartSound.Play();
        tostartSound.volume = 0.5f;
        Application.LoadLevel(sceneToLoad);
	}

	public void AddCourage(GameObject k){
		//GameObject.Find ("TextNumber").GetComponentInChildren<Text> ().text = number.ToString ();
		if ((number-courage-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="神息石数量不足，需"+(courage+1)+"块神息石";
		} else {
			courage += 1;
			number = number - courage;

		}
	}
	public void AddIntelligence(GameObject  k){
	
		if ((number-intelligence-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="神息石数量不足，需"+(intelligence+1)+"块神息石";
		} else {
			intelligence += 1;
			number = number - intelligence;
		}

	}
	public void AddWishes(GameObject k){

		if ((number - wishes-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="神息石数量不足，需"+(wishes+1)+"块神息石";
		} else {
			wishes += 1;
			number=number-wishes;
		}
	}

	public void ShiAddStone(GameObject k){
		if ((shi-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="泰拉尔石数量不足";
		} else {
			number += 3;
			shi=shi-1;
		}
	}
	public void QuanAddStone(GameObject k){
		if ((quan-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="泰拉尔拳数量不足";
		} else {
			number += 3;
			quan =quan -1;
		}
	}
	public void PaoAddStone(GameObject k){
		if ((pao-1) < 0) {
			k.SetActive (true);
			k.GetComponentInChildren<Text>().text="泰拉尔炮数量不足";
		} else {
			number += 5;
			pao=pao-1;
		}
	}

	public void ButtonRefresh(){
		courage = courage1;
		intelligence = intelligence1;
		wishes = wishes1;
		number = number1;
		shi = shi1;
		quan = quan1;
		pao = pao1;
	}

	public void ButtonConfirm(int sceneToLoad){
		courage1 = courage;
		intelligence1 = intelligence;
		wishes1 = wishes;
		number1 = number;shi1 = shi;
		quan1 = quan;
		pao1 = pao;
		PlayerPrefs.SetInt("courage", courage);
		PlayerPrefs.SetInt("intelligence", intelligence);
		PlayerPrefs.SetInt("wishes",wishes);
		PlayerPrefs.SetInt("number",number);
		PlayerPrefs.SetInt("shi",shi);
		PlayerPrefs.SetInt("quan",quan);
		PlayerPrefs.SetInt("pao",pao);
		Application.LoadLevel(sceneToLoad);
	}

	public void CourageArm(GameObject j){//,GameObject k,GameObject  l,GameObject m,GameObject n){
		j.SetActive (true);
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().color=Color.grey;
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().text = "泰拉尔的粉碎拳,需要2个泰拉尔之石，已有"+shi+"个";
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().text = "对部位造成的破坏量增加50%";
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().color=Color.grey;
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().text = "平凡的勇气";
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().text = "对任何判定区造成同样的伤害";
		GameObject.Find ("TextArm22").GetComponentInChildren<Text> ().color=Color.black;
		//GameObject.Find("TextArm22").GetComponentInChildren<Text> ().text = "对任何判定区造成同样的伤害";
	}
	public void IntelligenceArm(GameObject j){//,GameObject k,GameObject  l,GameObject m,GameObject n){
		j.SetActive (true);
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().color=Color.yellow;
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().text = "泰拉尔的核，需要2个泰拉尔之拳，已有"+quan+"个";
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().text = "防御效果提升，但消耗也提升";
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().color=Color.grey;
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().text = "朴素的智慧";
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().text = "凝神模式下所有伤害提升20%";
	}
	public void WishesArm(GameObject j){//,GameObject k,GameObject  l,GameObject m,GameObject n){
		j.SetActive (true);
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().color=new Color(125,125,0);
		//GameObject.Find("TextArm1").GetComponentInChildren<Text> ().text = "泰拉尔的凝视，需要2个泰拉尔之炮,已有"+pao+"个";
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm11").GetComponentInChildren<Text> ().text = "攻击获得凝神值提升20%";
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().color=Color.grey;
		GameObject.Find("TextArm2").GetComponentInChildren<Text> ().text = "不灭的希望";
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().color=Color.black;
		GameObject.Find("TextArm21").GetComponentInChildren<Text> ().text = "凝神模式凝神值消耗减少40%";
	}


    public void Refresh()
    {
        courage = 1;
        intelligence = 1;
        wishes = 1;
        number = 6;
        shi = 0;// PlayerPrefs.GetInt ("shi");
        quan = 0;
        pao = 0;
        courageArm=intelligenceArm =wishesArm= courageArm1 = intelligenceArm1 = wishesArm1 = courageArm2 = intelligenceArm2 = wishesArm2 = 0;
        PlayerPrefs.SetInt("text", 0);
        PlayerPrefs.SetInt("courage", courage);
        PlayerPrefs.SetInt("intelligence", intelligence);
        PlayerPrefs.SetInt("wishes", wishes);
        PlayerPrefs.SetInt("number", number);
        PlayerPrefs.SetInt("shi", shi);
        PlayerPrefs.SetInt("quan", quan);
        PlayerPrefs.SetInt("pao", pao);
        PlayerPrefs.SetInt("courageArm2", courageArm2);
        PlayerPrefs.SetInt("courageArm1", courageArm1);
        // PlayerPrefs.SetInt("shi", gameManager.shi);
        PlayerPrefs.SetInt("courageArm",courageArm);
        PlayerPrefs.SetInt("intelligenceArm2", intelligenceArm2);
        PlayerPrefs.SetInt("intelligenceArm1", intelligenceArm1);
        PlayerPrefs.SetInt("intelligenceArm",  intelligenceArm);
        PlayerPrefs.SetInt("wishesArm2",wishesArm2);
        PlayerPrefs.SetInt("wishesArm1", wishesArm1);
        PlayerPrefs.SetInt("wishesArm", wishesArm);
    }


	public void ShowMessage(GameObject k){
        tostartSound.Play();
        tostartSound.volume = 0.5f;
        k.SetActive (true);
		//message.IsActive ();
	}
	
	public void HideMessage(GameObject k){
	
		k.SetActive (false);
		//message.gameObject.SetActive (false);
		//gameObject.SetActive(false);
	}
	/*
	public void StartGameLabel(int sceneToLoad){
	
		PlayerPrefs.SetInt("courage", 1);
		PlayerPrefs.SetInt("intelligence", 1);
		PlayerPrefs.SetInt("wishes", 1);
		Application.LoadLevel(sceneToLoad);
		//k.SetActive (false);
	}
	*/
	public void TalkButton(GameObject k){
		text = PlayerPrefs.GetInt ("text");
		text = text+1;
		PlayerPrefs.SetInt ("text", text);
        if (GameObject.Find("Text1").GetComponent<TextChange>().talkend == true)
        {
            GameObject.Find("Text1").GetComponent<TextChange>().talkend = false;
            GameObject.Find("Text1").GetComponent<TextChange>().conversation++;
            PlayerPrefs.SetInt("text", 0);
            text = 0;
            k.SetActive(false);
        }
	}

	public void  update(){

	}
}
