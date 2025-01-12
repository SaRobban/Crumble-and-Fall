﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public Animator transition;
	public float transistionTime = 1f;
	public AudioClip clickSound;
	private AudioSource audioSource;
    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }
    //public static GameSceneManager instance;  //Singleton instance

    //void Start()
    //{
    //	if (instance == null)
    //	{
    //		instance = this; //Save our object so we can use it easily
    //		DontDestroyOnLoad(gameObject);
    //	}
    //	else
    //	{
    //		Destroy(gameObject);   //If we already have an instance, avoid creating another.
    //	}
    //}

    public void ChangeScene(string name)
	{
		//PlaySound(clickSound);
		if (Time.timeScale < 1)
			Time.timeScale = 1;

		if(transition != null)
			StartCoroutine(ChangeSceneAnimation(name));
		else
			SceneManager.LoadScene(name);
	}

    IEnumerator ChangeSceneAnimation(string name)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transistionTime);
        SceneManager.LoadScene(name);
    }

    public void ReloadCurrentScene()
	{
		PlaySound(clickSound);
		if (Time.timeScale < 1)
			Time.timeScale = 1;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void LoadNextScene()
	{
		int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
		nextIndex = nextIndex % SceneManager.sceneCountInBuildSettings;

		if (Time.timeScale < 1)
			Time.timeScale = 1;

		SceneManager.LoadScene(nextIndex);
	}

	public void LoadPreviousScene()
	{
		if (Time.timeScale < 1)
			Time.timeScale = 1;

		int nextIndex = SceneManager.GetActiveScene().buildIndex - 1 + SceneManager.sceneCountInBuildSettings;
		nextIndex = nextIndex % SceneManager.sceneCountInBuildSettings;
		SceneManager.LoadScene(nextIndex);
	}

	public void QuitGame()
    {
		if (transition != null)
			StartCoroutine(Quit(1));		
		else
			Application.Quit();
	}

	IEnumerator Quit(float t)
    {
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(t);
		Application.Quit();
	}

	void PlaySound(AudioClip clip)
    {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = clip;
		audioSource.Play();
    }
}