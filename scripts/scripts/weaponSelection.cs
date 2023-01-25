using UnityEngine;
using UnityEngine.SceneManagement;
public class weaponSelection : MonoBehaviour
{
    public GameObject mainmenu, weaponselection, weapons;

    public GameObject [] allweapons;
    public GameObject[] allweaponsdata;

    public void playbtn()
    {
        mainmenu.SetActive(false);
        weaponselection.SetActive(true);
        weapons.SetActive(true);
    }
   public static int numb = 0;

    public void rightbtn()
    {
        numb++;
        if (numb<3)
        {
            for (int i = 0; i < allweapons.Length; i++)
            {
                allweapons[i].gameObject.SetActive(false);
                allweaponsdata[i].gameObject.SetActive(false);
            }
            allweapons[numb].gameObject.SetActive(true);
            allweaponsdata[numb].gameObject.SetActive(true);
        }
        else
        { 
        numb--;
        }
       
    }
    public void leftbtn()
    {
        numb--;
        if (numb >= 0)
        {
            for (int i = 0; i < allweapons.Length; i++)
            {
                allweapons[i].gameObject.SetActive(false);
                allweaponsdata[i].gameObject.SetActive(false);
            }
            allweapons[numb].gameObject.SetActive(true);
            allweaponsdata[numb].gameObject.SetActive(true);
        }
        else
        {
            numb++;
        }

    }


    public void  selectbtn()
    {
       // GameManager.Instance.num = numb;
        SceneManager.LoadScene(1);
    }

}
