using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


[Serializable]
	public class MultipleObjectPoolerObject
	{
		public GameObject GameObjectToPool;
		public int PoolSize;
		public bool PoolCanExpand = true;
		public bool Enabled = true;
	}

	public enum PoolingMethods { RandomPoolSizeBased }

	public class MultipleObjectPooler : ObjectPooler
	{
		public List<MultipleObjectPoolerObject> Pool;
		public PoolingMethods PoolingMethod = PoolingMethods.RandomPoolSizeBased;
		public bool CanPoolSameObjectTwice=false;

		protected List<GameObject> _pooledGameObjects;
		protected List<GameObject> _pooledGameObjectsOriginalOrder;
		protected List<MultipleObjectPoolerObject> _randomizedPool;
		protected string _lastPooledObjectName;
		protected int _currentIndex=0;


		protected override string DetermineObjectPoolName()
		{
			return ("Multiple " + name);	
		}

		protected override void FillObjectPool()
		{
			CreateWaitingPool ();

			_pooledGameObjects = new List<GameObject>();

			_randomizedPool = new List<MultipleObjectPoolerObject>() ;
			for (int i = 0; i < Pool.Count; i++)
			{
				_randomizedPool.Add(Pool[i]);
			}
			_randomizedPool.Shuffle();


			if (Pool.Count <= 1)
			{
				CanPoolSameObjectTwice=true;
			}

			switch (PoolingMethod)
			{								
				default:
					int k = 0;

					foreach (MultipleObjectPoolerObject pooledGameObject in Pool)
					{
					    if (k > Pool.Count)
					    {
					        return;
					    }
						for (int j = 0; j < Pool[k].PoolSize; j++)
						{
							AddOneObjectToThePool(pooledGameObject.GameObjectToPool);
						}
						k++;
					}
					break;
			}
		}
		protected virtual GameObject AddOneObjectToThePool(GameObject typeOfObject)
		{
			GameObject newGameObject = (GameObject)Instantiate(typeOfObject);
			newGameObject.gameObject.SetActive(false);
			newGameObject.transform.SetParent(_waitingPool.transform);
			newGameObject.name=typeOfObject.name;		               
            _pooledGameObjects.Add(newGameObject);	
			return newGameObject;
		}

		public override GameObject GetPooledGameObject()
		{
			GameObject pooledGameObject;
			
			pooledGameObject =  GetPooledGameObjectPoolSizeBased();
					
			if (pooledGameObject!=null)
			{
				_lastPooledObjectName = pooledGameObject.name;
			}
			else
			{	
				_lastPooledObjectName="";
			}
			return pooledGameObject;
		}

		protected virtual GameObject GetPooledGameObjectPoolSizeBased()
		{
 
			int randomIndex = UnityEngine.Random.Range(0, _pooledGameObjects.Count);

			int overflowCounter=0;

			while (!PoolObjectEnabled(_pooledGameObjects[randomIndex]) && overflowCounter < _pooledGameObjects.Count)
			{
				randomIndex = UnityEngine.Random.Range(0, _pooledGameObjects.Count);
				overflowCounter++;
			}
			if (!PoolObjectEnabled(_pooledGameObjects[randomIndex]))
			{ 
				return null; 
			}

			// if we can't pool the same object twice, we'll loop for a while to try and get another one
			overflowCounter = 0;
			while (!CanPoolSameObjectTwice 
				&& _pooledGameObjects[randomIndex].name == _lastPooledObjectName 
				&& overflowCounter < _pooledGameObjects.Count)
			{
				randomIndex = UnityEngine.Random.Range(0, _pooledGameObjects.Count);
				overflowCounter++;
			}

			//  if the item we've picked is active
			if (_pooledGameObjects[randomIndex].gameObject.activeInHierarchy)
			{	
				// we try to find another inactive object of the same type
				GameObject pulledObject = FindInactiveObject(_pooledGameObjects[randomIndex].gameObject.name,_pooledGameObjects);
				if (pulledObject!=null)
				{
					return pulledObject;
				}
				else
				{
					// if we couldn't find an inactive object of this type, we see if it can expand
					MultipleObjectPoolerObject searchedObject = GetPoolObject(_pooledGameObjects[randomIndex].gameObject);
					if (searchedObject==null)
					{
						return null; 
					}
					// if the pool for this object is allowed to grow (this is set in the inspector if you're wondering)
					if (searchedObject.PoolCanExpand)
					{						
						return AddOneObjectToThePool(searchedObject.GameObjectToPool);						 	
					}
					else
					{
						// if it's not allowed to grow, we return nothing.
						return null;
					}
				}
			}
			else
			{			
				// if the pool wasn't empty, we return the random object we've found.
				return _pooledGameObjects[randomIndex];   
			}
		}

		protected virtual GameObject FindInactiveObject(string searchedName, List<GameObject> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				// if we find an object inside the pool that matches the asked type
				if (list[i].name.Equals(searchedName))
				{
					// and if that object is inactive right now
					if (!list[i].gameObject.activeInHierarchy)
					{
						// we return it
						return list[i];
					}
				}            
			}
			return null;
		}

		protected virtual GameObject FindAnyInactiveObject(List<GameObject> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				// and if that object is inactive right now
				if (!list[i].gameObject.activeInHierarchy)
				{
					// we return it
					return list[i];
				}                        
			}
			return null;
		}

		protected virtual GameObject FindObject(string searchedName,List<GameObject> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				// if we find an object inside the pool that matches the asked type
				if (list[i].name.Equals(searchedName))
				{
					// and if that object is inactive right now
					return list[i];
				}            
			}
			return null;
		}

		protected virtual MultipleObjectPoolerObject GetPoolObject(GameObject testedObject)
		{
			if (testedObject==null)
			{
				return null;
			}
			int i=0;
			foreach(MultipleObjectPoolerObject poolerObject in Pool)
			{
				if (testedObject.name.Equals(poolerObject.GameObjectToPool.name))
				{
					return (poolerObject);
				}
				i++;
			}
			return null;
		}

		protected virtual bool PoolObjectEnabled(GameObject testedObject)
		{
			MultipleObjectPoolerObject searchedObject = GetPoolObject(testedObject);
			if (searchedObject != null)
			{
				return searchedObject.Enabled;
			}
			else
			{
				return false;
			}
		}

		public virtual void EnableObjects(string name,bool newStatus)
		{
			foreach(MultipleObjectPoolerObject poolerObject in Pool)
			{
				if (name.Equals(poolerObject.GameObjectToPool.name))
				{
					poolerObject.Enabled = newStatus;
				}
			}
		}

		public virtual void ResetCurrentIndex()
		{
			_currentIndex=0;
		}
	}
