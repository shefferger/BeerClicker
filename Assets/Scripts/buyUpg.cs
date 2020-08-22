using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

public class buyUpg : MonoBehaviour {

    List<upgrades> up = new List<upgrades>(41);//НЕ ЗАБЫТЬ ЕМКОСТЬ
    List<donatUpgrades> donUp = new List<donatUpgrades>(7);
    Hashtable langT = new Hashtable();
    string lng;
    bool langSetted;
    public GameObject content, contentDon, _friend, _friend_legs, _waiter;
    

    private void Awake()
    {
        if (PlayerPrefs.HasKey("lang"))
        {
            langSetted = true;
            lng = PlayerPrefs.GetString("lang");
        }
        langT.Add("ru_upg1p1", "Пшеничное пиво");
        langT.Add("en_upg1p1", "Witbier");

        langT.Add("ru_upgp2", " \nцена: ");
        langT.Add("en_upgp2", " \ncost: ");

        langT.Add("en_upgp3", " l.");
        langT.Add("ru_upgp3", " л.");

        langT.Add("en_upgpd", " pretzels");
        langT.Add("ru_upgpd", " кренделей");

        langT.Add("ru_nomoney", "Недостаточно средств!");
        langT.Add("en_nomoney", "Not enough funds!");
    }

    void Start() {
        //название, в секунду, за клик, цена, коэф увелич стоимости, имя ru, имя en
        //ale
        //                     название / перСЕК/цена/
        up.Add(new upgrades(0, "witbier", 1, 30, 20, "Пшеничное пиво", "Witbier"));
        up.Add(new upgrades(1, "berliner_weisse", 3, 150, 21, "Берлинское белое", "Berliner Weisse"));
        up.Add(new upgrades(2, "blond_ale", 10, 450, 22, "Блонд эль", "Blond Ale"));
        up.Add(new upgrades(3, "pale_ale", 18, 800, 23, "Светлый эль", "Pale Ale"));
        up.Add(new upgrades(4, "kolsch", 40, 1600, 24, "Кёльш", "Kolsch"));
        up.Add(new upgrades(5, "golden_ale", 60, 4000, 25, "Золотой эль", "Golden Ale"));
        up.Add(new upgrades(6, "tripel", 90, 8000, 26, "Трипель", "Tripel"));
        up.Add(new upgrades(7, "ipa", 150, 14000, 27, "IPA", "IPA"));
        up.Add(new upgrades(8, "saison_ale", 210, 27000, 28, "Сезонный эль", "Saison Ale"));
        up.Add(new upgrades(9, "english_bitter", 320, 50000, 29, "Английский биттер", "English Bitter"));
        up.Add(new upgrades(10, "double_ipa", 500, 90000, 30, "Двойной IPA", "Double IPA"));
        up.Add(new upgrades(11, "red_ale", 700, 150000, 31, "Красный эль", "Red Ale"));
        up.Add(new upgrades(12, "dubbel", 1100, 230000, 32, "Дуббель", "Dubbel"));
        up.Add(new upgrades(13, "old_ale", 1500, 500000, 33, "Старый эль", "Old Ale"));
        up.Add(new upgrades(14, "amber_ale", 2000, 850000, 34, "Янтарный эль", "Amber Ale"));
        up.Add(new upgrades(15, "quadrupel", 3000, 1500000, 35, "Квадрупель", "Quadrupel"));
        up.Add(new upgrades(16, "mild_ale", 4000, 3500000, 36, "Мягкий эль", "Mild Ale"));
        up.Add(new upgrades(17, "oud_bruin", 5500, 25000000, 37, "Старое коричневое", "Oud Bruin"));
        up.Add(new upgrades(18, "dunkelweizen", 7000, 80000000, 38, "Темное пшеничное", "Dunkelweizen"));
        up.Add(new upgrades(19, "brown_ale", 9000, 150000000, 39, "Коричневый эль", "Brown Ale"));
        up.Add(new upgrades(20, "porter", 12000, 400000000, 40, "Портер", "Porter"));
        up.Add(new upgrades(21, "stout", 16000, 900000000, 42, "Стаут", "Stout"));
        //lager
        up.Add(new upgrades(22, "munchener_hell", 21000, 2000000000, 44, "Мюнхенское светлое", "Munchener Hell"));
        up.Add(new upgrades(23, "pilsner", 25000, 5000000000, 46, "Пильзнер", "Pilsner"));
        up.Add(new upgrades(24, "dortmunder", 30000, 10000000000, 48, "Дортмундер", "Dortmunder"));
        up.Add(new upgrades(25, "maibock", 38000, 20000000000, 50, "Майбок", "Maibock"));
        up.Add(new upgrades(26, "wiener_lager", 45000, 35000000000, 55, "Венский лагер", "Wiener Lager"));
        up.Add(new upgrades(27, "kellerbier", 55000, 50000000000, 60, "Келлербир", "Kellerbier"));
        up.Add(new upgrades(28, "doppelbock", 70000, 80000000000, 65, "Доппельбок", "Doppelbock"));
        up.Add(new upgrades(29, "bock", 100000, 140000000000, 70, "Бок", "Bock"));
        up.Add(new upgrades(30, "weizenbock", 120000, 200000000000, 75, "Пшеничный бок", "Weizenbock"));
        up.Add(new upgrades(31, "dunkel_lager", 150000, 260000000000, 80, "Темный лагер", "Dunkel Lager"));
        up.Add(new upgrades(32, "eisbock", 205000, 300000000000, 85, "Айсбок", "Eisbock"));
        up.Add(new upgrades(33, "schwarzbier", 300000, 340000000000, 90, "Черное пиво", "Schwarzbier"));
        //mixed brew
        up.Add(new upgrades(34, "cream_ale", 400000, 400000000000, 95, "Сливочный эль", "Cream Ale"));
        up.Add(new upgrades(35, "lambic", 450000, 500000000000, 100, "Ламбик", "Lambic"));
        up.Add(new upgrades(36, "marzen", 500000, 600000000000, 120, "Мартовское пиво", "Marzen"));
        up.Add(new upgrades(37, "bieredegarde", 600000, 700000000000, 140, "Бьер-де-Гард", "Biere de Garde"));
        up.Add(new upgrades(38, "barley_wine", 700000, 800000000000, 160, "Ячменное пиво", "Barley wine"));
        up.Add(new upgrades(39, "altbier", 850000, 1000000000000, 180, "Альтбир", "Altbier"));
        up.Add(new upgrades(40, "rauchbier", 1000000, 10000000000000, 200, "Раухбир", "Rauchbier"));

        donUp.Add(new donatUpgrades(50, "worker", 3, 10, 5, "Позвать рабочего с пивзавода", "Call a worker from the brewery"));
        donUp.Add(new donatUpgrades(51, "sosed", 1, 5, 5, "Позвать соседа", "Call a neighbor"));
        donUp.Add(new donatUpgrades(52, "waiter", 0, 0, 5, "Нанять официанта","Hire a waiter"));
        donUp.Add(new donatUpgrades(53, "barmen", 10, 40, 5, "Нанять бармена", "Hire a barmen"));
        donUp.Add(new donatUpgrades(54, "director", 50, 120, 30, "Нанять директора пивзавода", "Hire a brewery director"));
        donUp.Add(new donatUpgrades(55, "taster", 5, 20, 5, "Нанять дегустатора", "Hire a beer taster"));
        donUp.Add(new donatUpgrades(56, "laborator", 25, 60, 10, "Нанять лаборанта", "Hire a lab. assistant"));

        for (int i = 0; i < up.Capacity; i++)
            if (PlayerPrefs.HasKey(up[i]._name))        //loading
            {
                up[i].loadUpgs();
            }
        for (int i = 0; i < donUp.Capacity; i++)
            if (PlayerPrefs.HasKey(donUp[i]._name))        //loading
            {
                donUp[i].loadUpgs();
            }
        if (PlayerPrefs.HasKey("sosed"))
        {
            _friend.SetActive(!_friend.activeSelf);
            _friend_legs.SetActive(!_friend_legs.activeSelf);
        }
        if (PlayerPrefs.HasKey("waiter"))
        {
            _waiter.SetActive(!_waiter.activeSelf);
        }
        
        setUpgName();
    }

