using Common;

public class GenericListNode<T>
{
    public T Value;
    public GenericListNode<T> Next = null;

    public GenericListNode(T value)
    {
      Value = value;
    }

    public override string ToString()
    {
      return Value.ToString();
    }
}

public class GenericList<T> : IGenericList<T>
{
    GenericListNode<T> First = null;
    GenericListNode<T> Last = null;
    private int NumElements = 0;


    public string AsString()
    {
      GenericListNode<T> node = First;
      string output = "[";

      while (node != null)
      {
        output += node.ToString() + ",";
        node = node.Next;
      }
      output = output.TrimEnd(',') + "] " + Count() + " elements";
      
      return output;
    }

    public void Add(T value)
    {
        //TODO #1: add a new element to the end of the list
        if (First == null)
        {
            First = new GenericListNode<T>(value);
        }
        else
        {
            Last = First;
            while (Last.Next != null)
            {
                Last = Last.Next;
            }
            Last.Next = new GenericListNode<T>(value);

        }
        NumElements++;
    }

    public GenericListNode<T> FindNode(int index)
    {
        //TODO #2: Return the element in position 'index'

        if (index == 0)
        {
            return First;
        }
        else
        {
            GenericListNode<T> current = First;
            for (int i = 0; i < index && current != null; i++)
            {
                current = current.Next;
            }

            return current;
        }
    }

    public T Get(int index)
    {
        //TODO #3: return the element on the index-th position. YOU MUST USE GetNode(int). Return the default value for object class T if the position is out of bounds
        if ((index < 0) || (index >= Count()))
        {
            return default(T);
        }
        else
        {
            GenericListNode<T> node = FindNode(index);
            return node.Value;
        }
         
    }
    public int Count()
    {
        //TODO #4: return the number of elements on the list

        return NumElements;
    }


    public void Remove(int index)
    {
        //TODO #5: remove the element on the index-th position. Do nothing if position is out of bounds
        if (index < 0)
        {
            return;
        }

        if (index == 0)
        {
            First = First.Next;
        }
        else
        {
            GenericListNode<T> previous = FindNode(index - 1);
            if (previous != null && previous.Next != null)
            {
                previous.Next = previous.Next.Next;
            }
        }
        NumElements--;
    }

    public void Clear()
    {
        //TODO #6: remove all the elements on the list
        First = null;
        NumElements = 0;
    }
}