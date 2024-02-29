using System;
using System.Collections.Generic;

public class DirectoryStructure{
    public Dictionary<string, DirectoryStructure> Childs { get; set; }
    public DirectoryStructure(){
        Childs = new Dictionary<string, DirectoryStructure>();
    }
    public void Print(string indent = ""){
        foreach (var entry in Childs){
            Console.WriteLine($"{indent}{entry.Key}");
            entry.Value.Print(indent + " ");
        }
    }
}

class Program{
    static void Main(){
        Console.Write("Number of dirs: ");
        int n = int.Parse(Console.ReadLine());

        DirectoryStructure root = new DirectoryStructure();
        for (int i = 0; i < n; i++){
            string line = Console.ReadLine();
            line = line.Replace('\\', ' ');

            string[] directoryNames = line.Split(' ');
            DirectoryStructure current = root;

            foreach (string dirName in directoryNames){
                if (!current.Childs.ContainsKey(dirName))
                    current.Childs[dirName] = new DirectoryStructure();

                current = current.Childs[dirName];
            }
        }

        foreach (var entry in root.Childs){
            Console.WriteLine(entry.Key);
            entry.Value.Print(" ");
        }
    }
}
