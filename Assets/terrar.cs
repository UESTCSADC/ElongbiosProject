using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class terrar: MonoBehaviour
{
    //public Elongbios player;
    //public GameManager gamemanager;
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
    public GameObject all;

	private float speed = -500.0f; 
    public terrar monster;
	public float monsterHP;
    public float rangofs;
    public float rangofm;
    public float rangofb;
    public int alpha;
    public float A;
	public bool monsterhited;
    public bool triger;

    public bool handyon;
    public bool chestyon;
    public bool knee1yon;
    public bool knee2yon;
    public bool headyon;
    public bool end;
	private Animator Monster;
	
	public Vector3 playerPosition;
    public Vector3 monsterPosition;
    public Vector3 oriposition;
	public Vector3 rootposition;
	AnimatorStateInfo info;

    public bool transformchange;
    public bool changed;
    public bool shouldmove;
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
    public int courage, intelligence, wishes, shi, quan, pao,number,courageArm,intelligenceArm,wishesArm;

	public AudioClip attach2throw,attach4,roar,terrardead,attack3,getstone,walk,wheel,gan,terrarhited;
	AudioSource attach2throwSound,attach4Sound,roarSound,terrardeadSound,attack3Sound,getstoneSound,walkSound,wheelSound,ganSound,terrarhitedSound;

    // Use this for initialization 


    void Start()
	{
        headHP = 200;
        knee2HP = 200;
        knee1HP = 200;
        chestHP = 200;
        handHP = 200;

        headyon = false;
        knee1yon = false;
        knee2yon = false;
        handyon = false;
        chestyon = false;
        end = false;
        transformchange = false;
		changed = false;
		Monster = this.GetComponent<Animator>();
		monsterHP = 5000;
		monsterhited = false;
	    MonsterAttack ();
        Monster.SetBool("dead", false);
        shouldmove = false;

 

        courage = PlayerPrefs.GetInt("courage");
        intelligence = PlayerPrefs.GetInt("intelligence");
        wishes = PlayerPrefs.GetInt("wishes");
        number = PlayerPrefs.GetInt("number");

        shi =  PlayerPrefs.GetInt ("shi");
        quan = PlayerPrefs.GetInt("quan");
        pao = PlayerPrefs.GetInt("pao");

        courageArm = PlayerPrefs.GetInt("courageArm");
        intelligenceArm = PlayerPrefs.GetInt("intelligenceArm");
        wishesArm = PlayerPrefs.GetInt("wishesArm");

        if (courageArm == 2)
        {
            rangofs = 0;
            rangofm = 20;
            rangofb = 0;
        }
        else {
            rangofs = 20;
            rangofb = rangofs * 0.15f * (1 + wishes * 0.025f);
            rangofm = rangofs * 0.5f * (1 + wishes * 0.03f);
        }
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
        if (end == true&&Input.anyKeyDown)
        {
            Time.timeScale = 1;
            Application.LoadLevel(1);
        }
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
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().transform.position != GameObject.Find("Elongbios").GetComponent<Elongbios>().PositionA)
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

        if (Monster.GetBool("attach3") == true && GameObject.Find("Elongbios").GetComponent<Elongbios>().transform.position == GameObject.Find("Elongbios").GetComponent<Elongbios>().PositionB&& Monster.GetBool("attach3"))
        {
            Monster.SetBool("attach3", false);
        }

        if (GameObject.Find("Elongbios").GetComponent<Elongbios>().terrarhite == true)
        {
            Hited();
        }

        if (shouldmove == true)
        {
            endofanimation();
            shouldmove = false;
        }

		if (groudgoing == true) {
			if(count == 15)
			{
				if(groundposition.x - groundtarget.x > 50)
				{
					groundposition += new Vector3(-50,0,0); 
					GameObject groundgo0 = (GameObject)Instantiate(groundgo,groundposition,Quaternion.identity);
				}
				else
				{
					GameObject groundattack0 = (GameObject)Instantiate(groundattack,groundtarget + new Vector3(0,-41,0),Quaternion.identity);
                    if(GameObject.Find("checkpoint").transform.position == groundtarget)
					    GameObject.Find ("Elongbios").GetComponent<Elongbios> ().BeAttack (400);
					groudgoing = false;
				}
				count = 0;
			}
			else
				count += 1;

		}

		if(this.gameObject.transform.position.x < 800){
			Monster.SetBool("attach2",false);
		}
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
        GameObject.Find("Elongbios").GetComponent<Elongbios>().terrarhite = false;
        dis =GameObject.Find("Elongbios").GetComponent<Elongbios>().AttackRadius+41;
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
		float scalenumber = (GameObject.Find ("Elongbios").GetComponent<Elongbios> ().AttackRadius + 41.0f) * 10.2f / 41.0f;
		GameObject elongbiosattack0= (GameObject)Instantiate(elongbiosattack,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
		elongbiosattack0.transform.localScale = new Vector3 (scalenumber, scalenumber, 1);

        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= rangofb && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -rangofb)
        {
            monsterHP = monsterHP - 200*(1+courage*0.05f);
            handHP -= 30 * (1 + courage * 0.05f);
            if (courageArm == 1)
            {
                handHP = 0.5f * handHP;
            }
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 200 * (1 + intelligence * 0.05f);
                handHP -= 30 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    handHP = 0.8f * handHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f)*3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 15 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f);
            }
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
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= rangofm && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -rangofm)
        {
            monsterHP = monsterHP - 100*(1 + courage * 0.05f);
            handHP -= 20 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 100 * (1 + intelligence * 0.05f);
                handHP -= 20 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    handHP = 0.8f * handHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 8 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f);
            }
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
        }else if(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis <= rangofs && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - dis >= -rangofs)
        {
            monsterHP = monsterHP - 20 * (1 + courage * 0.05f);
            handHP -= 10 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 20 * (1 + intelligence * 0.05f);
                handHP -= 10 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    handHP = 0.8f * handHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 3 * (1 + intelligence * 0.05f);
            }
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


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= rangofb && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -rangofb)
        {
            monsterHP = monsterHP - 200 * (1 + courage * 0.05f);
            headHP -= 30 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 200 * (1 + intelligence * 0.05f);
                headHP -= 30 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    headHP = 0.8f * headHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 15 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= rangofm && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -rangofm)
        {
            monsterHP = monsterHP - 100 * (1 + courage * 0.05f);
            headHP -= 20 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 100 * (1 + intelligence * 0.05f);
                headHP -= 20 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    headHP = 0.8f * headHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 8 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis <= rangofs && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x2, y2, 0)) - dis >= -rangofs)
        {

            monsterHP = monsterHP - 20 * (1 + courage * 0.05f);
            headHP -= 10 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 20 * (1 + intelligence * 0.05f);
                headHP -= 10 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    headHP = 0.8f * headHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 3 * (1 + intelligence * 0.05f);
            }
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


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= rangofb && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -rangofb)
        {
            monsterHP = monsterHP - 200 * (1 + courage * 0.05f);
            chestHP -= 30 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 200 * (1 + intelligence * 0.05f);
                chestHP -= 30 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    chestHP = 0.8f * chestHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 15 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f);
            }
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
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= rangofm && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -rangofm)
        {
            monsterHP = monsterHP - 100 * (1 + courage * 0.05f);
            chestHP -= 20 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 100 * (1 + intelligence * 0.05f);
                chestHP -= 20 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    chestHP = 0.8f * chestHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 8 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f);
            }
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
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis <= rangofs && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x3, y3, 0)) - dis >= -rangofs)
        {
            monsterHP = monsterHP - 20 * (1 + courage * 0.05f);
            chestHP -= 5 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 20 * (1 + intelligence * 0.05f);
                chestHP -= 5 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    chestHP = 0.8f * chestHP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 3 * (1 + intelligence * 0.05f);
            }
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


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis <= rangofb && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -rangofb)
        {
            monsterHP = monsterHP - 200 * (1 + courage * 0.05f);
            knee1HP -= 20 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 200 * (1 + intelligence * 0.05f);
                knee1HP -= 20 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee1HP = 0.8f * knee1HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 15 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis <= rangofm && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -rangofm)
        {
            monsterHP = monsterHP - 100 * (1 + courage * 0.05f);
            knee1HP -= 10 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 100 * (1 + intelligence * 0.05f);
                knee1HP -= 10 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee1HP = 0.8f * knee1HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 8 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis <= rangofs && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x4, y4, 0)) - dis >= -rangofs)
        {
            monsterHP = monsterHP - 20 * (1 + courage * 0.05f);
            knee1HP -= 5 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 20 * (1 + intelligence * 0.05f);
                knee1HP -= 5 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee1HP = 0.8f * knee1HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 3 * (1 + intelligence * 0.05f);
            }
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


        if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= rangofb && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -rangofb)
        {
            monsterHP = monsterHP - 200 * (1 + courage * 0.05f);
            knee2HP -= 20 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 200 * (1 + intelligence * 0.05f);
                knee2HP -= 20 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee2HP = 0.8f * knee2HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 15 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 10 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= rangofm && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -rangofm)
        {
            monsterHP = monsterHP - 100 * (1 + courage * 0.05f);
            knee2HP -= 10 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 100 * (1 + intelligence * 0.05f);
                knee2HP -= 10 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee2HP = 0.8f * knee2HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f) * 3;
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 8 * (1 + intelligence * 0.05f);
            }
            else {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 5 * (1 + intelligence * 0.05f);
            }
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
        }
        else if (Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis <= rangofs && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x5, y5, 0)) - dis >= -rangofs)
        {
            monsterHP = monsterHP - 20 * (1 + courage * 0.05f);
            knee2HP -= 5 * (1 + courage * 0.05f);
            if (GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus)
            {
                monsterHP = monsterHP - 20 * (1 + intelligence * 0.05f);
                knee2HP -= 5 * (1 + intelligence * 0.05f);
                if (intelligenceArm == 2)
                {
                    monsterHP = 0.8f * monsterHP;
                    knee2HP = 0.8f * knee2HP;
                }
                GameObject.Find("Elongbios").GetComponent<Elongbios>().checkfocus = false;
            }
            if (wishesArm == 1)
            {
                GameObject.Find("Elongbios").GetComponent<Elongbios>().sp += 3 * (1 + intelligence * 0.05f);
            }
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
            if (headyon)
            {
                shi += 1;
                number += 3;
            }
            if (handyon)
            {
                number += 3;
                quan += 1;
            }
            if (chestyon)
            {
                pao += 1;
                number += 3;
            }
            if (knee1yon)
            {
                number += 5;
            }
            if (knee2yon)
            {
                number += 5;
            }
            PlayerPrefs.SetInt("courage", courage);
            PlayerPrefs.SetInt("intelligence", intelligence);
            PlayerPrefs.SetInt("wishes", wishes);
            PlayerPrefs.SetInt("number", number);
            PlayerPrefs.SetInt("shi", shi);
            PlayerPrefs.SetInt("quan", quan);
            PlayerPrefs.SetInt("pao", pao);
            PlayerPrefs.SetInt("wishesArm", wishesArm);
            PlayerPrefs.SetInt("courageArm", courageArm);
            PlayerPrefs.SetInt("intelligenceArm", intelligenceArm);
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
		Transform stone = GameObject.Find ("Stone(Clone)").transform;
		float arrivetime = (stone.transform.position.x - target.position.x) / speed;
		float deltay = stone.transform.position.y - target.position.y;
		float speedy = (deltay - 1 / 2 * 10 * arrivetime * arrivetime) / arrivetime;
		GameObject.Find ("Stone(Clone)").transform.parent = GameObject.Find("State").transform;
		GameObject.Find ("Stone(Clone)").GetComponent<stonecontr> ().isrotate = true;
		GameObject.Find ("Stone(Clone)").GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, speedy);
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
        Time.timeScale = 0;
        all.SetActive(true); 
        GameObject.Find("TextAll1").GetComponentInChildren<Text>().color = Color.black;
        GameObject.Find("TextAll2").GetComponentInChildren<Text>().color = Color.black;
        GameObject.Find("TextAll3").GetComponentInChildren<Text>().color = Color.black;
        GameObject.Find("TextAll4").GetComponentInChildren<Text>().color = Color.black;
        GameObject.Find("TextAll5").GetComponentInChildren<Text>().color = Color.black;
        if (headyon)
        {
            GameObject.Find("TextAll1").GetComponentInChildren<Text>().text = "破坏头部，获得泰拉尔的石头1个，神息石3个";
        }
        else if (!headyon)
        {
            GameObject.Find("TextAll1").GetComponentInChildren<Text>().text = "头部未被破坏";
        }
        if (handyon)
        {
            GameObject.Find("TextAll2").GetComponentInChildren<Text>().text = "破坏手部，获得泰拉尔的钢拳1个，神息石3个";
        }
        else if (!handyon)
        {
            GameObject.Find("TextAll2").GetComponentInChildren<Text>().text = "手部未被破坏";
        }
        if (chestyon)
        {
            GameObject.Find("TextAll3").GetComponentInChildren<Text>().text = "破坏腹部，获得泰拉尔的铁炮1个，神息石3个";
        }
        else if (!chestyon)
        {
            GameObject.Find("TextAll3").GetComponentInChildren<Text>().text = "腹部未被破坏";
        } if (knee1yon)
        {
            GameObject.Find("TextAll4").GetComponentInChildren<Text>().text = "破坏左膝部，获得神息石5个";
        }
        else if (!knee1yon)
        {
            GameObject.Find("TextAll4").GetComponentInChildren<Text>().text = "左膝部未被破坏";
        } if (knee2yon)
        {
            GameObject.Find("TextAll5").GetComponentInChildren<Text>().text = "破坏右膝部，获得神息石5个";
        }
        else if (!knee2yon)
        {
            GameObject.Find("TextAll5").GetComponentInChildren<Text>().text = "右膝部未被破坏";
        }
        end = true;
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