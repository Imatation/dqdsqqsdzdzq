﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using DRAVEN_Draven.MyUtils;
using Color = System.Drawing.Color;

namespace DRAVEN_Draven.MyLogic.Others
{
    public static partial class Events
    {
        public static void OnDraw(EventArgs args)
        {
            foreach (var hero in HeroManager.Enemies.Where(h => h.IsValidTarget() && h.Distance(Heroes.Player) < 1400))
            {
                var AADMG = Heroes.Player.GetAutoAttackDamage(hero) + Program.Q.GetDamage(hero);
                var AAOnly = (int)(hero.Health / AADMG);
                Drawing.DrawText(hero.HPBarPosition.X + 5, hero.HPBarPosition.Y - 30,
                    AAOnly <= 3 ? Color.Gold : Color.White,
                    "AAs to kill: " + AAOnly);
            }

            if (Program.DrawingsMenu.Item("drawenemywaypoints").GetValue<bool>())
            {
                foreach (var e in HeroManager.Enemies.Where(en => en.IsVisible && !en.IsDead && en.Distance(Heroes.Player) < 2500))
                {
                    var ip = Drawing.WorldToScreen(e.Position); //start pos

                    var wp = Utility.GetWaypoints(e);
                    var c = wp.Count - 1;
                    if (wp.Count() <= 1) break;

                    var w = Drawing.WorldToScreen(wp[c].To3D()); //endpos

                    Drawing.DrawLine(ip.X, ip.Y, w.X, w.Y, 2, Color.Red);
                }
            }
        }
    }
}