    // Update is called once per frame
    void Update() {
        if (!langSetted && PlayerPrefs.HasKey("lang"))
        {
            langSetted = true;
            lng = PlayerPrefs.GetString("lang");
            setUpgName();
        }
        if (lng != PlayerPrefs.GetString("lang"))
            langSetted = false;
    }

    public void setDefaultVals()
    {
        for (int i = 0; i < up.Capacity; i++)
            up[i].remUpg();
        setUpgName();
    }

    public void setUpgName()
    {
        Button[] b = new Button[up.Capacity];
        Button[] d = new Button[donUp.Capacity];
        Text c1;
        b = content.GetComponentsInChildren<Button>();
        d = contentDon.GetComponentsInChildren<Button>();
        ICollection keys = langT.Keys;
        if (PlayerPrefs.HasKey("lang"))
        {
            for (int i = 0; i < up.Capacity; i++)
            {
                c1 = b[i].GetComponentInChildren<Text>();
                if (i == 0 || i == 1)
                    c1.text = up[i].get_name() + "\n +" + shortener(up[i]._litPerSec) + " l/s" + langT[lng + "_upgp2"] + shortener(up[i]._cost) + langT[lng + "_upgp3"];
                else
                    if (up[i - 1]._count > 0)
                    c1.text = up[i].get_name() + "\n +" + shortener(up[i]._litPerSec) + " l/s" + langT[lng + "_upgp2"] + shortener(up[i]._cost) + langT[lng + "_upgp3"];
                else
                    c1.text = "???";
                c1.transform.GetChild(0).GetComponent<Text>().text = up[i]._count.ToString();
            }
            for (int i = 0; i < donUp.Capacity; i++)
            {
                c1 = d[i].GetComponentInChildren<Text>();

                c1.text = donUp[i].get_name() + langT[lng + "_upgp2"] + donUp[i]._cost + langT[lng + "_upgpd"];
                c1.transform.GetChild(0).GetComponent<Text>().text = donUp[i]._count.ToString();
            }
        }
    }

