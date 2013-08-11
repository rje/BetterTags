BetterTags
==========

A new tag system for Unity that gives you the flexibility you need.
-------------------------------------------------------------------

### Features over the built in unity tagging system:

* Tags can be defined at runtime, no need to maintain a canonical list.
* Objects can have multiple tags associated with them, leave layers for rendering & physics
* Case insensitive

How to use it?
--------------

### From the editor:

1. Import BetterTags into your project
2. On objects you want to tag, add a BetterUtils.Tag component
3. Add whatever initial tags you want to the Tag List property

![Editor Image](https://github.com/rje/BetterTags/raw/master/docs/image/sample.png)

### From code:

Adding/removing/checking tags:

```
  using BetterTag;

  var go = <some game object>;
  go.AddTag("my_new_tag");
  go.RemoveTag("some_other_tag");
  if(go.HasTag("conditional_tag")) {
    DoSomething();
  }
```

Finding things by tag:

```
  using BetterTag;

  GameObject obj = TagSystem.GameObjectForTag("other_tag_to_find");
  List<GameObject> objs = TagSystem.AllGameObjectsForTag("tag_to_find");
```

License
-------
All code available under the MIT license

Feedback
--------
Questions/Comments? Hit me up on twitter: [@rje](http://twitter.com/rje)

Fixes or feature additions? Send a pull request, happy to integrate them!
