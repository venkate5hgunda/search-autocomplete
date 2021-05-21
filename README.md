# search-autocomplete
Search AutoComplete Code in C# using Trie

After indexing the below, list:
```
{ "the", "a", "aba", "abc", "restrict", "hi", "hello" }
```

When we search the following terms:
```
{ "t", "a", "resto", "b", ""}
```

These are the suggestions: 

```
Suggestions for t are:  the
Suggestions for a are:  a  aba  abc
Suggestions for resto are:
Suggestions for b are:
Suggestions for  are:   a   aba   abc   hello   hi   restrict   the
```
