using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public GameObject Main_Panel;
    public GameObject Comunity_Panel;
    public GameObject Shop_Panel;
    public GameObject Unit_Panel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Comunity_Btn()
    {
        Comunity_Panel.SetActive(true);
        Shop_Panel.SetActive(false);
        Unit_Panel.SetActive(false);
        Main_Panel.SetActive(false);
    }

    public void Shop_Btn()
    {
        Comunity_Panel.SetActive(false);
        Shop_Panel.SetActive(true);
        Unit_Panel.SetActive(false);
        Main_Panel.SetActive(false);
    }

    public void Fight_Btn()
    {
        Comunity_Panel.SetActive(false);
        Shop_Panel.SetActive(false);
        Unit_Panel.SetActive(false);
        Main_Panel.SetActive(true);
    }

    public void Unit_Btn()
    {
        Comunity_Panel.SetActive(false);
        Shop_Panel.SetActive(false);
        Unit_Panel.SetActive(true);
        Main_Panel.SetActive(false);
    }
}
