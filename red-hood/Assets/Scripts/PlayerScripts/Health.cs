using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    private int lifes = 5;
    public TextMeshProUGUI uiLifes;
    public Vector3 startPosition;
    public PlayerInventory playerInventory;
    public TextMeshProUGUI gems;
    public Player cameraHolder;
    public EnemyAI enemyAI;
    public GameObject _gotHit;
    public GameObject normalCanvas;
    public GameObject gameOverCanvas;
    public bool hit;
    public UGS_Analytic UGS_Analytic;
    private bool hasEventbeenSent;
    public int NumberOfLifes { get { return lifes; } private set { } }
    void Start()
    {
        uiLifes.text = lifes.ToString();
        startPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        playerInventory= gameObject.GetComponent<PlayerInventory>();
        gameOverCanvas.SetActive(false);
        normalCanvas.SetActive(true);
        hit = false;
        hasEventbeenSent = false;
    }

    // Update is called once per frame
    void Update()
    {
        uiLifes.text = lifes.ToString();
        if(lifes== 0)
        {
            GameOver();
            if (hasEventbeenSent == false)
            {
                UGS_Analytic.LevelFailedCustomEvent();
                UGS_Analytic.PlayerInventoryCustomEvent(playerInventory.NumberOfDiamonds, cameraHolder.numberOfKeys, lifes);
                hasEventbeenSent = true;
            }
        }
        if (_gotHit != null)
        {
            if (_gotHit.GetComponent<Image>().color.a > 0)
            {
                var color = _gotHit.GetComponent<Image>().color;
                color.a -= 0.01f;
                _gotHit.GetComponent<Image>().color = color;
            }
        }
    }

    private void GameOver()
    {
        this.gameObject.transform.position = startPosition;
        normalCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        cameraHolder.GetComponent<Player>().enabled = false;
        enemyAI.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyHit")
        {
            hit = true;
            GotHurt();
            lifes -= 1;
            
        }
    }
    private void GotHurt()
    {
        var color = _gotHit.GetComponent<Image>().color;
        color.a = 0.8f;
        _gotHit.GetComponent<Image>().color = color;
    }
}
