using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BetterTags
{
	public class TagSystem
	{

		public static Dictionary<int, List<GameObject>> m_taggedObjects = new Dictionary<int, List<GameObject>> ();

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
			var hash = tag.GetHashCode ();
			if (!m_taggedObjects.ContainsKey (hash)) {
				m_taggedObjects [hash] = new List<GameObject> ();
			}
			var goList = m_taggedObjects [hash];
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
			var hash = tag.GetHashCode ();
			if (m_taggedObjects.ContainsKey (hash)) {
				var goList = m_taggedObjects [hash];
				goList.Remove (go);
			}
		}

		public static List<GameObject> AllGameObjectsForTag (string tagName)
		{
			var hash = tagName.ToLower ().GetHashCode();
			if (m_taggedObjects.ContainsKey (hash)) {
				return m_taggedObjects [hash];
			} else {
				return new List<GameObject> ();
			}
		}

		public static GameObject GameObjectForTag (string tagName)
		{
			var hash = tagName.ToLower ().GetHashCode();
			if (m_taggedObjects.ContainsKey (hash)) {
				var goList = m_taggedObjects [hash];
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