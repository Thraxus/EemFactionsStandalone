using System;
using Sandbox.ModAPI;
using VRage.Game.Components;

// ReSharper disable once ClassNeverInstantiated.Global
namespace EemFactions
{
	[MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
	public class FactionsCore : MySessionComponentBase
	{

		// Fields
		private bool _registerEarly;
		private bool _registerLate;
		private bool _initialized;

		// Properties
		public static bool IsServer => MyAPIGateway.Multiplayer.IsServer;


		// Methods
		private void Initialize()
		{
			_initialized = true;
		}


		private void RegisterEarly()
		{
			if (!IsServer || _registerEarly) return;
			//GeneralLog = new Log(GeneralLogName);
			//ProfilerLog = new Log(ProfilerLogName);
			//Messaging.Register();
			//GameSettings.Register();
			//MyAPIGateway.Utilities.InvokeOnGameThread(() => SetUpdateOrder(MyUpdateOrder.BeforeSimulation));
			//Random = new Random();
			//GeneralLog.WriteToLog("Core", $"RegisterEarly Complete... {UpdateOrder}");
			_registerEarly = true;
		}

		private void RegisterLate()
		{
			if (!IsServer || _registerLate) return;
			//Definitions.Register();
			//Drones.Drones.Register();
			//MyAPIGateway.Utilities.InvokeOnGameThread(() => SetUpdateOrder(MyUpdateOrder.NoUpdate));
			//GeneralLog.WriteToLog("Core", $"RegisterLate Complete... {UpdateOrder}");
			_registerLate = true;
		}

		private static void Close()
		{
			if (!IsServer) return;
			//GeneralLog.WriteToLog("Core", "Unloading...");
			//CubeProcessing.Close();
			//Drones.Drones.Close();
			//Definitions.Close();
			//Messaging.Close();
			//ProfilerLog.Close();
			//GeneralLog.Close();
		}

		/// <summary>
		/// Runs every tick before the simulation is updated
		/// </summary>
		public override void UpdateBeforeSimulation()
		{
			base.UpdateBeforeSimulation();
			if (!_initialized) Initialize();
		}

		public override void BeforeStart()
		{
			base.BeforeStart();
			if (!IsServer || _registerEarly) return;
			//RegisterEarly();
		}
		
		protected override void UnloadData()
		{
			Close();
		}
	}
}