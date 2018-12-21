using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class terrar1: MonoBehaviour
{
    //public Elongbios player;
    public GameObject righthandbreak;
    public GameObject headbreak;
    public GameObject chestbreak;
    public GameObject knee1break;
    public GameObject knee2break;
	public GameObject elongbiosattack;
	public GameObject Stone;
	public GameObject Contribution;
	public GameObject FireBall;
	public GameObject Dust;
	public GameObject groundgo;
	public GameObject groundattack;
	public GameObject DamegeM;
	public GameObject DamageS;
	public GameObject DamageB;
    public GameObject teach;
    public GameObject pic1;
    public GameObject pic2;
    public GameObject touchhead;
    public GameObject touchhand;
    public GameObject touchchest;
    public GameObject touchknee1;
    public GameObject touchknee2;

    private float speed = -500.0f; 

    public terrar1 monster;
	public float monsterHP;
    public int alpha;
    public float A;
	public bool monsterhited;
    public bool triger;

    public bool handyon;
    public bool chestyon;
    public bool knee1yon;
    public bool knee2yon;
    public bool headyon;

	private Animator Monster;
	
	public Vector3 playerPosition;
    public Vector3 monsterPosition;
    public Vector3 oriposition;
	public Vector3 rootposition;
	AnimatorStateInfo info;

    public bool transformchange;
    public bool changed;
    public bool shouldmove;
    public bool asd;
    public bool qwe;
    public float x, y, x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, dis;
    public float handHP;
    public float chestHP;
    public float knee1HP;
    public float knee2HP;
    public float headHP;
	public bool groudgoing = false;
	public Vector3 groundposition;
	public Vector3 groundtarget;
	public int count=0;

	public AudioClip attach2throw,attach4,roar,terrardead,attack3,getstone,walk,wheel,gan,terrarhited;
	AudioSource attach2throwSound,attach4Sound,roarSound,terrardeadSound,attack3Sound,getstoneSound,walkSound,wheelSound,ganSound,terrarhitedSound;

    // Use this for initialization 


    void Start()
	{
        headHP = 200;
        knee2HP = 200;
        knee1HP = 200;
        chestHP = 200;
        handHP = 60;
        asd = true;
        qwe = true;
        headyon = false;
        knee1yon = false;
        knee2yon = false;
        handyon = false;
        chestyon = false;

        transformchange = false;
		changed = false;
		Monster = this.GetComponent<Animator>();
		monsterHP = 5000;
		monsterhited = false;
	    MonsterAttack ();
        Monster.SetBool("dead", false);
        shouldmove = false;
        oriposition = this.transform.Find ("root").localPosition;
		info = Monster.GetCurrentAnimatorStateInfo (0);

		attach2throwSound = gameObject.AddComponent<AudioSource>();
		attach4Sound = gameObject.AddComponent<AudioSource>();
		roarSound= gameObject.AddComponent<AudioSource>();
		terrardeadSound= gameObject.AddComponent<AudioSource>();
		attack3Sound = gameObject.AddComponent<AudioSource> ();
		getstoneSound = gameObject.AddComponent<AudioSource> ();
		walkSound=gameObject.AddComponent<AudioSource> ();
		wheelSound=gameObject.AddComponent<AudioSource> ();
		ganSound=gameObject.AddComponent<AudioSource> ();
		terrarhitedSound = gameObject.AddComponent<AudioSource> ();

		attach2throwSound.clip = attach2throw;
		attach4Sound.clip = attach4;
		roarSound.clip = roar;
		terrardeadSound.clip = terrardead;
		attack3Sound.clip = attack3;
		getstoneSound.clip = getstone;
		walkSound.clip = walk;
		wheelSound.clip = wheel;
		ganSound.clip = gan;
		terrarhitedSound.clip = terrarhited;
	}

    // Update is called once per frame
    void Update()
    {
        if (triger == true)
        {
            A += -0.1f;
            alpha += 1;
            GameObject.Find("Main Camera").transform.position = new Vector3(673, 383 + A * Mathf.Sin(alpha % 360), -20);
            if (A <= 0)
            {
                triger = false;
            }
        }
        if (monsterPosition.x + monster.transform.Find("root").position.x < 390 && !Monster.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Dead") && !Monster.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.break"))
        {
            if (GameObject.Find("Elongbios1").GetComponent<Elongbios1>().transform.position != GameObject.Find("Elongbios1").GetComponent<Elongbios1>().PositionA)
            {
                Monster.SetBool("attach1", true);
                Monster.SetBool("back", true);
                this.transform.position = new Vector3(this.transform.position.x + this.transform.Find("root").localPosition.x - oriposition.x, this.transform.position.y, this.transform.position.z);
            }
            else
            {
                Monster.SetBool("run", true);
                this.transform.position = new Vector3(this.transform.position.x + this.transform.Find("root").localPosition.x - oriposition.x, this.transform.position.y, this.transform.position.z);
            }
        }

        if (Monster.GetBool("attach3") == true && GameObject.Find("Elongbios1").GetComponent<Elongbios1>().transform.position == GameObject.Find("Elongbios1").GetComponent<Elongbios1>().PositionB && Monster.GetBool("attach3"))
        {
            Monster.SetBool("attach3", false);
        }

        if (GameObject.Find("Elongbios1").GetComponent<Elongbios1>().terrarhite == true)
        {
            Hited();
        }

        if (shouldmove == true)
        {
            endofanimation();
            shouldmove = false;
        }

        if (groudgoing == true)
        {
            if (count == 15)
            {
                if (groundposition.x - groundtarget.x > 50)
                {
                    groundposition += new Vector3(-50, 0, 0);
                    GameObject groundgo0 = (GameObject)Instantiate(groundgo, groundposition, Quaternion.identity);
                }
                else
                {
                    GameObject groundattack0 = (GameObject)Instantiate(groundattack, groundtarget + new Vector3(0, -41, 0), Quaternion.identity);
                    if (GameObject.Find("checkpoint").transform.position == groundtarget)
                        GameObject.Find("Elongbios1").GetComponent<Elongbios1>().BeAttack(400);
                    groudgoing = false;
                }
                count = 0;
            }
            else
                count += 1;

        }

        if (this.gameObject.transform.position.x < 800)
        {
            Monster.SetBool("attach2", false);
        }
        

        dis = GameObject.Find("Elongbios1").GetComponent<Elongbios1>().AttackRadius + 41;
        x = GameObject.Find("checkpoint").transform.position.x;
        y = GameObject.Find("checkpoint").transform.position.y;
        x1 = GameObject.Find("handpoint").transform.position.x;
        y1 = GameObject.Find("handpoint").transform.position.y;
        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -3 && asd == true)
        {
            teach.SetActive(true);
            GameObject.Find("Text4").GetComponentInChildren<Text>().text = "就是现在！攻击指示器已经接触到了怪物身上的判定点，松开   “space”   ！攻击它！";
            pic1.SetActive(true);
            Time.timeScale = 0;
            asd = false;
        }
        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -3 && qwe == false)
        {
            teach.SetActive(true);
            GameObject.Find("Text4").GetComponentInChildren<Text>().text = "就是现在！攻击指示器已经接触到了怪物身上的判定点，松开  “D”  键！攻击它！";
            pic2.SetActive(true);
            Time.timeScale = 0;
            qwe = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            teach.SetActive(false);
            Time.timeScale = 1;
            qwe = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            teach.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            teach.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            teach.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            teach.SetActive(false);
            pic1.SetActive(false);
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            teach.SetActive(false);
            Time.timeScale = 1;
            pic2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            Application.LoadLevel(1);

        }
    }
    public void talk1()
    {
       
        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "在Elongbios的周围有两个攻击指示器，让我们一直按住  “space” 让攻击指示器的半径增大来攻击它！ ，";
        touchhead.SetActive(false);
        touchhand.SetActive(false);
        touchchest.SetActive(false);
        touchknee1.SetActive(false);
        touchknee2.SetActive(false);
        Time.timeScale = 0;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //teach.SetActive(false);
            //Time.timeScale = 1;
      //  }
    }
    public void talk2()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "怪物要展开攻势了！按 “ 左右 ” 方向键移动位置，避开这次攻击！";
        Time.timeScale = 0;
    }
    public void talk3()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "这次的攻击我们难以躲避，快一直按住 “ A ” 进入防御模式，这样可以减小它对我们的伤害！";
        Time.timeScale = 0;
    }
    public void talk4()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "干得漂亮！你已经懂得了如何战斗，让我们开始冒险吧！                  （按“esc”退出教学） ";
        Time.timeScale = 0;
       
    }
    public void talk5()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "怪物要逃走了！这时我们可以按住“D”键，进入凝神模式，给怪物猛的一击！";
        Time.timeScale = 0;
    }
    public void talk6()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "这时怪物的手臂被破坏了！           （按 “ A ” 继续）";
        Time.timeScale = 0;
    }
    public void talk7()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "  欢迎来到Elongbios的世界！     左上方的指示器上下分别为生命值和凝神值。生命值为零游戏结束。凝神值用来移动和开启凝神模式（按 “ A ” 继续）";
        Time.timeScale = 0;
    }
    public void talk8()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "因为Elongbios双眼失明，由我来引导她的移动，所以只有在我先到达目标位置后，她才可以移动 （按 “ A ” 继续）";
        Time.timeScale = 0;
    }
    public void talk9()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "怪物来了！在它的身上有5个有效打击点，分别在怪物的头，手臂，胸口和两个膝盖。我们要瞄准它们！ （按 “ A ” 继续）";
        touchhead.SetActive(true);
        touchhand.SetActive(true);
        touchchest.SetActive(true);
        touchknee1.SetActive(true);
        touchknee2.SetActive(true);
        Time.timeScale = 0;
    }
    public void talk10()
    {

        teach.SetActive(true);
        GameObject.Find("Text4").GetComponentInChildren<Text>().text = "在凝神模式下，我们的攻击将对怪物造成更大的伤害，精准度也会大大提高。注意：会消耗凝神值 ！（按 “ A ” 继续）";
        Time.timeScale = 0;
    }

    public void startanimation()
	{
		oriposition = this.transform.Find ("root").localPosition;
	    MonsterAttack ();
	}

	public void MonsterAttack()
	{
		Monster.SetBool("attach1",false);
		Monster.SetBool("attach2",false);
		Monster.SetBool("attach3",false);
		Monster.SetBool("attach4",false);
		Monster.SetBool("back",true);
		Monster.SetBool("break",false);
		Monster.SetBool("return",false);
        Monster.SetBool("walk", true);
        Monster.SetBool("run", false);

        //Monster = this.GetComponent<Animator>();
        if (monsterHP != 0){
			Random Random = new Random();
			int a=Random.Range(0,10);
			switch(a){
			case 1:
			    Monster.SetBool("attach2",true);
                Monster.SetBool("return", true);
                break;
			case 2:
				Monster.SetBool("attach2",true);
                Monster.SetBool("return", true);
                break;
			case 3:
                Monster.SetBool("attach3", true);
                Monster.SetBool("return", true);
                break;
			case 4:
				Monster.SetBool("attach4",true);
                Monster.SetBool("return", true);
                break;
			case 5:
				Monster.SetBool("attach2", true);
                Monster.SetBool("return", true);
                break;
			case 6:
				Monster.SetBool("attach3", true);
                Monster.SetBool("return", true);
                break;
			case 7:
				Monster.SetBool("attach4", true);
                Monster.SetBool("return", true);
                break;
			case 8:
				Monster.SetBool("attach2", true);
                Monster.SetBool("return", true);
                break;
			case 9:
                    Monster.SetBool("walk", true);
                break;
			case 10:
				Monster.SetBool("walk",true);
                 break;
			}
		}else
        {
			Monster.SetBool("break",true);
			Monster.SetBool("dead",true);
		}
		Monster.SetBool("Monsterhited",true);
	}


    public void Hited()
    {
        GameObject.Find("Elongbios1").GetComponent<Elongbios1>().terrarhite = false;
        dis =GameObject.Find("Elongbios1").GetComponent<Elongbios1>().AttackRadius+41;
        x = GameObject.Find("checkpoint").transform.position.x;
        y = GameObject.Find("checkpoint").transform.position.y;
        x1 = GameObject.Find("handpoint").transform.position.x;
        y1 = GameObject.Find("handpoint").transform.position.y;
        x2 = GameObject.Find("headpoint").transform.position.x;
        y2 = GameObject.Find("headpoint").transform.position.y;
        x3 = GameObject.Find("chestpoint").transform.position.x;
        y3 = GameObject.Find("chestpoint").transform.position.y;
        x4 = GameObject.Find("kneepoint1").transform.position.x;
        y4 = GameObject.Find("kneepoint1").transform.position.y;
        x5 = GameObject.Find("kneepoint2").transform.position.x;
        y5 = GameObject.Find("kneepoint2").transform.position.y;

		if (GameObject.Find ("DamegeM(Clone)"))
			GameObject.DestroyImmediate (GameObject.Find("DamegeM(Clone)"));
		if (GameObject.Find ("DamageS(Clone)"))
			GameObject.DestroyImmediate (GameObject.Find("DamageS(Clone)"));
		if (GameObject.Find ("DamageB(Clone)"))
			GameObject.DestroyImmediate (GameObject.Find("DamageB(Clone)"));

		GameObject.Destroy (GameObject.Find("ElongbiosAttack(Clone)"));
		float scalenumber = (GameObject.Find ("Elongbios1").GetComponent<Elongbios1> ().AttackRadius + 41.0f) * 10.2f / 41.0f;
		GameObject elongbiosattack0= (GameObject)Instantiate(elongbiosattack,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
		elongbiosattack0.transform.localScale = new Vector3 (scalenumber, scalenumber, 1);

        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -3)
        {
            monsterHP = monsterHP - 200;
            handHP -= 30;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 10;
            GameObject damegem0 = (GameObject)Instantiate(DamageB, GameObject.Find("handpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("handpoint").transform;
            if (handHP <= 0)
            {
                GameObject.Find("terrar-righthand").SetActive(false);
                righthandbreak.SetActive(true);
                handyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                handHP = 100000;
            }
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= 10 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -10)
        {
            monsterHP = monsterHP - 100;
            handHP -= 20;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 5;
            GameObject damegem0 = (GameObject)Instantiate(DamegeM, GameObject.Find("handpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("handpoint").transform;
            if (handHP <= 0)
            {
                GameObject.Find("terrar-righthand").SetActive(false);
                righthandbreak.SetActive(true);
                handyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                handHP = 100000;
            }
        }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= 20 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -20)
        {
            monsterHP = monsterHP - 20;
            handHP -= 10;
			GameObject damegem0 = (GameObject)Instantiate(DamageS, GameObject.Find("handpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("handpoint").transform;
            if (handHP <= 0)
            {
                GameObject.Find("terrar-righthand").SetActive(false);
                righthandbreak.SetActive(true);
                handyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                handHP = 100000;
            }
        }


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -3)
        {
            monsterHP = monsterHP - 200;
            headHP -= 30;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 10;
			GameObject damegem1 = (GameObject)Instantiate(DamageB,GameObject.Find("headpoint").transform.position,Quaternion.identity);
			//damegem.transform.parent = GameObject.Find("headpoint").transform;
            if (headHP <= 0)
            {
                GameObject.Find("terrar-head").SetActive(false);
                headbreak.SetActive(true);
                headyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                headHP = 100000;
            }
        }else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= 10 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -10)
        {
                monsterHP = monsterHP - 100;
                headHP -= 20;
                GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 5;
                GameObject damegem1 = (GameObject)Instantiate(DamegeM, GameObject.Find("headpoint").transform.position, Quaternion.identity);
                //damegem.transform.parent = GameObject.Find("headpoint").transform;
                if (headHP <= 0)
                {
                    GameObject.Find("terrar-head").SetActive(false);
                    headbreak.SetActive(true);
                    headyon = true;
                    Monster.SetBool("break", true);
                    Monster.SetBool("return", true);
                    headHP = 100000;
                }
            }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= 20 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -20)
        {

            monsterHP = monsterHP - 20;
            headHP -= 10;
			GameObject damegem1 = (GameObject)Instantiate(DamageS, GameObject.Find("headpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("headpoint").transform;
            if (headHP <= 0)
            {
                GameObject.Find("terrar-head").SetActive(false);
                headbreak.SetActive(true);
                headyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                headHP = 100000;
            }
        }


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -3)
        {
            monsterHP = monsterHP - 200;
            chestHP -= 30;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 10;
			GameObject damegem2 = (GameObject)Instantiate(DamageB, GameObject.Find("chestpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("chestpoint").transform;
            if (chestHP <= 0)
            {
                GameObject.Find("terrar-body").SetActive(false);
                chestbreak.SetActive(true);
                chestyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                chestHP = 100000;
            }
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= 10 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -10)
        {
            monsterHP = monsterHP - 100;
            chestHP -= 20;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 5;
            GameObject damegem2 = (GameObject)Instantiate(DamegeM, GameObject.Find("chestpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("chestpoint").transform;
            if (chestHP <= 0)
            {
                GameObject.Find("terrar-body").SetActive(false);
                chestbreak.SetActive(true);
                chestyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                chestHP = 100000;
            }
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= 20 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -20)
        {
            monsterHP = monsterHP - 20;
            chestHP -= 5;
			GameObject damegem2 = (GameObject)Instantiate(DamageS, GameObject.Find("chestpoint").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("chestpoint").transform;
            if (chestHP <= 0)
            {
                GameObject.Find("terrar-body").SetActive(false);
                chestbreak.SetActive(true);
                chestyon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                chestHP = 100000;
            }
        }


        if (Vector3.Distance(new Vector3(x,y,0),new Vector3(x4,y4,0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -3)
        {
            monsterHP = monsterHP - 200;
            knee1HP -= 20;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 10;
			GameObject damegem3 = (GameObject)Instantiate(DamageB,GameObject.Find("kneepoint1").transform.position,Quaternion.identity);
			//damegem.transform.parent = GameObject.Find("kneepoint1").transform;
            if (knee1HP <= 0)
            {
                GameObject.Find("terrar-leftleg").SetActive(false);
                knee1break.SetActive(true);
                knee1yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee1HP = 1000000;
            }
        }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis <= 10 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -10)
        {
            monsterHP = monsterHP - 100;
            knee1HP -= 10;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 5;
            GameObject damegem3 = (GameObject)Instantiate(DamegeM, GameObject.Find("kneepoint1").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("kneepoint1").transform;
            if (knee1HP <= 0)
            {
                GameObject.Find("terrar-leftleg").SetActive(false);
                knee1break.SetActive(true);
                knee1yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee1HP = 1000000;
            }
        }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis <= 20 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -20)
        {
            monsterHP = monsterHP - 20;
            knee1HP -= 5;
			GameObject damegem3 = (GameObject)Instantiate(DamageS, GameObject.Find("kneepoint1").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("kneepoint1").transform;
            if (knee1HP <= 0)
            {
                GameObject.Find("terrar-leftleg").SetActive(false);
                knee1break.SetActive(true);
                knee1yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee1HP = 1000000;
            }
        }


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= 3 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -3)
        {
            monsterHP = monsterHP - 200;
            knee2HP -= 20;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 10;
			GameObject damegem4 = (GameObject)Instantiate(DamageB,GameObject.Find("kneepoint2").transform.position,Quaternion.identity);
			//damegem.transform.parent = GameObject.Find("kneepoint2").transform;
            if (knee2HP <= 0)
            {
                GameObject.Find("terrar-rightleg").SetActive(false);
                knee2break.SetActive(true);
                knee2yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee2HP = 100000;
            }
        }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= 10 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -10)
        {
            monsterHP = monsterHP - 100;
            knee2HP -= 10;
            GameObject.Find("Elongbios1").GetComponent<Elongbios1>().sp += 5;
            GameObject damegem4 = (GameObject)Instantiate(DamegeM, GameObject.Find("kneepoint2").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("kneepoint2").transform;
            if (knee2HP <= 0)
            {
                GameObject.Find("terrar-rightleg").SetActive(false);
                knee2break.SetActive(true);
                knee2yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee2HP = 100000;
            }
        }else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= 20 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -20)
        {
            monsterHP = monsterHP - 20;
            knee2HP -= 5;
            GameObject damegem4 = (GameObject)Instantiate(DamageS, GameObject.Find("kneepoint2").transform.position, Quaternion.identity);
            //damegem.transform.parent = GameObject.Find("kneepoint2").transform;
            if (knee2HP <= 0)
            {
                GameObject.Find("terrar-rightleg").SetActive(false);
                knee2break.SetActive(true);
                knee2yon = true;
                Monster.SetBool("break", true);
                Monster.SetBool("return", true);
                knee2HP = 100000;
            }
        }


        if (monsterHP <= 0)
        {
            Monster.SetBool("dead", true);
        }
        if (Monster.GetBool("dead") == true || Monster.GetBool("break") == true)
            if (!Monster.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.break") && !Monster.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.dead"))
                shouldmove = true;
    }

	public void visible()
	{
		Stone.SetActive (true);
		GameObject.Destroy(GameObject.Find("StoneBreak(Clone)"));
		GameObject Stone0 = (GameObject)Instantiate (Stone, GameObject.Find ("handpoint").transform.position + new Vector3(-20,-40,0), Quaternion.identity);
		Stone0.transform.parent = GameObject.Find ("terrar-righthand").transform;
		Stone0.transform.localScale = new Vector3 (150, 150, 1);
	}
	
	public void shotstone()
	{
		Transform target = GameObject.Find ("checkpoint").transform;
		Transform stone = GameObject.Find ("Stone1(Clone)").transform;
		float arrivetime = (stone.transform.position.x - target.position.x) / speed;
		float deltay = stone.transform.position.y - target.position.y;
		float speedy = (deltay - 1 / 2 * 10 * arrivetime * arrivetime) / arrivetime;
		GameObject.Find ("Stone1(Clone)").transform.parent = GameObject.Find("State").transform;
		GameObject.Find ("Stone1(Clone)").GetComponent<stonecontr1> ().isrotate = true;
		GameObject.Find ("Stone1(Clone)").GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, speedy);
	}

	public void contribution()
	{
		GameObject.Destroy (GameObject.Find ("TrrrarContribute(Clone)"));
		GameObject contribution0 = (GameObject)Instantiate (Contribution, GameObject.Find ("chestpoint").transform.position, Quaternion.identity);
	}

	public void fireattack()
	{
		GameObject.Destroy(GameObject.Find("TerrarDust(clone)"));
		GameObject.Destroy (GameObject.Find ("TerrarFire(Clone)"));
		GameObject dust0 = (GameObject)Instantiate (Dust, GameObject.Find ("chestpoint").transform.position + new Vector3(-100,0,0), Quaternion.identity);
		GameObject fireball0 = (GameObject)Instantiate (FireBall, GameObject.Find ("chestpoint").transform.position, Quaternion.identity);
		fireball0.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-500, 0, 0);
	}

	public void Groundstart()
	{
		groudgoing = true;
		groundposition = GameObject.Find ("terrar-leftfoot").transform.position + new Vector3 (0, -80, 0);
		groundtarget = GameObject.Find ("checkpoint").transform.position;
	}


    public void endofanimation()
	{
		this.transform.position = new Vector3(this.transform.position.x + this.transform.Find("root").localPosition.x - oriposition.x,this.transform.position.y,this.transform.position.z);
	}

    public void shake()
    {
        A = 3;
        alpha = 0;
        triger = true;
    }
    public void Return()
    {
        Application.LoadLevel(1);
    }
	public void playattach2throw()
	{
		attach2throwSound.Play ();
	}
	public void playattach4()
	{
		attach4Sound.Play ();
	}
	public void playroar()
	{
		roarSound.Play ();
	}
	public void playterrardead()
	{
		terrardeadSound.Play ();
	}
	public void playattack3()
	{
		attack3Sound.Play ();
	}
	public void playgetstone()
	{
		getstoneSound.Play ();
	}
	public void playwalk()
	{
		walkSound.Play ();
	}
	public void playwheel()
	{
		wheelSound.Play ();
	}
	public void playgan()
	{
		ganSound.Play ();
	}
	public void playterrarhited()
	{
		terrarhitedSound.Play ();
	}
}