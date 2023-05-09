using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    public GameObject button;
    public GameObject cameraHolder;
    public EnemyAI enemyAI;
    public GameObject _gotHit;

    void Start()
    {
        uiLifes.text = lifes.ToString();
        startPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        playerInventory= gameObject.GetComponent<PlayerInventory>();
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        uiLifes.text = lifes.ToString();
        if(lifes== 0)
        {
            GameOver();
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
        this.GetComponent<PlayerMovement>().enabled = false;
        cameraHolder.GetComponent<PlayerCamera>().enabled = false;
        enemyAI.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        button.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyHit")
        {
            GotHurt();
            lifes -= 1;
            playerInventory.NumberOfDiamonds -= 3;
            if(playerInventory.NumberOfDiamonds <= 3)
            {
                playerInventory.NumberOfDiamonds = 0;
                gems.text = playerInventory.NumberOfDiamonds.ToString();
                return;
            }
            else if(playerInventory.NumberOfDiamonds <= 0)
            {
                playerInventory.NumberOfDiamonds = 0;
                gems.text = playerInventory.NumberOfDiamonds.ToString();
                return;
            }
            gems.text = playerInventory.NumberOfDiamonds.ToString();
        }
    }
    private void GotHurt()
    {
        var color = _gotHit.GetComponent<Image>().color;
        color.a = 0.8f;
        _gotHit.GetComponent<Image>().color = color;
    }
}
