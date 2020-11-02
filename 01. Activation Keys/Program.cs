using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeGenerate = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(">>>").ToArray();

            List<string> corection = new List<string>();

            for (int i = 0; i < codeGenerate.Length; i++)
            {
                string currentLetter = codeGenerate[i].ToString();
                corection.Add(currentLetter);
            }
           
            while (commands[0]!= "Generate")
            {

                StringBuilder messages = new StringBuilder();
                
                if (commands[0]== "Contains")
                {
                    if(codeGenerate.Contains(commands[1]))
                    {
                        messages.AppendLine($"{codeGenerate} contains {commands[1]}.");
                    }
                    else
                    {
                        messages.AppendLine("Substring not found!");
                    }
                }
                else if(commands[0]=="Flip")
                {
                    if(commands[1]=="Upper")
                    {
                        for (int i = int.Parse(commands[2]); i < int.Parse(commands[3]); i++)
                        {

                            corection[i] = corection[i].ToUpper();

                        }

                        messages.AppendLine(string.Join("", corection));

                    }
                    else if (commands[1]== "Lower")
                    {
                        for (int i = int.Parse(commands[2]); i < int.Parse(commands[3]); i++)
                        {

                            corection[i] = corection[i].ToLower();

                        }

                        messages.AppendLine(string.Join("",corection));
                    }
                }
                else if(commands[0]== "Slice")
                {
                    for (int i = int.Parse(commands[1]); i < int.Parse(commands[2]); i++)
                    {
                        corection.RemoveAt(int.Parse(commands[1]));
                    }
                    messages.AppendLine(string.Join("", corection));
                }
                Console.Write(messages);

                codeGenerate = string.Join("", corection);

                commands = Console.ReadLine().Split(">>>").ToArray();
            }

            Console.WriteLine($"Your activation key is: {string.Join("",corection)}");

        }
    }
}