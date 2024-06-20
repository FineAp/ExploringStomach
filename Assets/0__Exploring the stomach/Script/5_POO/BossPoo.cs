using UnityEngine;
using UnityEngine.UI;
public class BossPoo : MonoBehaviour
{
    public float speed;
    // public GameManager gameManager;
    public SceneMN scene;
    public GameObject[] winPoo;

    [SerializeField]
    private Slider hpBar;
    
    public float maxHp = 100;
    public float curHp = 100;
    private float imsi;

    private bool isBack = false;

    public bool isCure = false;

    // Start is called before the first frame update
    void Start()
    {
        hpBar.value = (float)curHp / (float)maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HP();
        PooCure();
    }

    void Move()
    {
        transform.Translate(speed * Time.deltaTime ,0f, 0f);
    }

    void HP()
    {
        if(isCure)
        {
            if(curHp > 0)
            {
                curHp += 10;
                isCure = false;
            }

            // else if(curHp == 100f)
            // {
            //     gameManager.finishPoo = true;
            //     Destroy(this.gameObject,2f);
            // }
            else curHp = 0;
            imsi = (float)curHp / (float)maxHp;
            
        }
        HandleHp();
    }

    private void HandleHp()
    {
        hpBar.value = Mathf.Lerp(hpBar.value, (float)curHp /(float)maxHp, Time.deltaTime * 10);


    }

    void PooCure()
    {
        if(curHp >= maxHp)
        {
            winPoo[0].SetActive(true);
            print("Win");
            gameObject.SetActive(false);
            Invoke("ChangeScene", 5f);
        }
    }

    void ChangeScene()
    {
        scene.ToClear();
    }

}
