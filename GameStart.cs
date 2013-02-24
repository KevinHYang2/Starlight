﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWorld;

namespace HelloWorld
{
    public class GameMain
    {
        Boolean gameRunning = false;
        Boolean gameStatus;
        Dictionary<int, Room> RoomHold = new Dictionary<int, Room>(); // <id, Room>
        Dictionary<int, int> RoomNumbers = new Dictionary<int, int>(); // <id, room number>

        Agent JamesBond = new Agent();
        Wumpus TheBeast = new Wumpus();
        Bat SuperBats = new Bat();
        Pit Pit1 = new Pit();
        Pit Pit2 = new Pit();

        //some getters for the Rooms, Agent, Wumpus, and Bats. Debug purposes.
        public Dictionary<int, Room> getRooms()
        {
            return RoomHold;
        }
        
        public Agent getAgent()
        {
            return JamesBond;
        }

        public Wumpus getWumpus()
        {
            return TheBeast;
        }

        public Bat getBats()
        {
            return SuperBats;
        }

        public Pit[] getPits()
        {
            return new Pit[2] {Pit1, Pit2};
        }

        public void init()
        {
            InitiateRooms();
            LinkRooms();
            RandomizeRooms();
            CycleCreature();
        }

        private void InitiateRooms()
        {
            for (int i = 1; i <= 20; i++)
            {
                RoomHold.Add(i, new Room());
                RoomHold[i].setId(i);
            }
        }

        private void LinkRooms()
        {
            for (int i = 1; i <= 20; i++)
            {
                switch (i)
                {
                    case 1:
                        RoomHold[i].setBack(RoomHold[6]);
                        RoomHold[i].setLeft(RoomHold[5]);
                        RoomHold[i].setRight(RoomHold[2]);
                        break;
                    case 2:
                        RoomHold[i].setBack(RoomHold[8]);
                        RoomHold[i].setLeft(RoomHold[1]);
                        RoomHold[i].setRight(RoomHold[3]);
                        break;
                    case 3:
                        RoomHold[i].setBack(RoomHold[10]);
                        RoomHold[i].setLeft(RoomHold[2]);
                        RoomHold[i].setRight(RoomHold[4]);
                        break;
                    case 4:
                        RoomHold[i].setBack(RoomHold[20]);
                        RoomHold[i].setLeft(RoomHold[3]);
                        RoomHold[i].setRight(RoomHold[5]);
                        break;
                    case 5:
                        RoomHold[i].setBack(RoomHold[18]);
                        RoomHold[i].setLeft(RoomHold[4]);
                        RoomHold[i].setRight(RoomHold[1]);
                        break;
                    case 6:
                        RoomHold[i].setBack(RoomHold[13]);
                        RoomHold[i].setLeft(RoomHold[1]);
                        RoomHold[i].setRight(RoomHold[7]);
                        break;
                    case 7:
                        RoomHold[i].setBack(RoomHold[11]);
                        RoomHold[i].setLeft(RoomHold[6]);
                        RoomHold[i].setRight(RoomHold[8]);
                        break;
                    case 8:
                        RoomHold[i].setBack(RoomHold[9]);
                        RoomHold[i].setLeft(RoomHold[7]);
                        RoomHold[i].setRight(RoomHold[2]);
                        break;
                    case 9:
                        RoomHold[i].setBack(RoomHold[12]);
                        RoomHold[i].setLeft(RoomHold[8]);
                        RoomHold[i].setRight(RoomHold[10]);
                        break;
                    case 10:
                        RoomHold[i].setBack(RoomHold[17]);
                        RoomHold[i].setLeft(RoomHold[9]);
                        RoomHold[i].setRight(RoomHold[3]);
                        break;
                    case 11:
                        RoomHold[i].setBack(RoomHold[14]);
                        RoomHold[i].setLeft(RoomHold[7]);
                        RoomHold[i].setRight(RoomHold[12]);
                        break;
                    case 12:
                        RoomHold[i].setBack(RoomHold[16]);
                        RoomHold[i].setLeft(RoomHold[11]);
                        RoomHold[i].setRight(RoomHold[9]);
                        break;
                    case 13:
                        RoomHold[i].setBack(RoomHold[18]);
                        RoomHold[i].setLeft(RoomHold[6]);
                        RoomHold[i].setRight(RoomHold[14]);
                        break;
                    case 14:
                        RoomHold[i].setBack(RoomHold[15]);
                        RoomHold[i].setLeft(RoomHold[13]);
                        RoomHold[i].setRight(RoomHold[11]);
                        break;
                    case 15:
                        RoomHold[i].setBack(RoomHold[19]);
                        RoomHold[i].setLeft(RoomHold[14]);
                        RoomHold[i].setRight(RoomHold[16]);
                        break;
                    case 16:
                        RoomHold[i].setBack(RoomHold[17]);
                        RoomHold[i].setLeft(RoomHold[15]);
                        RoomHold[i].setRight(RoomHold[12]);
                        break;
                    case 17:
                        RoomHold[i].setBack(RoomHold[20]);
                        RoomHold[i].setLeft(RoomHold[16]);
                        RoomHold[i].setRight(RoomHold[10]);
                        break;
                    case 18:
                        RoomHold[i].setBack(RoomHold[19]);
                        RoomHold[i].setLeft(RoomHold[5]);
                        RoomHold[i].setRight(RoomHold[13]);
                        break;
                    case 19:
                        RoomHold[i].setBack(RoomHold[20]);
                        RoomHold[i].setLeft(RoomHold[18]);
                        RoomHold[i].setRight(RoomHold[15]);
                        break;
                    case 20:
                        RoomHold[i].setBack(RoomHold[19]);
                        RoomHold[i].setLeft(RoomHold[17]);
                        RoomHold[i].setRight(RoomHold[4]);
                        break;
                }
            }
        }

