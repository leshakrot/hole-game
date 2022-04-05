using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSplit : MonoBehaviour
{

	public bool isdead = false; //переменная которая обозначает разрушился объект, или еще нет

	void Start()
	{
		GetComponent<Rigidbody>().isKinematic = true;//включаем у риджидбоди синематик дабы наш объект не разрушался раньше времени
	}

	void OnTriggerEnter()//проверяем на объект на коллизию
	{
		GetComponent<Rigidbody>().isKinematic = false;//и если он с чем-то столкнулся, отключаем синематик тем самым разрушая его
		isdead = true;//делаем переменную положительной, чтобы скрипт смог понять что обьект уже "отработан", и его можно удалить
	}
}
