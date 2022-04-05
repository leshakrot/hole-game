using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentSplit : MonoBehaviour
{

	public bool isdead = false; //���������� ������� ���������� ���������� ������, ��� ��� ���

	void Start()
	{
		GetComponent<Rigidbody>().isKinematic = true;//�������� � ���������� ��������� ���� ��� ������ �� ���������� ������ �������
	}

	void OnTriggerEnter()//��������� �� ������ �� ��������
	{
		GetComponent<Rigidbody>().isKinematic = false;//� ���� �� � ���-�� ����������, ��������� ��������� ��� ����� �������� ���
		isdead = true;//������ ���������� �������������, ����� ������ ���� ������ ��� ������ ��� "���������", � ��� ����� �������
	}
}