        private void RandomizeRooms()
        {
            
            Random rand = new Random();
            int[] roomNumbers = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
            Random rnd = new Random();

            //shuffle numbers 1-20 using the Fisher-Yates shuffle algorithm
            //this will provide us with the room ids in random order
            for (int i = roomNumbers.Length; i > 1; i--)
            {
                int pos = rnd.Next(i);
                var x = roomNumbers[i - 1];
                roomNumbers[i - 1] = roomNumbers[pos];
                roomNumbers[pos] = x;
            }            

            //insert shuffled room numbers into the room indexes
            for (int i = 1; i <= 20; i++)
            {
                RoomHold[i].setRoomNum(roomNumbers[i-1]);
            }
        }

        //edit to return room when it places creature
        private Room PlaceCreature(Creature myCreature)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(1,20);

            if (RoomHold[randomIndex].getCreature() == null)
            {
                RoomHold[randomIndex].setCreature(myCreature);
                return RoomHold[randomIndex];
            }
            else
            {
                return null;
            }
        }

        private void CycleCreature()
        {
            Boolean agentPlaced = true;
            Boolean wumpusPlaced = true;
            Boolean batPlaced = true;
            Boolean pit1Placed = true;
            Boolean pit2Placed = true;
            Room tmp = null;

            //editted to tell the creature what room is is
            while (agentPlaced)
            {
                tmp = PlaceCreature(JamesBond);
                if (tmp != null)
                {
                    JamesBond.setRoom(tmp);
                    agentPlaced = false;
                } 
                //agentPlaced = PlaceCreature(JamesBond);
            }

            while (wumpusPlaced)
            {
                tmp = PlaceCreature(TheBeast);
                if (tmp != null)
                {
                    TheBeast.setRoom(tmp);
                    wumpusPlaced = false;
                } 
                //wumpusPlaced = PlaceCreature(TheBeast);
            }

            while (batPlaced)
            {
                tmp = PlaceCreature(SuperBats);
                if (tmp != null)
                {
                    SuperBats.setRoom(tmp);
                    batPlaced = false;
                } 
                //batPlaced = PlaceCreature(SuperBats);
            }

            while (pit1Placed)
            {
                tmp = PlaceCreature(Pit1);
                if (tmp != null)
                {
                    Pit1.setRoom(tmp);
                    pit1Placed = false;
                } 
                //pit1Placed = PlaceCreature(Pit1);
            }

            while (pit2Placed)
            {
                tmp = PlaceCreature(Pit2);
                if (tmp != null)
                {
                    Pit2.setRoom(tmp);
                    pit2Placed = false;
                } 
                //pit2Placed = PlaceCreature(Pit2);
            }

/*            RoomHold[1].setCreature(JamesBond);
            JamesBond.setRoom(RoomHold[1]);

            RoomHold[2].setCreature(TheBeast);

            RoomHold[3].setCreature(SuperBats);

            RoomHold[4].setCreature(Pit1);

            RoomHold[5].setCreature(Pit2);*/

        }

        private void GameCycle()
        {
            
        }
    }
}