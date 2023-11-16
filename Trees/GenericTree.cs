
using System;

//TODO #1: Copy your GenericList<T> class from last project and add the file GenericList.cs to this project.

public class GenericTreeNode<T>
{
    private T Value;
    private GenericList<GenericTreeNode<T>> Children;


    public GenericTreeNode(T value)
    {
        //TODO #2: Initialize member variables/attributes
        Value = value;
        Children = new GenericList<GenericTreeNode<T>>();
        
    }

    public string AsString(int depth)
    {
        string output = null;
        string leftSpace = null;
        for (int i = 0; i < depth; i++) leftSpace += " ";
        if (leftSpace != null) leftSpace += "->";

        output += $"{leftSpace}[{Value}]\n";

        for (int childIndex = 0; childIndex < Children.Count(); childIndex++)
        {
            GenericTreeNode<T> child = Children.Get(childIndex);
            output += child.AsString(depth + 1);
        }
        return output;
    }

    public GenericTreeNode<T> Add(T value)
    {
        //TODO #3: Add a new instance of class GenericTreeNode<T> with Value=value. Return the instance we just created
        GenericTreeNode<T> child = new GenericTreeNode<T>(value);
        Children.Add(child);
        return child;
    }

    public int Count()
    {
        //TODO #4: Return the total number of elements in this tree
        int contador = 1;
        for (int i = 0; i < Children.Count(); i++)
        {
            contador+= Children.Get(i).Count();
        }
        return contador;
    }

    public int Depth()
    {
        //TODO #5: Return the depth of this tree

        int contador = 0;
        for(int i = 0; i < Children.Count();i++)
        {
            int depth = Children.Get(i).Depth();
            if(depth > contador)
            {
                contador = depth;
            }
        }
        return 1 + contador;
    }

    

    public void Remove(T value)
    {
        //TODO #6: Remove the child node that has Value=value. We only check children nodes for this value. If it's not found, do nothing
        for(int i = 0; i < Children.Count(); i++)
        {
            if (Children.Get(i).Value.Equals(value))
            {
                Children.Remove(i);
            }
            else
            {
                Children.Get(i).Remove(value);
            }
        }
      
    }
}

public class GenericTree<T>
{
    public GenericTreeNode<T> RootNode = null;

    public string AsString()
    {
        if (RootNode == null)
            return null;
        else return RootNode.AsString(0);
    }
}


