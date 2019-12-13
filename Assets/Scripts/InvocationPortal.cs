using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class InvocationPortal : MonoBehaviour
{
    public Image monsterImage;
    public int invocationCost;
    public Text gemsNumber, monsterName;
    public GameObject cannotSummon;

    private Monster monster = null;
    private int timeInLoop;
    private float alpha;

    void Start()
    {
        cannotSummon.SetActive(false);
        gemsNumber.text = Player.Gems.ToString();
    }

    public void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Summon()
    {
        if(Player.Gems >= invocationCost)
        {
            int rng = Random.Range(0, 100);
            if (rng < 89)    // summon 1 star monster
            {
                monster = ListMonsters.OneStarMonsters[Random.Range(0, ListMonsters.OneStarMonsters.Count)];
            }
            else if (rng < 99)    // summon 2 star monster
            {
                monster = ListMonsters.TwoStarsMonsters[Random.Range(0, ListMonsters.TwoStarsMonsters.Count)];
            }
            else if (rng == 99)    // summon 3 star monster
            {
                monster = ListMonsters.ThreeStarsMonsters[Random.Range(0, ListMonsters.ThreeStarsMonsters.Count)];
            }
            //monsterImage.sprite = Resources.Load<Sprite>("MonstersThumbnails/" + monster.getName());
            timeInLoop = 0;
            alpha = .1f;
            StartCoroutine(SummonAnimation(2f, 1f));
            monsterName.text = monster.getName();
            Player.addMonster(monster);
            Player.Gems -= invocationCost;
            DataSaver.SaveData("player");
            gemsNumber.text = Player.Gems.ToString();
        }
        else
        {
            cannotSummon.SetActive(true);
        }
    }

    public void CloseCannotSummon()
    {
        cannotSummon.SetActive(false);
    }

    public IEnumerator SummonAnimation(float animationSpeed, float animationDuration)
    {
        float counter = 0;
        float innerCounter = 0;

        while (counter < animationDuration)
        {
            counter += Time.deltaTime;
            innerCounter += Time.deltaTime;

            //Toggle and reset if innerCounter > blinkSpeed
            if (innerCounter > animationSpeed)
            {
                ToggleMonsterImage();
                innerCounter = 0f;
            }

            ToggleMonsterImage();

            //Wait for a frame
            yield return null;
        }
        monsterImage.sprite = Resources.Load<Sprite>("MonstersThumbnails/" + monster.getName());
        /*

                float start = Time.deltaTime;
                while (Time.time - start < 2f)
                {
                    ToggleMonsterImage();
                    yield return new WaitForSeconds(.1f);
                }
                monsterImage.sprite = Resources.Load<Sprite>("MonstersThumbnails/" + monster.getName());*/
    }

    private void ToggleMonsterImage()
    {
        if(monsterImage.sprite == null)
        {
            monsterImage.sprite = Resources.Load<Sprite>("MonstersThumbnails/" + monster.getName());
            Color tmp = monsterImage.color;
            tmp.a = alpha;
            monsterImage.color = tmp;
        }
        else
        {
            monsterImage.sprite = null;
        }
        alpha *= 1.1f;
    }
}
