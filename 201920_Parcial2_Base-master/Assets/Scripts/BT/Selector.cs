using UnityEngine;
using System.Collections;

namespace AI
{
	public abstract class Selector : Group 
	{
		public override void Execute ()
		{
			if (Check ())
				base.Execute ();
		}

		protected abstract bool Check ();
	}
}