    public void button_buyUpgrade(UnityEngine.GameObject sender)
    {
        bool isBuy = false;
        string typeOfBuy = sender.name[0].ToString();
        int upgNum = Convert.ToInt16((sender.name[1].ToString() + sender.name[2].ToString()));
        if (typeOfBuy == "l")
        {
            if (upgNum == 1)
                isBuy = up[upgNum - 1].buyUpgr(Convert.ToUInt64(_game.litresSt));
            if (upgNum > 1 && up[upgNum - 2]._count >= 1)
                isBuy = up[upgNum - 1].buyUpgr(Convert.ToUInt64(_game.litresSt));
        }
        if (typeOfBuy == "d")
        {
            isBuy = donUp[upgNum - 1].buyUpgr(_game.donvalSt);
            if (isBuy)
                switch (upgNum)
                {
                    case 2:
                        if (donUp[upgNum - 1]._count == 1)
                        {
                            _friend.SetActive(!_friend.activeSelf);
                            _friend_legs.SetActive(!_friend_legs.activeSelf);
                        }
                        break;
                    case 3:
                        if (donUp[upgNum - 1]._count == 1)
                            _waiter.SetActive(!_waiter.activeSelf);
                        break;
                    default:
                        break;
                }
        }
        if (isBuy)
        {
            setUpgName();
        }
        else
        {
            sender.GetComponentInChildren<Text>().text = langT[lng + "_nomoney"].ToString();
            StartCoroutine(no_money_my_friend(sender));
        }
        
        isBuy = false;
    }

    private IEnumerator no_money_my_friend(UnityEngine.GameObject sender)
    {
        yield return new WaitForSeconds(3f);
        setUpgName();
    }

