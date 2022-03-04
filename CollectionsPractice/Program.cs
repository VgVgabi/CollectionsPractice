using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;


namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arlist = new ArrayList();
            Stack<int> stackList = new Stack<int>();
            Queue<int> queueIds = new Queue<int>();
            Hashtable keyValueList = new Hashtable();
            bool breakFlag = false;
            bool arrayListBreakFlag = false;
            bool hashtableBreakFlag = false;
            bool queueBreakFlag = false;
            bool stackBreakFlag = false;
            //
            while (!breakFlag)
            {
                try
                {
                    Console.WriteLine("\nWhat data structure would you like to work with?\n1. ArrayList\n2. Hashtable\n3. Queue\n4. Stack\n5. Quit Program");
                    int userInput = int.Parse(Console.ReadLine());
                    //
                    switch (userInput)
                    {

                        case 1:
                            while (!arrayListBreakFlag)
                            {
                                void GetArrayList()
                                {
                                    foreach (var item in arlist)
                                        Console.WriteLine($"Current Array List RowS: {item}");
                                }
                                //
                                Console.WriteLine("\nWhat action would you like to take in Array List?\na - Add\nd - Remove\ne - Enumerate\nb - Contains\nc - Clear\nq - Quit");
                                string userActionListiner = Console.ReadLine().ToLower();
                                //
                                if (userActionListiner == "a")
                                {
                                    Console.WriteLine("Please, add an item:");
                                    object userItemAdd = Console.ReadLine();
                                    arlist.Add(userItemAdd);
                                    GetArrayList();
                                }
                                else if (userActionListiner == "d")
                                {
                                    Console.WriteLine("Which index element would you like to remove?");
                                    Console.WriteLine(arlist);
                                    int userItemRemove = int.Parse(Console.ReadLine());
                                    arlist.RemoveAt(userItemRemove);
                                }
                                else if (userActionListiner == "e")
                                {
                                    if (arlist.Count > 0)
                                    {
                                        GetArrayList();
                                    }
                                    else
                                        Console.WriteLine("There in no record for this Array List!");
                                }
                                else if (userActionListiner == "b")
                                {
                                    Console.WriteLine("What object would you like to check?");
                                    object obj = Console.ReadLine();
                                    if (arlist.Contains(obj) == true)
                                        Console.WriteLine("The Object is exist in Array List");
                                    else
                                        Console.WriteLine("The Object is not exist in Array List");
                                }
                                else if (userActionListiner == "c")
                                    arlist.Clear();
                                else if (userActionListiner == "q")
                                    arrayListBreakFlag = true;
                                else
                                {
                                    Console.WriteLine("Wrong choise, please try again");
                                }
                            }
                            arrayListBreakFlag = false;
                            break;
                        //
                        case 2:
                            while (!hashtableBreakFlag)
                            {
                                Console.WriteLine("\nWhat action would you like to take in Key Value List?\na - Add\nd - Remove\ne - Enumerate\nb - Contains\nc - Clear\nq - Quit");
                                string userActionListiner = Console.ReadLine().ToLower();
                                void GetKeyValueList()
                                {
                                    foreach (DictionaryEntry de in keyValueList)
                                        Console.WriteLine("Current HashTable Row: Key: {0}, Value: {1}", de.Key, de.Value);
                                }
                                //                            
                                if (userActionListiner == "a")
                                {
                                    try
                                    {
                                        Console.WriteLine("Set the Key please - number");
                                        int keyInput = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Set the Value please");
                                        var valueInput = Console.ReadLine();
                                        keyValueList.Add(keyInput, valueInput);
                                        GetKeyValueList();
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("The operation is failure!");
                                        GetKeyValueList();
                                    }
                                }
                                //
                                else if (userActionListiner == "d")
                                {
                                    try
                                    {
                                        Console.WriteLine("Which Key To Remove?");
                                        int keyInput = int.Parse(Console.ReadLine());
                                        keyValueList.Remove(keyInput);
                                        GetKeyValueList();
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("The operation is failure!");
                                        GetKeyValueList();
                                    }
                                }
                                //
                                else if (userActionListiner == "e")
                                {
                                    if (keyValueList.Values.Count != 0)
                                        GetKeyValueList();
                                    else
                                        Console.WriteLine("The is no exist record for Key Value List");
                                }
                                //
                                else if (userActionListiner == "b")
                                {
                                    Console.WriteLine("Please set the search input:");
                                    object obj = Console.ReadLine();
                                    if (keyValueList.ContainsValue(obj) == true)
                                        Console.WriteLine("The Object is exist in Key Value List");
                                    else
                                        Console.WriteLine("The Object is not exist in Key Value List");
                                }
                                //
                                else if (userActionListiner == "c")
                                {
                                    keyValueList.Clear();
                                }
                                //
                                else if (userActionListiner == "q")
                                {
                                    hashtableBreakFlag = true;
                                }
                                //
                                else
                                {
                                    Console.WriteLine("Wrong choise, please try again");
                                }
                            }
                            //
                            hashtableBreakFlag = false;
                            break;
                        //
                        case 3:
                            while (!queueBreakFlag)
                            {
                                Console.WriteLine("\nWhat action would you like to take in Queue Collection?\na - Add\nd - Remove\ne - Enumerate\nb - Contains\nc - Clear\nq - Quit");
                                string userActionListiner = Console.ReadLine().ToLower();
                                //
                                void GetQueueCollection()
                                {
                                    foreach (var id in queueIds)
                                        Console.WriteLine($"Current Queue List Row: <{id}>");
                                }
                                //
                                if (userActionListiner == "a")
                                {
                                    try
                                    {
                                        Console.WriteLine("Set a number please");
                                        int userInnerListiner = int.Parse(Console.ReadLine());
                                        //
                                        queueIds.Enqueue(userInnerListiner);
                                        GetQueueCollection();
                                    }
                                    catch
                                    {
                                        Console.WriteLine("The Add To Queue Operation Is Failure!");
                                    }
                                }
                                //
                                else if (userActionListiner == "d")
                                {
                                    if (queueIds.Count != 0)
                                    {
                                        Console.WriteLine("DO YOU SURE THAT YOU WANT TO DELETE? Y/N ");
                                        string UserAnswer = Console.ReadLine().ToLower();
                                        switch (UserAnswer)
                                        {
                                            case "y":
                                                queueIds.Dequeue();
                                                Console.WriteLine("Remove Operation Succeeded From First Limb!");
                                                break;
                                            //
                                            default:
                                                Console.WriteLine("Remove Operation Canceled!");
                                                break;
                                        }
                                    }
                                }
                                //
                                else if (userActionListiner == "e")
                                {
                                    if (queueIds.Count != 0)
                                        GetQueueCollection();
                                    else
                                        Console.WriteLine("There Is No Record In Queue List.");
                                }
                                //
                                else if (userActionListiner == "b")
                                {
                                    if (queueIds.Count != 0)
                                    {
                                        try
                                        {
                                            Console.WriteLine("Set The Search Input Please:");
                                            int userInnerListiner = int.Parse(Console.ReadLine().ToLower());
                                            bool searchStatus = queueIds.Contains(userInnerListiner);
                                            if (searchStatus == true)
                                                Console.WriteLine("The Element Exists In Queue List");
                                            else
                                                Console.WriteLine("The Element NOT Exists In Queue List");
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Checking element in Queue List Operation is failure!");
                                        }
                                    }
                                    else
                                        Console.WriteLine("There Is No Record In Queue List.");
                                }
                                //
                                else if (userActionListiner == "c")
                                {
                                    queueIds.Clear();
                                    Console.WriteLine("The Queue List Cleared!");
                                }
                                //
                                else if (userActionListiner == "q")
                                    queueBreakFlag = true;
                                else
                                    Console.WriteLine("Wrong choise, please try again");
                            }
                            //
                            queueBreakFlag = false;
                            break;
                        //
                        case 4:
                            while (!stackBreakFlag)
                            {
                                Console.WriteLine("\nWhat action would you like to take in Queue Collection?\na - Add\nd - Remove\ne - Enumerate\nb - Contains\nc - Clear\nq - Quit");
                                string userActionListiner = Console.ReadLine().ToLower();
                                void GetStackList()
                                {
                                    foreach (var item in stackList)
                                        Console.WriteLine($"Current Stack List Row: {item}");
                                }
                                //
                                if (userActionListiner == "a")
                                {
                                    Console.WriteLine("Set a number please:");
                                    int userInnerListiner = int.Parse(Console.ReadLine());
                                    //
                                    stackList.Push(userInnerListiner);
                                    GetStackList();
                                }
                                //
                                else if (userActionListiner == "d")
                                {
                                    if (stackList.Count != 0)
                                    {
                                        Console.WriteLine("DO YOU SURE THAT YOU WANT TO DELETE? Y/N ");
                                        string UserAnswer = Console.ReadLine().ToLower();
                                        switch (UserAnswer)
                                        {
                                            case "y":
                                                stackList.Pop();
                                                Console.WriteLine("Remove Operation Succeeded From First Limb!");
                                                break;
                                            //
                                            default:
                                                Console.WriteLine("Remove Operation Canceled!");
                                                break;
                                        }
                                    }
                                    else
                                        Console.WriteLine("No Record Found In Stack List.");
                                }
                                else if (userActionListiner == "e")
                                {
                                    if (stackList.Count != 0)
                                        GetStackList();
                                    else
                                        Console.WriteLine("No Record Found In Stack List.");
                                }
                                //
                                else if (userActionListiner == "b")
                                {
                                    if (stackList.Count != 0)
                                    {
                                        try
                                        {
                                            Console.WriteLine("Set The Search Input Please:");
                                            int userInnerListiner = int.Parse(Console.ReadLine().ToLower());
                                            bool searchStatus = stackList.Contains(userInnerListiner);
                                            if (searchStatus == true)
                                                Console.WriteLine("The Element Exists In Stack List");
                                            else
                                                Console.WriteLine("The Element NOT Exists In Stack List");
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Checking element in Stack List Operation is failure!");
                                        }
                                    }
                                    else
                                        Console.WriteLine("There Is No Record In Stack List.");
                                }
                                //
                                else if (userActionListiner == "c")
                                {
                                    stackList.Clear();
                                    Console.WriteLine("The Stack List Cleared!");
                                }
                                else if (userActionListiner == "q")
                                    stackBreakFlag = true;
                                else
                                    Console.WriteLine("Wrong choise, please try again");
                            }
                            //
                            stackBreakFlag = false;
                            break;
                        //
                        case 5:
                            breakFlag = true;
                            break;
                        //
                        default:
                            Console.WriteLine("Choose number between 1 - 5 please:");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("The Operation is failure!");
                }
            }
        }
    }
}