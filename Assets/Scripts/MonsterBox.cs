using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterBox : MonoBehaviour
{
    public GameObject monsterButtonPrefab;
    public GameObject monstersListContainer;

    private List<Monster> _monsters;

    private GameObject nameDisplay;
    private GameObject roleDisplay;
    private GameObject alimDisplay;
    private GameObject hpDisplay;
    private GameObject attackDisplay;
    private GameObject defDisplay;
    private GameObject speedDisplay;
    private GameObject critRateDisplay;
    private GameObject critDmgDisplay;

    // Start is called before the first frame update
    void Start()
    {
        _monsters = Player.getMonsters();

        nameDisplay = GameObject.Find("MonsterName");
        roleDisplay = GameObject.Find("Role");
        alimDisplay = GameObject.Find("Alim");
        hpDisplay = GameObject.Find("Hp");
        attackDisplay = GameObject.Find("Attack");
        defDisplay = GameObject.Find("Def");
        speedDisplay = GameObject.Find("Speed");
        critRateDisplay = GameObject.Find("CritRate");
        critDmgDisplay = GameObject.Find("CritDmg");

        // create monsters list
        foreach (Monster m in _monsters)
        {
            Sprite sprite = Resources.Load<Sprite>("MonstersThumbnails/" + m.getName());    // load texture
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
            thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
            thumbnail.transform.SetParent(monstersListContainer.transform);                 // place button at the right place
            thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
            string monsterName = m.getName();
            thumbnail.GetComponent<Button>().onClick.AddListener(() => DisplayMonsterData(m));
        }

        if(_monsters.Count > 0)
            DisplayMonsterData(_monsters[0]);   // display data of the first monster
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void DisplayMonsterData(Monster m)
    {
        Debug.Log("monster " + m.getName() + " is selected");
        // image part
        Sprite monsterSprite = Resources.Load<Sprite>("MonstersSprites/" + m.getName());
        GameObject spriteContainer = GameObject.Find("MonsterSprite");
        spriteContainer.GetComponent<Image>().sprite = monsterSprite;
        // data part
        nameDisplay.GetComponent<Text>().text = m.getName();
        roleDisplay.GetComponent<Text>().text = m.getRole();
        alimDisplay.GetComponent<Text>().text = m.getDiet();
        hpDisplay.GetComponent<Text>().text = m.getMaxHp().ToString();
        attackDisplay.GetComponent<Text>().text = m.getAttack().ToString();
        defDisplay.GetComponent<Text>().text = m.getDef().ToString();
        speedDisplay.GetComponent<Text>().text = m.getSpeed().ToString();
        critRateDisplay.GetComponent<Text>().text = m.getCritRate().ToString();
        critDmgDisplay.GetComponent<Text>().text = m.getCritDmg().ToString();
    }
}
