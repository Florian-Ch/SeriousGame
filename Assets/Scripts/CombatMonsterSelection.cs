using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatMonsterSelection : MonoBehaviour
{
    public GameObject monsterButtonPrefab;
    public GameObject monstersListContainer;
    public GameObject playerMonstersContainer;
    public GameObject ennemiesContainer;
    public GameObject noSlotsPopup;

    private int numberOfPlayerMonsters;
    private List<Monster> _playerMonsters;

    private List<Monster> _monsters;
    // Start is called before the first frame update
    void Start()
    {
        noSlotsPopup.SetActive(false);
        numberOfPlayerMonsters = Combat.getNumberOfPlayerMonsters();
        _playerMonsters = new List<Monster>();

        _monsters = Player.getMonsters();
        // create monsters list
        foreach (Monster m in _monsters)
        {
            Sprite sprite = Resources.Load<Sprite>("MonstersThumbnails/" + m.getName());    // load texture
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;          // create button
            thumbnail.GetComponent<Image>().sprite = sprite;                                // apply texture
            thumbnail.transform.SetParent(monstersListContainer.transform);                 // place button at the right place
            thumbnail.transform.localScale = new Vector3(1, 1, 1);                          // resize button (sooo huge by default)
            thumbnail.GetComponent<Button>().onClick.AddListener(() => AddMonsterToFight(m));
        }

        DisplayPlayerMonsters();

        List<Monster> _ennemies = Combat.getEnnemies();
        foreach(Monster m in _ennemies)
        {
            Sprite sprite = Resources.Load<Sprite>("MonstersThumbnails/" + m.getName());
            GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;
            thumbnail.GetComponent<Image>().sprite = sprite;
            thumbnail.transform.SetParent(ennemiesContainer.transform);
            thumbnail.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void AddMonsterToFight(Monster m)
    {
        if(_playerMonsters.Count < numberOfPlayerMonsters)
        {
            _playerMonsters.Add(m);
            DisplayPlayerMonsters();
        }
        else
        {
            noSlotsPopup.SetActive(true);
        }
    }

    public void RemovePopup() { noSlotsPopup.SetActive(false); }

    public void RemoveMonster(Monster m)
    {
        _playerMonsters.Remove(m);
        DisplayPlayerMonsters();
    }

    public void DisplayPlayerMonsters()
    {
        foreach(Transform child in playerMonstersContainer.transform) { GameObject.Destroy(child.gameObject); }
        if(_playerMonsters.Count > 0)
        {
            foreach(Monster m in _playerMonsters)
            {
                Sprite sprite = Resources.Load<Sprite>("MonstersThumbnails/" + m.getName());
                GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;
                thumbnail.GetComponent<Image>().sprite = sprite;
                thumbnail.transform.SetParent(playerMonstersContainer.transform);
                thumbnail.GetComponent<Button>().onClick.AddListener(() => RemoveMonster(m));
                thumbnail.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        int emptySlots = numberOfPlayerMonsters - _playerMonsters.Count;
        if(emptySlots > 0)
        {
            for(int i=0; i<emptySlots; i++)
            {
                Sprite sprite = Resources.Load<Sprite>("BtnIcons/Monstres");
                GameObject thumbnail = Instantiate(monsterButtonPrefab) as GameObject;
                thumbnail.GetComponent<Image>().sprite = sprite;
                thumbnail.transform.SetParent(playerMonstersContainer.transform);
                thumbnail.transform.localScale = new Vector3(1, 1, 1);
            }        
        }
    }
}
