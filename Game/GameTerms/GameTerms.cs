
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using CardGame.Game.GameTerms.Cards.Utility;
using CardGame.Game.GameTerms;

namespace CardGame.Game.GameTerms
{
   
    public class Ownerable
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public Player Owner { get; set; }

        public void init(Player Owner ,string name, string des)
        {
            this.Description = des;
            this.Name = name;
            this.Owner = Owner;
        }

        public Ownerable(Player Owner ,string name, string des)
        {
            init(Owner, name, des);
        }

        public Ownerable(string name,string des )
        {
            init(null,name,des );
        }

        public Ownerable()
        {
            init(null, "A card", "This is a object");
        }

    }
    public class ObjectOnMap : Ownerable
    {
        public GameNode loc { set; get; }
        public ObjectOnMap(GameNode loc,Player Owner, string name, string des): base(Owner,name,des)
        {
            this.loc = loc;
        }
    }
   // public enum Role { Police, Scientist, Dissident }

    public class MapNode
    {
        public List<MapNode> Neighbors;

        public MapNode() { Neighbors = new List<MapNode>(); }
        public MapNode(List<MapNode> neighbors)
        {
            Neighbors = neighbors;
        }

        public void AddNeighbor(MapNode node) { Neighbors.Add(node); }
        public void RemoveNeighbor(MapNode node) { Neighbors.Remove(node); }
        public bool IsNear(MapNode node)
        {
            return Neighbors.Contains(node);
        }

    }

    public class GameNode : MapNode
    {
        public int tensionLevel { get; set; }
        public bool isLockDown { get; set; }

        public bool IsOpenTo(Unit unit)
        {
            if (unit.GetType() == typeof(Dissident))
            {
                return !isLockDown;
            }
            return true;
        }
    }
    public class PoliceDepartment : GameNode { }
    public class Prison : GameNode { }
    public class Lab : GameNode { }
    public class Place : GameNode
    {
        int Unrest;
        public int unrest
        {
            get { return Unrest; }
            set { if (value < 0) Unrest = 0; if (value > 3) Unrest = 3; }
        }

        public bool hasCollected;

    }

}
