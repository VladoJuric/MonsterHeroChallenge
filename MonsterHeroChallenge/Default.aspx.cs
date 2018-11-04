using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonsterHeroChallenge
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            Character hero = new Character();
            Character monster = new Character();

            hero.name = "Herkules";
            hero.DamageMax = 25;
            hero.Health = 100;
            hero.AttackBonus = 6;
            hero.Bonus = false;

            monster.name = "DarkShit";
            monster.DamageMax = 20;
            monster.Health = 100;
            monster.AttackBonus = 5;
            monster.Bonus = false;

            BattlePrint(hero, monster);
        }

        public void BattlePrint(Character hero, Character monster)
        {
            while (hero.Health > 0 && monster.Health > 0)
            {
                int attacHero = hero.Attack();
                int attacMonster = monster.Attack();

                if (monster.Health > 0 && hero.Health > 0)
                {
                    resultLabel.Text +=
                        $"Hero {hero.name} attack {monster.name} with {attacHero.ToString()} damage (bonus: {hero.Bonus.ToString()}) and {monster.name} defend Hero attact with {monster.Defend(attacHero).ToString()} armor and left with {monster.Health} health";
                }

                if (hero.Health > 0 && monster.Health > 0)
                {
                    resultLabel.Text +=
                        $"<br/>Monster {monster.name} attack {hero.name} with {attacMonster.ToString()} damage (bonus: {monster.Bonus.ToString()}) and {hero.name} defend Monster attact with {hero.Defend(attacMonster).ToString()} armor and left with {hero.Health} health<br/><br/>";
                }
            }

            if (monster.Health >= 0)
                winLabel.Text = $"{monster.name} winn battle with {hero.name} !!!";

            if (hero.Health >= 0)
                winLabel.Text = $"{hero.name} winn battle with {monster.name} !!!";
        }
    }

    class Character
    {
        //public Character ()
        //{
        //    this.Health = 100;
        //    this.DamageMax
        //}

        public string name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public int AttackBonus { get; set; }
        public bool Bonus { get; set; }

        Random rand = new Random();
        public int Attack()
        {
            int damage = 0;

            if (this.name == "DarkShit")
                damage = rand.Next(0, this.DamageMax);
            if (this.name == "Herkules")
                damage = rand.Next(0, this.DamageMax);

            if ((rand.Next(0, 1)) == 1)
            {
                damage += this.AttackBonus;
                this.Bonus = true;
            }

            return damage;
        }

        public int Defend(int damage)
        {
            int defend = 0;

            if (this.name == "DarkShit")
                defend = rand.Next(0, damage);
            if (this.name == "Herkules")
                defend = rand.Next(0, damage);

            this.Health -= damage - defend;

            return defend;
        }
    }
}