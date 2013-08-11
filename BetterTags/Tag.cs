using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BetterTags
{
	public class Tag : MonoBehaviour
	{

		public List<string> m_tagList = new List<string>();

		void Awake ()
		{
			for (var i = 0; i < m_tagList.Count; i++) {
				var tag = m_tagList [i];
				m_tagList [i] = tag.Trim ().ToLower ();
			}
			UpdateTagSystem ();
		}

		public void AddTag (string toAdd)
		{
			var tag = toAdd.ToLower ();
			if (!m_tagList.Contains (tag)) {
				RemoveFromTagSystem ();
				m_tagList.Add (tag);
				UpdateTagSystem ();
			}
		}

		public void RemoveTag (string toRemove)
		{
			var tag = toRemove.ToLower ();
			if (m_tagList.Contains (tag)) {
				RemoveFromTagSystem ();
				m_tagList.Remove (tag);
				UpdateTagSystem ();
			}
		}

		public List<string> GetTags ()
		{
			return m_tagList;
		}

		void OnDestroy ()
		{
			RemoveFromTagSystem ();
		}

		void OnDisable ()
		{
			RemoveFromTagSystem ();
		}

		void OnEnable() {
			UpdateTagSystem ();
		}

		void UpdateTagSystem ()
		{
			TagSystem.AddObject (this);
		}

		void RemoveFromTagSystem ()
		{
			TagSystem.RemoveObject (this);
		}
	}
}