﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuController : MonoBehaviour
{
	#region variables
	public bool submenuOpen;

	public Text announceText;
	public Text alertText;
	public GameObject charaStatusMenu;
//	public GameObject statsPanel;
//	public GameObject skillChartButton;
//	public GameObject skillChart;
//	public GameObject partyButton;
	public GameObject partyMenu;
	public GameObject partyList;
	public GameObject partyListContent;
	public Image[] partyMemberImages;
	public GameObject partyPosPanel;
	public Image[] partyOrderImages;
	public Transform[] memberForwardPositions;
	public Transform[] memberBackPositions;
	public GameObject inventory;
	public GameObject calendar;
	public GameObject questLog;
	public GameObject journal;
	public GameObject addEntryButton;
	public GameObject map;
	public GameObject achievementList;
	public GameObject saveMenu;
	public GameObject optionsMenu;

	gameController gameController;
	inventoryController inventoryController;
	public characterMenuController characterMenuController;
	characterStatusController charaStatus;
	#endregion

	// Use this for initialization
	void Start()
	{
		gameController = GameObject.Find("gameController").GetComponent<gameController>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void openStatusMenu()
	{
		closeMenu();
		charaStatusMenu.SetActive(true);
		submenuOpen = true;

		characterMenuController.numCharas = gameController.availCharas.Count;
		characterMenuController.charaPreviews = gameController.availCharas.ToArray();
		characterMenuController.selectedChara = gameController.currentChara;
	}

	public void openPartyMenu()
	{
		closeMenu();
		partyMenu.SetActive(true);
		partyList.SetActive(false);
		partyPosPanel.SetActive(false);
		submenuOpen = true;
	}

	public void openPartyList()
	{
		partyList.SetActive(true);
		partyPosPanel.SetActive(false);

		for (int i = 0; i < gameController.numCharasInParty; i++)
		{
//			partyMemberPos[i].sprite = 
//				gameController.currentParty[i].GetComponent<characterStatusController>().charaSprite;
		}
	}

	public void openPartyPosPanel()
	{
		partyList.SetActive(false);
		partyPosPanel.SetActive(true);
	}

	public void openInventory()
	{
		closeMenu();
		inventory.SetActive(true);
		submenuOpen = true;
	}

	public void openCalendar()
	{
		closeMenu();
		calendar.SetActive(true);
		submenuOpen = true;
	}

	public void openQuestLog()
	{
		closeMenu();
		questLog.SetActive(true);
		submenuOpen = true;
	}

	public void openJournal()
	{
		closeMenu();
		journal.SetActive(true);
		submenuOpen = true;
	}

	public void openMap()
	{
		closeMenu();
		map.SetActive(true);
		submenuOpen = true;
	}

	public void openAchievementList()
	{
		closeMenu();
		achievementList.SetActive(true);
		submenuOpen = true;
	}

	public void saveGame()
	{
		PlayerPrefs.Save();
	}

	public void openOptionsMenu()
	{
		closeMenu();
		optionsMenu.SetActive(true);
		submenuOpen = true;
	}

	public void closeMenu()
	{
		announceText.text = "";
		alertText.text = "";
		if (charaStatusMenu.activeInHierarchy)
		{
			characterMenuController.reset();
		}
		charaStatusMenu.SetActive(false);
		partyMenu.SetActive(false);
		inventory.SetActive(false);
		if (calendar.activeInHierarchy)
		{
			calendar.GetComponent<calendarController>().reset();
		}
		calendar.SetActive(false);
		questLog.SetActive(false);
		journal.SetActive(false);
		addEntryButton.SetActive(false);
		map.SetActive(false);
		achievementList.SetActive(false);
		optionsMenu.SetActive(false);
		submenuOpen = false;
	}

	public void exitGame()
	{
		Input.ResetInputAxes();
		SceneManager.LoadScene(0);
		Destroy(GameObject.FindGameObjectWithTag("data"));
	}

//	public void quitGame()
//	{
//		Input.ResetInputAxes();
//		PlayerPrefs.Save();
//		Application.Quit();
//	}
}