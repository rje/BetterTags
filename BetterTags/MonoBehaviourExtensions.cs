using UnityEngine;

namespace BetterTags
{
	public static class MonoBehaviourExtensions
	{

		public static Tag GetTag (MonoBehaviour bh)
		{
			var tag = bh.GetComponent<Tag> ();
			if (tag == null) {
				tag = bh.gameObject.AddComponent<Tag> ();
			}
			return tag;
		}

		public static void AddTag (this MonoBehaviour bh, string tagName)
		{
			var tag = GetTag (bh);
			tag.AddTag (tagName);
		}

		public static void RemoveTag (this MonoBehaviour bh, string tagName)
		{
			var tag = GetTag (bh);
			tag.RemoveTag (tagName);
		}

		public static bool HasTag (this MonoBehaviour bh, string tagName)
		{
			var tag = GetTag (bh);
			return tag.m_tagList.Contains (tagName.ToLower ());
		}
	}
}