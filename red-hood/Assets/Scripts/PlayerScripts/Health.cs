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
}
