/*
Complexity Analysis

Time complexity : O(M) to build the trie where M is total number of characters in
products For each prefix we find its representative node in O(len(prefix)) and dfs
to find words which is an O(1) operation. Thus the overall complexity is dominated
by the time required to build the trie.

In Java there is an additional complexity of O(m^2) due to Strings being immutable,
here m is the length of searchWord.

Space complexity : O(n). Here n is the number of nodes in the trie.
*/
public class Trie
{
    private class Node
    {
        internal bool IsWord { get; set;} = false;
        
        internal Dictionary<char, Node> Children { get; } = new ();
        
        internal List<string> Words { get; } = new ();
    }

    private Node _root = new ();

    public void Add(string s)
    {
        Node currentNode = _root;
        foreach (char c in s)
        {
            if (!currentNode.Children.ContainsKey(c)) currentNode.Children.Add(c, new ());
            currentNode = currentNode.Children[c];
            currentNode.Words.Add(s);
        }

        currentNode.IsWord = true;
    }

    public List<string> FindByPrefix(string prefix)
    {
        Node currentNode = _root;
        
        foreach (char c in prefix)
        {
            if (!currentNode.Children.ContainsKey(c)) return new ();
            currentNode = currentNode.Children[c];
        }
        
        return currentNode.Words;
    }
}
