using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	public class ObjectPooler : MonoBehaviour
	{

		public static ObjectPooler Instance;

		public bool mutualizeWaitingPools = true;

		protected GameObject _waitingPool;

	    protected virtual void Awake()
	    {
			Instance = this;
			FillObjectPool();
	    }

		protected virtual void CreateWaitingPool()
		{
			if (!mutualizeWaitingPools)
			{
				_waitingPool = new GameObject(DetermineObjectPoolName());
				return;
			}
			else
			{
				GameObject waitingPool = GameObject.Find (DetermineObjectPoolName ());
				if (waitingPool != null)
				{
					_waitingPool = waitingPool;
				}
				else
				{
					_waitingPool = new GameObject(DetermineObjectPoolName());
				}
			}
		}

		protected virtual string DetermineObjectPoolName()
		{
			return ("[ObjectPooler] " + this.name);	
		}


	    protected virtual void FillObjectPool()
	    {
	        return ;
	    }


		public virtual GameObject GetPooledGameObject()
	    {
	        return null;
	    }
	}
