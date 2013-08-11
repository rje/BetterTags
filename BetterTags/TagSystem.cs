using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BetterTags
{
	public class TagSystem
	{

		public static Dictionary<string, List<GameObject>> m_taggedObjects = new Dictionary<string, List<GameObject>> ();

		public static void Clear ()
		{
			m_taggedObjects.Clear ();
		}

		public static void AddObject (Tag tagObj)
		{
			var tags = tagObj.GetTags ();
			var go = tagObj.gameObject;
			foreach (var tag in tags) {
				AddObjectForTag (tag, go);
			}
		}

		static void AddObjectForTag (string tag, GameObject go)
		{
			if (!m_taggedObjects.ContainsKey (tag)) {
				m_taggedObjects [tag] = new List<GameObject> ();
			}
			var goList = m_taggedObjects [tag];
			if (!goList.Contains (go)) {
				goList.Add (go);
			}

		}

		public static void RemoveObject (Tag tagObj)
		{
			var tags = tagObj.GetTags ();
			var go = tagObj.gameObject;
			foreach (var tag in tags) {
				RemoveObjectForTag (tag, go);
			}
		}

		static void RemoveObjectForTag (string tag, GameObject go)
		{
			if (m_taggedObjects.ContainsKey (tag)) {
				var goList = m_taggedObjects [tag];
				goList.Remove (go);
			}
		}

		public static List<GameObject> AllGameObjectsForTag (string tagName)
		{
			var tag = tagName.ToLower ();
			if (m_taggedObjects.ContainsKey (tag)) {
				return m_taggedObjects [tag];
			} else {
				return new List<GameObject> ();
			}
		}

		public static GameObject GameObjectForTag (string tagName)
		{
			var tag = tagName.ToLower ();
			if (m_taggedObjects.ContainsKey (tag)) {
				var goList = m_taggedObjects [tag];
				if (goList.Count > 0) {
					return goList [0];
				} else {
					return null;
				}
			} else {
				return null;
			}
		}
	}
}