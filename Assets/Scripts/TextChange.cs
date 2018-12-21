using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextChange : MonoBehaviour {
	GameManager gameManeger;
	Text number;
	public int i;
    public GameObject k;
    public int conversation;
    public bool talkend;
	
	// Use this for initialization
	void Start () {
        gameManeger = GameObject.Find("GameManager").GetComponentInChildren<GameManager>();
        conversation = 0;
        talkend = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (i == 1)
        {
            number = GameObject.Find("Text").GetComponentInChildren<Text>();
            number.text = gameManeger.courage.ToString();
        }
        else if (i == 2)
        {
            number = GameObject.Find("Text1").GetComponentInChildren<Text>();
            number.text = gameManeger.intelligence.ToString();
        }
        else if (i == 3)
        {
            number = GameObject.Find("Text2").GetComponentInChildren<Text>();
            number.text = gameManeger.wishes.ToString();
        }
        else if (i == 4)
        {
            number = GameObject.Find("TextNumber").GetComponentInChildren<Text>();
            number.text = gameManeger.number.ToString();
        }
        else if (i == 5)
        {
            number = GameObject.Find("ShiText").GetComponentInChildren<Text>();
            number.text = "已有" + gameManeger.shi.ToString() + "块，每块可转化神息石3块";
        }
        else if (i == 6)
        {
            number = GameObject.Find("QuanText").GetComponentInChildren<Text>();
            number.text = "已有" + gameManeger.quan.ToString() + "块，每块可转化神息石3块";
        }
        else if (i == 7)
        {
            number = GameObject.Find("PaoText").GetComponentInChildren<Text>();
            number.text = "已有" + (gameManeger.pao.ToString()) + "块，每块可转化神息石5块";
        }
        else if (i == 8)
        {                 //nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnew
            talk();
        }
        else if (i == 9)
        {
            GameObject.Find("TextArm1").GetComponentInChildren<Text>().color = Color.grey;
            GameObject.Find("TextArm1").GetComponentInChildren<Text>().text = "泰拉尔的粉碎拳,需要2个泰拉尔之石，已有"+gameManeger.shi+"个";
        }
        else if (i == 10)
        {
            GameObject.Find("TextArm111").GetComponentInChildren<Text>().color = Color.grey;
            GameObject.Find("TextArm111").GetComponentInChildren<Text>().text = "泰拉尔的核，需要2个泰拉尔之拳，已有" + gameManeger.quan + "个";
        }
        else if(i==11)
        {
            GameObject.Find("TextArm1111").GetComponentInChildren<Text>().color = Color.grey;
            GameObject.Find("TextArm1111").GetComponentInChildren<Text>().text = "泰拉尔的凝视，需要2个泰拉尔之炮,已有" + gameManeger.pao + "个";
        }
        else if (i == 12)
        {
            if (gameManeger.courageArm == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已装备";
            else
            {
                if (gameManeger.courageArm1 == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "未获得";
            }
        }
        else if (i == 13)
        {
            if (gameManeger.courageArm == 2) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已装备";
            else
            {
                if (gameManeger.courageArm2 == 1) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "未获得";
            }
        }
        else if (i == 14)
        {
            if (gameManeger.intelligenceArm == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已装备";
            else
            {
                if (gameManeger.intelligenceArm1 == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "未获得";
            }
        }
        else if (i == 15)
        {
            if (gameManeger.intelligenceArm == 2) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已装备";
            else
            {
                if (gameManeger.intelligenceArm2 == 1) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "未获得";
            }
        }
        else if (i == 16)
        {
            if (gameManeger.wishesArm == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已装备";
            else
               {
                if(gameManeger.wishesArm1 == 1) GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm12").GetComponentInChildren<Text>().text = "未获得";
            }
        }
        else if (i == 17)
        {
            if (gameManeger.wishesArm == 2) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已装备";
            else
            {
                if (gameManeger.wishesArm2 == 1) GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "已获得";
                else GameObject.Find("TextArm22").GetComponentInChildren<Text>().text = "未获得";
            }
        }
       
    }

    public void talk()
    {
        int text = GameObject.Find("GameManager").GetComponent<GameManager>().text;
        switch (conversation)
        {
            case (0):
                {
                    switch (text)
                    {
                        case (0):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：那个...鹰先生？"; break;
                        case (1):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Eagle：Elongbios,你在叫我吗？"; break;
                        case (2):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：鹰先生我该怎么称呼你呢？"; break;
                        case (3):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Eagle：我还没有名字，你喜欢叫什么就叫什么吧。"; break;
                        case (4):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：那我就叫你希望吧。"; break;
                        case (5):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Eagle：为什么是希望呢？"; break;
                        case (6):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：因为你给我带来了希望，这曾经是我打算给儿子起的名字，不过他已经不在了..."; break;
                        case (7):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：...没关系，我会帮助你找到你的孩子，谢谢你给我的名字，我很喜欢。"; talkend = true; break;
                        
                        default: break;
                    }
                    break;
                }
            case (1):
                {
                    switch (text)
                    {
                        case (0):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios:之前你在我最绝望的时候出现在我的面前，真是像奇迹一样。"; break;
                        case (1):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：奇迹么...某种程度上确实是个奇迹呢。"; break;
                        case (2):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：你为什么知道我需要帮助呢?...你为什么要帮助我呢，我都不知道该怎么报答你。"; break;
                        case (3):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：总有一天你会明白我帮助你的理由。而且，我想要的东西，你其实已经给我了....."; break;
                        case (4):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：我们还是先考虑怎么找到你的孩子吧，我的事情你不需要考虑太多。"; break;
                        case (5):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：好吧，我知道了...如果有什么我能做到的，请一定要告诉我呀。"; break;
                        case (6):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：我答应你。"; break;
                        case (7): talkend = true; break;
                        default: break;
                    }
                    break;
                }
            case (2):
                {
                    switch (text)
                    {
                        case (0):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：希望，需要我给你做一个架子方便你站着休息吗？那个婴儿床，可能站着不太舒服吧..."; break;
                        case (1):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：没关系，我挺喜欢这里的，给我一种十分熟悉的感觉...。"; break;
                        case (2):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：嗯，要是我的孩子也在就好了...他一定会喜欢你的。"; break;
                        case (3):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：...是啊，我们会找到他的"; break;
                        case (4): talkend = true; break;
                        default: break;
                    }
                    break;
                }
            case (3):
                {
                    switch (text)
                    {
                        case (0):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：希望，我们接下来会遭遇的困难，我真的有办法克服他们吗？"; break;
                        case (1):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：我们需要战胜神的三个使者，分别代表着大地，天空和海洋，他们都有着独特的力量。"; break;
                        case (2):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：首先是大地的使者泰拉尔，他拥有撼动山峦的神力，还能控制地脉的喷发"; break;
                        case (3):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：虽然泰拉尔有很强的力量，不过比较笨拙，看穿他的招数并早点回避的话，不是非常难缠的对手"; break;
                        case (4):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：我知道了，谢谢你告诉我这些。"; break;
                        case (5):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：但愿我们可以一起克服这最初的难关..."; break;
                        case (6): talkend = true; talkend = true; break;
                        default: break;
                    }
                    break;
                }
            default:
                {
                    switch (text)
                    {
                        case (0):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：希望，你想吃东西么，家里还有牛奶"; break;
                        case (1):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = new Color(0.55f, 0.15f, 0.07f);
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "希望：谢谢你，Elongbios，早点休息吧，明天还有艰难的战斗等着我们呢。"; break;
                        case (2):
                            GameObject.Find("Text1").GetComponentInChildren<Text>().color = Color.white;
                            GameObject.Find("Text1").GetComponentInChildren<Text>().text = "Elongbios：嗯，希望明天一切顺利。"; break;
                        case (3): talkend = true; break;
                        default: break;
                    }
                    break;
                }
        }
    }

	}
