using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamObject : MonoBehaviour {

	public float X{
		get{
			return this.transform.position.x;
		}
		set{
			this.transform.position = new Vector3 (value, this.transform.position.y, this.transform.position.z); 
		}
	}

	public float Y{
		get{
			return this.transform.position.y; 
		}
		set{
			this.transform.position = new Vector3 (this.transform.position.x, value, this.transform.position.z); 
		}
	}

	private Vector3 _direction;
	public float direction{
		get{ 
			return Mathf.Atan2 (_direction.x, _direction.y);
		}
		set{ 
			var _x = Mathf.Cos (value / 180 * Mathf.PI);
			var _y = Mathf.Sin (value / 180 * Mathf.PI);
			_direction = new Vector3 (_x, _y, 0);
		}
	}

	public float speed;

	public void Move()
	{
		this.transform.position = this.transform.position + (_direction * speed);
	}
}
