using System;
using System.Collections.Generic;

namespace Generics
{
    //not thread safe. TODO: Make it thread safe
    public class BinaryTree<T> where T: IComparable
    {
        private class BinaryTreeNode
        {
            public T info;
            public BinaryTreeNode left;
            public BinaryTreeNode right;
        }

        private enum FindDirection { None = 0, Left = 1, Right};

        private class FindNodeResult
        {
            public BinaryTreeNode parent = null;

            public BinaryTreeNode foundNode = null;

            public FindDirection direction = FindDirection.None; 
        }

        private BinaryTreeNode root = null;

        private FindNodeResult GetRightLeftMostNode(BinaryTreeNode startNode)
        {
            FindNodeResult retValue = new FindNodeResult{ parent = null, foundNode = startNode };
            if (startNode == null)
            {
                throw new ArgumentNullException("Invalid starting node.");    
            }

            retValue.foundNode = startNode.right;
            retValue.parent = startNode;
            retValue.direction = FindDirection.Right;

            while (retValue.foundNode.left != null)
            {
               retValue.parent = retValue.foundNode;
               retValue.foundNode = retValue.foundNode.left;
               retValue.direction = FindDirection.Left;     
            }

            return retValue;            
        }

            

        private FindNodeResult FindNode(T infoToFind)
        {
            FindNodeResult result = new FindNodeResult{ parent = null, foundNode = root };
            bool foundInfo = false;

            while (!foundInfo && result.foundNode != null)
            {
                var compareResult = infoToFind.CompareTo(result.foundNode.info);
                if (compareResult > 0)
                {
                    result.parent = result.foundNode;
                    result.foundNode = result.foundNode.right; 
                    result.direction = FindDirection.Right;   
                }
                else if (compareResult < 0)
                {
                    result.parent = result.foundNode;
                    result.foundNode = result.foundNode.left;
                    result.direction = FindDirection.Left;    
                }
                else
                {
                    foundInfo = true;
                }    
            }

            return result;

        }

        private void DumpElementsInList(BinaryTreeNode startNode, List<T> destList)
        {
            if (startNode == null)
                return;
            destList.Add(startNode.info);
            DumpElementsInList(startNode.left, destList);
            DumpElementsInList(startNode.right, destList);
        }

        public void Add(T infoToAdd)
        {
            
            int compareResult;
            if (root == null)
            {
               root = new BinaryTreeNode();
               root.info = infoToAdd;     
            }
            else
            {
                var currentNode = root;
                BinaryTreeNode prevNode = null;
                while(currentNode != null)
                {
                    prevNode = currentNode;
                    compareResult = infoToAdd.CompareTo(currentNode.info);
                    if (compareResult > 0)
                    {
                        currentNode = currentNode.right;
                    }
                    else if (compareResult < 0)
                    {
                        currentNode = currentNode.left;      
                    }
                    else
                    {
                        throw new DuplicateTreeInfoException();
                    }
                }

                var nodeToAdd = new BinaryTreeNode { info = infoToAdd };
                compareResult = infoToAdd.CompareTo(prevNode.info);
                if (compareResult > 0)
                {
                    prevNode.right = nodeToAdd;
                }
                else
                {
                    prevNode.left = nodeToAdd;
                }
            }
        }

        public void Remove(T infoToRemove)
        {
            FindNodeResult findResult = FindNode(infoToRemove);
            var foundNode = findResult.foundNode;
            if (foundNode == null)
            {
                throw new InformationNotFoundException();
            }

            if (foundNode.left == null && foundNode.right == null)
            {
                if (findResult.parent != null)
                {
                    if (findResult.direction == FindDirection.Left)
                    {
                        findResult.parent.left = null;
                    }
                    else
                    {
                        findResult.parent.right = null;
                    }
                }
                else
                {
                    root = null;
                }
            }
            else if (foundNode.left == null)
            {
                if (findResult.direction == FindDirection.Left)
                {
                    findResult.parent.left = foundNode.right;    
                }
                else
                {
                    findResult.parent.right = foundNode.right;
                }
            } 
            else if (foundNode.right == null)
            {
                if (findResult.direction == FindDirection.Left)
                {
                    findResult.parent.left = foundNode.left;    
                }
                else
                {
                    findResult.parent.right = foundNode.left;
                } 
            }
            else
            {
               var leftMostResult = GetRightLeftMostNode(foundNode);
               foundNode.info = leftMostResult.foundNode.info;
               if (leftMostResult.direction == FindDirection.Left)
               {
                   leftMostResult.parent.left = null;
               } 
               else
               {
                   leftMostResult.parent.right = null;
               }    
            }
        }

        public void Update(T infoToUpdate)
        {

        }

        T FindInfo(T infoToFind)
        {
             
            var findResult = FindNode(infoToFind);
            if (findResult.foundNode != null)
            {
                return findResult.foundNode.info;    
            }

            throw new InformationNotFoundException();
        }

        public IEnumerable<T> ToList()
        {
                List<T> list = new List<T>();
                DumpElementsInList(root, list);
                return list.AsReadOnly();
        }

    }

}