    private string shortener(double a)
    {
        string res = a.ToString();
        string multiplier = "";
        if (a >= 10000 && a < 1000000)
        {
            a = a / 1000;
            multiplier = "K.";
        }
        else if (a >= 1000000 && a < 1000000000)
        {
            a = a / 1000000;
            multiplier = "M.";
        }
        else if (a >= 1000000000 && a < 1000000000000)
        {
            a = a / 1000000000;
            multiplier = "B.";
        }
        else if (a >= 1000000000000 && a < 1000000000000000)
        {
            a = a / 1000000000000;
            multiplier = "Q.";
        }
        res = a.ToString() + multiplier;
        return res;
    }
}

public class donatUpgrades
{
    public string _name { get; set; }
    public int _id { get; set; }
    public ulong _litPerCl { get; set; }
    public int _count { get; set; }
    public ulong _cost { get; set; }
    private double _koef { get; set; }
    private ulong _defCost;
    public string _ru { get; set; }
    public string _en { get; set; }
    //private int eventType;

    public donatUpgrades(int id, string name, ulong litPerCl, ulong cost, double koef, string ru_name, string en_name)
    {
        _id = id;
        _name = name;
        _litPerCl = litPerCl;
        _count = 0;
        _defCost = cost;
        _cost = cost;
        _koef = koef;
        _ru = ru_name;
        _en = en_name;
    }


    public bool buyUpgr(double money)
    {
        if (money >= _cost)
        {
            _count += 1;
            _game.donvalSt -= (int)_cost;
            _game.litresPerClickSt += _litPerCl;
            _cost += Convert.ToUInt64(_koef);
            if (PlayerPrefs.HasKey(_name))
                PlayerPrefs.DeleteKey(_name);
            PlayerPrefs.SetInt(_name, _count);
            Debug.Log(_name + " saved in count of " + _count);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void remUpg()
    {
        _cost = _defCost;
        _count = 0;
    }

    public void loadUpgs()
    {
        _count = PlayerPrefs.GetInt(_name);
        for (int i = 0; i < _count; i++)
        {
            _game.litresPerClickSt += _litPerCl;
            _cost = Convert.ToUInt64(Math.Round(_cost + _cost * (_koef / 100)));
            
        }
        Debug.Log("Upgrade " + _name + " loaded in count " + _count);
    }

    public string get_name()
    {
        if (PlayerPrefs.GetString("lang") == "ru")
            return _ru;
        if (PlayerPrefs.GetString("lang") == "en")
            return _en;
        return "";
    }

}


public class upgrades
{
    public string _name { get; set; }
    public int _id { get; set; }
    public int _litPerSec { get; set; }
    public int _count { get; set; }
    public ulong _cost { get; set; }
    private double _koef { get; set; }
    private ulong _defCost;
    public string _ru { get; set; }
    public string _en { get; set; }

    public upgrades(int id, string name, int litPerSec, ulong cost, double koef, string ru_name, string en_name)
    {
        _id = id;
        _name = name;
        _litPerSec = litPerSec;
        _count = 0;
        _defCost = cost;
        _cost = cost;
        _koef = koef;
        _ru = ru_name;
        _en = en_name;
    }

    public bool buyUpgr(double money)
    {
        if (money >= _cost)
        {
            _count += 1;
            _game.litresSt -= _cost;
            _game.litresPerSecondSt += Convert.ToUInt64(_litPerSec);
            _cost = Convert.ToUInt64(Math.Round(_cost + _cost * (_koef / 100), 1));
            if (PlayerPrefs.HasKey(_name))
                PlayerPrefs.DeleteKey(_name);
            PlayerPrefs.SetInt(_name, _count);
            Debug.Log(_name + " saved in count of " + _count);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void remUpg()
    {
        _cost = _defCost;
        _count = 0;
    }

    public void loadUpgs()
    {
        _count = PlayerPrefs.GetInt(_name);
        for (int i = 0; i < _count; i++)
        {
            _game.litresPerSecondSt += Convert.ToUInt64(_litPerSec);
            _cost = Convert.ToUInt64(Math.Round(_cost + _cost * (_koef / 100), 1));
        }
        Debug.Log("Upgrade " + _name + " loaded in count " + _count);
    }

    public string get_name()
    {
        if (PlayerPrefs.GetString("lang") == "ru")
            return _ru;
        if (PlayerPrefs.GetString("lang") == "en")
            return _en;
        return "";
    }
}
