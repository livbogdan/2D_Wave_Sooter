using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    public KeyCode[] weaponInput;

    int weaponSelected = 0;

    [SerializeField]
    public GameObject[] weapons;

    [SerializeField]
    public GameObject[] sprites;

    [SerializeField]
    public GameObject[] switchWeaponSound;

    // Start is called before the first frame update
    void Start()
    {
        SwapWeapon(0);
        SwapSprite(0);
        SwapSound(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(weaponInput[0]))
        {
            if (weaponSelected != 0)
            {
                SwapWeapon(0);
                SwapSprite(0);
                SwapSound(0);
            }
        }

        if (Input.GetKeyDown(weaponInput[1]))
        {
            if (weaponSelected != 1)
            {
                SwapWeapon(1);
                SwapSprite(1);
                SwapSound(1);
            }
        }

        if (Input.GetKeyDown(weaponInput[2]))
        {
            if (weaponSelected != 2)
            {
                SwapWeapon(2);
                SwapSprite(2);
                SwapSound(2);
            }
        }

        if (Input.GetKeyDown(weaponInput[3]))
        {
            if (weaponSelected != 3)
            {
                SwapWeapon(3);
                SwapSprite(3);
                SwapSound(3);
            }
        }
    }

    void SwapWeapon(int weaponType)
    {
        if (weaponType == 0)
        {
            
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
           

            weaponSelected = 0;
        }

        if (weaponType == 1)
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);

            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);

            weaponSelected = 1;
        }

        if (weaponType == 2)
        {
            //Weapon two
            
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(false);
            


            //Sprite for weapon two
            
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(true);
            sprites[3].SetActive(false);
            

            weaponSelected = 2;
        }

        if (weaponType == 3)
        {
            //Weapon Three
            
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(false);
            weapons[3].SetActive(true);
            

            //Sprite For weapon 3
            
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(true);
            

            weaponSelected = 3;
        }
    }

    void SwapSprite(int weaponSprite)
    {
        if (weaponSprite == 0)
        {
           
            sprites[0].SetActive(true);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);

            weaponSelected = 0;
        }

        if (weaponSprite == 1)
        {

            sprites[0].SetActive(false);
            sprites[1].SetActive(true);
            sprites[2].SetActive(false);
            sprites[3].SetActive(false);

            weaponSelected = 1;
        }

        if (weaponSprite == 2)
        {

            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(true);
            sprites[3].SetActive(false);


            weaponSelected = 2;
        }

        if (weaponSprite == 3)
        {

            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
            sprites[3].SetActive(true);


            weaponSelected = 3;
        }
    }

    void SwapSound(int swapSound)
    {
        if (swapSound == 0)
        {

            switchWeaponSound[0].SetActive(true);
            switchWeaponSound[1].SetActive(false);
            switchWeaponSound[2].SetActive(false);
            switchWeaponSound[3].SetActive(false);

            weaponSelected = 0;
        }

        if (swapSound == 1)
        {

            switchWeaponSound[0].SetActive(false);
            switchWeaponSound[1].SetActive(true);
            switchWeaponSound[2].SetActive(false);
            switchWeaponSound[3].SetActive(false);

            weaponSelected = 1;
        }

        if (swapSound == 2)
        {

            switchWeaponSound[0].SetActive(false);
            switchWeaponSound[1].SetActive(false);
            switchWeaponSound[2].SetActive(true);
            switchWeaponSound[3].SetActive(false);


            weaponSelected = 2;
        }

        if (swapSound == 3)
        {

            switchWeaponSound[0].SetActive(false);
            switchWeaponSound[1].SetActive(false);
            switchWeaponSound[2].SetActive(false);
            switchWeaponSound[3].SetActive(true);


            weaponSelected = 3;
        }
    }

}
