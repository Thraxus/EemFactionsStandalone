﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EemFactions
{
	public interface IEemFaction
	{
		void DeclareWar(ulong playerFaction, ulong npcFaction);
		
	}
}
