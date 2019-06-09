/*
Copyright (C) Jeff Campbell - All Rights Reserved
Unauthorized copying of this file, via any medium is strictly prohibited
Proprietary and confidential
Written by Jeff Campbell <mirraraenn@gmail.com>, 2019
*/
using UnityEngine;

namespace JCMG.Utility
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		public void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}
