﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSP
{
    public class Graph
    {

        public List<Transition> transitions = new List<Transition>();
        public List<char> nodes = new List<char>();
        public int nodeQuantity = 0;

        public Graph(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);
            Console.WriteLine("Reading file...");
            
            nodeQuantity = int.Parse(lines[0]);
            Console.Write(nodeQuantity);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                char nodeA = char.Parse(line[0]);
                char nodeB = char.Parse(line[1]);
                int cost = int.Parse(line[2]);

                if (!nodes.Contains(nodeA))
                {
                    nodes.Add(nodeA);
                }
                
                if (!nodes.Contains(nodeB))
                {
                    nodes.Add(nodeB);
                }
                
                Console.Write(nodeA + " " + nodeB + " " + cost + "\n");
                transitions.Add(new Transition(nodeA, nodeB, cost));
            }

        }

        public int GetCost(char nodeA, char nodeB)
        {
            foreach (Transition transition in transitions)
            {
                if ((transition.Node1 == nodeA && transition.Node2 == nodeB) || (transition.Node2 == nodeA && transition.Node1 == nodeB))
                {
                    return transition.Cost;
                }
            }
            return -1;
        }

        public int GetPathCost(List<char> path)
        {
            int cost = 0;
            for (int i = 0; i < path.Count - 1; i++)
            {
                cost += GetCost(path[i], path[i + 1]);
            }
            return cost;
        }

        public List<Transition> GetTransitions(char node)
        {
            List<Transition> transitions = new List<Transition>();
            foreach (Transition transition in this.transitions)
            {
                if (transition.Node1 == node || transition.Node2 == node)
                {
                    transitions.Add(transition);
                }
            }
            return transitions;
        }

        public int GetDistance(char nodeA, char nodeB)
        {
            foreach (Transition transition in transitions)
            {
                if ((transition.Node1 == nodeA && transition.Node2 == nodeB) || (transition.Node2 == nodeA && transition.Node1 == nodeB))
                {
                    return transition.Cost;
                }
            }
            return -1;
        }
    }
}
