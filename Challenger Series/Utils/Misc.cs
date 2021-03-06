﻿#region License
/* Copyright (c) LeagueSharp 2016
 * No reproduction is allowed in any way unless given written consent
 * from the LeagueSharp staff.
 * 
 * Author: LeagueSharp.Common Developers
 * Date: 2/21/2016
 * File: Misc.cs
 */
#endregion License

using System;
using System.Drawing;
using System.Linq;
using LeagueSharp;
using LeagueSharp.SDK;
using SharpDX;
using SharpDX.Text;
using Color = System.Drawing.Color;

namespace Challenger_Series.Utils
{
    public static class Misc
    {        /// <summary>
        ///     Returns true if the unit is under tower range.
        /// </summary>
        public static bool UnderTurret(this Obj_AI_Base unit)
        {
            return UnderTurret(unit.Position, true);
        }

        /// <summary>
        ///     Returns true if the unit is under turret range.
        /// </summary>
        public static bool UnderTurret(this Obj_AI_Base unit, bool enemyTurretsOnly)
        {
            return UnderTurret(unit.Position, enemyTurretsOnly);
        }

        public static bool UnderTurret(this Vector3 position, bool enemyTurretsOnly)
        {
            return
                ObjectManager.Get<Obj_AI_Turret>().Any(turret => turret.IsValidTarget(950, enemyTurretsOnly, position));
        }
        public static bool UnderAllyTurret(this Obj_AI_Base unit)
        {
            return UnderAllyTurret(unit.ServerPosition);
        }

        public static bool UnderAllyTurret(this Vector3 position)
        {
            return
                GameObjects.Get<Obj_AI_Turret>()
                    .Any(turret => turret.Position.Distance(position) < 950 && turret.IsAlly && turret.Health > 1);
        }
    }
}
