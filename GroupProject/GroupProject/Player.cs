using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class Player
    {
        //declare constants DMG1, DMG2, DMG3, DMGS, DMGL
        const int DMG1 = 10;
        const int DMG2 = 20;
        const int DMG3 = 30;
        const int DMGS = 50;
        const int DMGL = 5;

        //declare BLOCK25, BLOCK50, BLOCKF, CHARGEDAM
        const double BLOCKHALF = .5;
        const double BLOCKQUART = .75;
        const double BLOCKFAIL = 1;
        const double CHARGEDAM = 1.5;
        const double CRITBLOCK = .1;

        //declare constant for CHARGE1, CHARGE2, CHARGE3
        const int CHARGE1 = 1;
        const int CHARGE2 = 2;
        const int CHARGE3 = 3;
        const int SCHARGE = 4;
        //declare int health string name int charge,
        int health;
        string name;
        int charge;
        bool wait = false;
        int damage;
        double blockDamage = 1;
        double chargeDamage = 1;

        //declare Random RNGSUS(RNGsus)

        Random chance = new Random();
        //set up properties for health, name, and charge, damage, blockDamage,chargeDamage

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public double BlockDamage
        {
            get { return blockDamage; }
            set { blockDamage = value; }
        }

        public double ChargeDamage
        {
            get { return chargeDamage; }
            set { chargeDamage = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Charge
        {
            get { return charge; }
            set { charge = value; }
        }
        public bool Wait
        {
            get { return wait; }
            set { wait = value; }
        }

        
        //default constructor;
        public Player()
        {
            health = 100;
        }
         


        //Attack Method
        //Determines how much damage is going to be used
        //parameters: int attackType
        //return: int damage
        public void  Attack(int attackType, out string attackName)
        {


            //if attackType equals attack1, set damage to ATTACK1, subtract 1 charge
            if (attackType == 1) { damage = DMG1; charge--; attackName = "Attack 1"; }

            //if attackType equals attack2, set damage to ATTACK2, subtract 2 charges
            else if (attackType == 2 && charge >= CHARGE2) { damage = DMG2; charge -= CHARGE2; attackName = "Attack 2"; }

            //if attackType equals attack3, set damage to ATTACK3, subtract 3 charges
            else if (attackType == 3 && charge >= CHARGE3) { damage = DMG3; charge -= CHARGE3; attackName = "Attack 3"; }


            //if attackType equals specialAttack, set damage to SPECIALATTACK, subtract 3 charges, set wait to true
            else if (attackType == 4 && charge >= SCHARGE)
            {
                damage = DMGS;
                charge -= CHARGE3;
                wait = true;
                attackName = "Special Attack";

            }

            //if attackType equals weakAttack, set damage to WEAKATTACK
            else if (attackType == 5)
            {
                damage = DMGL;
                attackName = "Weak attack";
            }
            else
            {
                Console.WriteLine("What did you do? this shouldn't happen!");
                attackName = "error404: attack not found";
            }
            


        }


        //Block Method
        //Determines how much damage to block
        //Parameters: none
        //Return int damageTaken
        public void Block()
        {

            //damageTaken declared
            double damageTaken = 1;
            int random;
            //takes random value between 1 & 100
            random = chance.Next(1, 101);

            //if value is 1-50, set damageTaken to .5
            if (random <= 50) damageTaken = BLOCKQUART;
            //if value = 51-75, set damageTaken to .25
            if (random >= 51 && random <= 75) damageTaken = BLOCKHALF;
            //if value = 76-95, set damageTaken to 1
            if (random >= 76 && random <= 95) damageTaken = BLOCKFAIL;
            //if value = 96-100, set damageTaken to .1
            if (random >= 96 && random <= 100) damageTaken = CRITBLOCK;
            
                //return damageTaken
            blockDamage = damageTaken;


        }

        //Name: Charge
        //purpose: gain an extra charge, but takes extra damage
        //Parameters: none
        //returns: damage taken
        //Dev: Morgan
        public void ExtraCharge()
        {

            //double damage taken set to CHARGEDAM
             chargeDamage = CHARGEDAM;
            //charge incremented by one
            charge++;
            //return damageTaken
                        
        }




        //Name: GainCharge
        //purpose: give Charge to each 
        //Parameters: none
        //returns: none
        //Dev: Morgan
        public void GainCharge()
        {
            //charge incremented by one
            charge++;
        }

        
    }
}
