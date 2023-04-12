using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    private int lifes = 5;
    public TextMeshProUGUI uiLifes;
    public Vector3 startPosition;
    public PlayerInventory playerInventory;
    public TextMeshProUGUI gems;

    void Start()
    {
        uiLifes.text = lifes.ToString();
        startPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        playerInventory= gameObject.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        uiLifes.text = lifes.ToString();
        if(lifes== 0) {
            this.gameObject.transform.position = startPosition;
            lifes= 5;
        }
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
