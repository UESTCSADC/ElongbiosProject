using UnityEngine;
using System.Collections;

public class Elongbios1 : MonoBehaviour {
    public GameObject attack;
	public GameObject defenceE;
	public GameObject MoveE;
    public GameObject terrar1;
	public GameObject flare3, flare4;

	public float HP;
	public float monsterHP;
	public float sp;
	public float Radius;
	public float AttackRadius;
	public float HopenessFlyHeight;
	public float speed;
	public float step;
	public float check;
    public float x, y, x1, y1;

    public int count;

	public bool hited;
	public bool recovery;
	public bool avoid;
    public bool hite;
    public bool terrarhite;

	public Animator animator;
	public Animator HopenessFlyAnimator;
	public Animator terraranimator;
	
	public Vector3 PositionA;
	public Vector3 PositionB;
	public Vector3 PositionC;

	public float PositionAx,PositionAy;
	public float PositionBx,PositionBy;
	public float PositionCx,PositionCy;

	public AudioClip move;
	AudioSource moveSound;

	// Use this for initialization
	void Start () {
		moveSound = gameObject.AddComponent<AudioSource>();
		moveSound.clip = move;
		HP = 1000;

		PositionAx = 219;
		PositionAy = 121;
		PositionBx = 280;
		PositionBy = 220;
		PositionCx = 335;
		PositionCy = 160;
		HopenessFlyHeight = 82;
		speed = 100f;
		check = 0;
		sp = 100;
		count = 0;

		PositionA = new Vector3 (PositionAx,PositionAy,-4);
		PositionB = new Vector3 (PositionBx,PositionBy,-4);
		PositionC = new Vector3 (PositionCx,PositionCy,-4);

		Radius = 0;
		AttackRadius = 0;

		hited = false;
		recovery = false;
        avoid = false;
        hite = false;
        terrarhite = false;

		animator = this.GetComponent<Animator>();
		HopenessFlyAnimator = GameObject.Find ("HopenessFly").GetComponent<Animator> ();
		this.transform.position = PositionB;
		GameObject.Find ("HopenessFly").transform.position =
			new Vector3 (PositionBx,PositionBy+HopenessFlyHeight,-3);
		GameObject.Find ("Hopeness").transform.position = new Vector3 (10000, 0, -3);



	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("red").GetComponent<SpriteRenderer> ().color.a > 0)
			GameObject.Find ("red").GetComponent<SpriteRenderer> ().color += new Color(0,0,0,-0.01f);
        if (hited == true &&( Input.GetKeyUp(KeyCode.Space)||Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.D)))
            hited = false;
        if (hited == false)
        {
            Defence();
            Attack();
            Avoid();
            Focus();
        }
		if (hite == true && !Input.GetKey(KeyCode.Space)&& !Input.GetKey(KeyCode.D) && animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.InSing"))
        {
			GameObject.Find("checkpoint").GetComponent<NoveContorl1>().novaA();
            hite = false;
            terrarhite = true;
        }
		if (avoid == true) {
			Fly ();
		}
       
	}

	public void BeAttack(int damage)
	{
		GameObject.Find ("red").GetComponent<SpriteRenderer> ().color += new Color(0,0,0,0.3f);
		this.GetComponent<Animator> ().SetBool ("hited", true);
        terrar1.GetComponent<terrar1>().shake();
        if (recovery == true) {
            GameObject.Find("State").GetComponent<soundmaker>().playdefence();
		    HP -= Mathf.Max((damage - 200),0);
			if(GameObject.Find("Defence(Clone)"))
				GameObject.Destroy(GameObject.Find("Defence(Clone)"));
			GameObject de = (GameObject)Instantiate(defenceE,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
			de.transform.Rotate(90,0,0);
		} else {
            GameObject.Find("State").GetComponent<soundmaker>().playboom();
            HP -= damage;
            avoid = false;
            GameObject.Find("HopenessFly").transform.position = this.transform.position + new Vector3(0, HopenessFlyHeight, 0);
            hite = false;
            Radius = 0;
            AttackRadius = 0;
            hited = true;
            GameObject.Find("Hopeness").transform.position = new Vector3(10000, 0, -3);
        }
		HP = Mathf.Max (0, HP);
		if (HP == 0) {
			this.GetComponent<Animator> ().SetBool ("dead", true);
		}
        if (this.transform.position == PositionA)
        {
            count = -1;
        }
        else if (this.transform.position == PositionB)
        {
            count = 0;
        }
        else if (this.transform.position == PositionC)
        {
            count = 1;
        }
	}

	public void Defence()
	{
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.EndSing"))
		if (Input.GetKey (KeyCode.A)&&!avoid&&!GameObject.Find("HopenessFly").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.face-attach")) 
		{
			animator.SetBool("enddefence",false);
			animator.SetBool("todefence",true);
			sp-=0.1f;
			check++;
			if (check>=44)
			{
				recovery=true;
			}
			if (sp<=0)
			{
				animator.SetBool("enddefence",true);
				sp=0;
			}
		}
		else if (!Input.GetKey(KeyCode.A))
		{
			recovery=false;
			animator.SetBool("todefence",false);
			animator.SetBool("enddefence",true);
			if(sp < 300 && animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Breath"))
				sp+=0.1f;
			if(sp > 300)
				sp = 300;
		}
	}
	public void Attack()
	{
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.EndSing"))
		if (Input.GetKey (KeyCode.Space)&&!avoid&&!GameObject.Find("HopenessFly").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.face-attach")) {
            hite = true;
			animator.SetBool ("endsing",false);
			HopenessFlyAnimator.SetBool("attach",false);
			animator.SetBool("tosing",true);
                x = GameObject.Find("checkpoint").transform.position.x;
                y = GameObject.Find("checkpoint").transform.position.y;
                x1 = GameObject.Find("handpoint").transform.position.x;
                y1 = GameObject.Find("handpoint").transform.position.y;
                if (!(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - AttackRadius-41 <= 1.5 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - AttackRadius-41 >= -1.5))
                {
                    Radius += 3;
                }
            attack.SetActive(true);
			if (this.transform.position==PositionA)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionAx,PositionAy+HopenessFlyHeight+Radius,-3);
			}else if (this.transform.position==PositionB)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionBx,PositionBy+HopenessFlyHeight+Radius,-3);
			}else if (this.transform.position==PositionC)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionCx,PositionCy+HopenessFlyHeight+Radius ,-3);
			}
			HopenessFlyAnimator.SetBool("fly",true);
            AttackRadius = Radius;
            
        }
            else if(!Input.GetKey(KeyCode.D))
		{
            attack.SetActive(false);
			animator.SetBool("tosing",false);
			animator.SetBool("endsing",true);
			HopenessFlyAnimator.SetBool("fly",false);
			HopenessFlyAnimator.SetBool("attach",true);
			Radius=0;
		}

	}

	public void Focus()
	{
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.EndSing"))
		if (Input.GetKey (KeyCode.D)&& sp>=1 &&!avoid&&!GameObject.Find("HopenessFly").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.face-attach")) {
			if(GameObject.Find("star").GetComponent<SpriteRenderer>().color.a < 0.5)
				GameObject.Find("star").GetComponent<SpriteRenderer>().color += new Color(0,0,0,0.1f);
			flare3.SetActive(true);
			flare4.SetActive(true);
            sp -= 0.1f;
			hite = true;
			animator.SetBool ("endsing",false);
			HopenessFlyAnimator.SetBool("attach",false);
			animator.SetBool("tosing",true);
                x = GameObject.Find("checkpoint").transform.position.x;
                y = GameObject.Find("checkpoint").transform.position.y;
                x1 = GameObject.Find("handpoint").transform.position.x;
                y1 = GameObject.Find("handpoint").transform.position.y;
                if (!(Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - AttackRadius - 41 <= 1.5 && Vector3.Distance(new Vector3(x, y, 0), new Vector3(x1, y1, 0)) - AttackRadius - 41 >= -1.5))
                {
                    Radius += 3;
                }
                GameObject.Find("BackGround").GetComponent<AudioSource>().volume=0.1f;
			if (this.transform.position==PositionA)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionAx,PositionAy+HopenessFlyHeight+Radius,-3);
			}else if (this.transform.position==PositionB)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionBx,PositionBy+HopenessFlyHeight+Radius,-3);
			}else if (this.transform.position==PositionC)
			{
				GameObject.Find("HopenessFly").transform.position=
					new Vector3(PositionCx,PositionCy+HopenessFlyHeight+Radius ,-3);
			}
			HopenessFlyAnimator.SetBool("fly",true);
			AttackRadius = Radius;
			terraranimator.speed = 0.2f;
		} 
		else  if(!Input.GetKey(KeyCode.Space))
		{
            GameObject.Find("BackGround").GetComponent<AudioSource>().volume = 0.32f;
			if(flare3)
				flare3.SetActive(false);
			if(flare4)
				flare4.SetActive(false);
			terraranimator.speed = 0.9f;
			animator.SetBool("tosing",false);
			animator.SetBool("endsing",true);
			HopenessFlyAnimator.SetBool("fly",false);
			HopenessFlyAnimator.SetBool("attach",true);
			Radius=0;
            if (GameObject.Find("star").GetComponent<SpriteRenderer>().color.a > 0)
			    GameObject.Find("star").GetComponent<SpriteRenderer>().color += new Color(0,0,0,-0.05f);
		}

	}

	public void Avoid()
	{
		if(sp >= 40)
		if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.EndSing"))
		if (!HopenessFlyAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Base Layer.face-attach")) {
			if (Input.GetKeyDown (KeyCode.RightArrow)&&
			    !Input.GetKey (KeyCode.Space)&&
			    !Input.GetKey (KeyCode.A)) {
				if (count < 1) {
					animator.SetBool("tosing",true);
					GameObject.Find ("HopenessFly").transform.position = new Vector3 (10000, 0, -3);
					GameObject.Find ("Hopeness").transform.localScale = new Vector3 (0.05f, 0.05f, 1);
					count += 1;
					avoid = true;
				}
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)&&
			           !Input.GetKey (KeyCode.Space)&&
			           !Input.GetKey (KeyCode.A)) {
				if (count > -1) {
					animator.SetBool("tosing",true);
					GameObject.Find ("HopenessFly").transform.position = new Vector3 (10000, 0, -3);
					GameObject.Find ("Hopeness").transform.localScale = new Vector3 (-0.05f, 0.05f, 1);
					count -= 1;
					avoid = true;
				}
			}
		}
	}
	public void hittedoff()
	{
		animator.SetBool ("hited", false);
	}

    public void Return()
    {
        Application.LoadLevel(1);
    }
	public void Fly()
	{
		if (GameObject.Find ("Hopeness").transform.position.x > 1000) {
			GameObject.Find ("Hopeness").transform.position=
				new Vector3(this.transform.position.x,this.transform.position.y+HopenessFlyHeight,-3);
			GameObject.Find ("HopenessFly").transform.position=
				new Vector3(-10000,0,-3);
		}
		if (count == 0) {
			step = speed * Time.deltaTime;
			GameObject.Find ("Hopeness").transform.position =
				Vector3.MoveTowards
					(GameObject.Find ("Hopeness").transform.position,
					 new Vector3 (PositionBx, PositionBy + HopenessFlyHeight, -3), step);
			if (Vector3.Distance (GameObject.Find ("Hopeness").transform.position,
			                     new Vector3 (PositionBx, PositionBy + HopenessFlyHeight, -3)) <= 1f) {
				GameObject.DestroyImmediate (GameObject.Find ("NoveMove(Clone)"));
				GameObject.DestroyImmediate (GameObject.Find ("Move(Clone)"));
				avoid = false;
				GameObject.Find ("Hopeness").transform.position = new Vector3 (10000, 0, -3);
				GameObject.Find ("HopenessFly").transform.position =
					new Vector3 (PositionBx, PositionBy + HopenessFlyHeight, -3);
				HopenessFlyAnimator.SetBool ("fly", true);
				HopenessFlyAnimator.SetBool ("attach", true);
				animator.SetBool("endsing",true);
				this.transform.position = PositionB;
				moveSound.Play();
				GameObject moveE = (GameObject)Instantiate(MoveE,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
				sp = sp -40;
			}
		} else if (count == 1) {
			step = speed * Time.deltaTime;
			GameObject.Find ("Hopeness").transform.position =
				Vector3.MoveTowards
					(GameObject.Find ("Hopeness").transform.position,
					 new Vector3 (PositionCx, PositionCy + HopenessFlyHeight, -3), step);
			if (Vector3.Distance (GameObject.Find ("Hopeness").transform.position,
			                     new Vector3 (PositionCx, PositionCy + HopenessFlyHeight, -3)) <= 1f) {
				GameObject.DestroyImmediate (GameObject.Find ("NoveMove(Clone)"));
				GameObject.DestroyImmediate (GameObject.Find ("Move(Clone)"));
				avoid = false;
				GameObject.Find ("Hopeness").transform.position = new Vector3 (10000, 0, -3);
				GameObject.Find ("HopenessFly").transform.position =
					new Vector3 (PositionCx, PositionCy + HopenessFlyHeight, -3);
				HopenessFlyAnimator.SetBool ("fly", true);
				HopenessFlyAnimator.SetBool ("attach", true);
				animator.SetBool("endsing",true);
				this.transform.position = PositionC;
				moveSound.Play();
				GameObject moveE = (GameObject)Instantiate(MoveE,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
				sp = sp -40;
			}
		} else if (count == -1) {
			step = speed * Time.deltaTime;
			GameObject.Find ("Hopeness").transform.position =
				Vector3.MoveTowards
					(GameObject.Find ("Hopeness").transform.position,
					 new Vector3 (PositionAx, PositionAy + HopenessFlyHeight, -3), step);
			if (Vector3.Distance (GameObject.Find ("Hopeness").transform.position,
			                      new Vector3 (PositionAx, PositionAy + HopenessFlyHeight, -3)) <= 1f) {
				GameObject.DestroyImmediate (GameObject.Find ("NoveMove(Clone)"));
				GameObject.DestroyImmediate (GameObject.Find ("Move(Clone)"));
				avoid = false;
				GameObject.Find ("Hopeness").transform.position = new Vector3 (10000, 0, -3);
				GameObject.Find ("HopenessFly").transform.position =
					new Vector3 (PositionAx, PositionAy + HopenessFlyHeight, -3);
				HopenessFlyAnimator.SetBool ("fly", true);
				HopenessFlyAnimator.SetBool ("attach", true);
				animator.SetBool("endsing",true);
				this.transform.position = PositionA;
				moveSound.Play ();
				GameObject moveE = (GameObject)Instantiate(MoveE,GameObject.Find("checkpoint").transform.position,Quaternion.identity);
				sp = sp -40;
			}
		}

			animator.SetBool ("endsing", false);
	}
}
