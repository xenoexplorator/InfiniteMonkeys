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

	public void FlipXToLeft()
	{
		var scalex = this.transform.localScale.x;
		this.transform.localScale = new Vector3(Mathf.Abs(scalex) * -1, this.transform.localScale.y);
	}

	public void FlipXToRight()
	{
		var scalex = this.transform.localScale.x;
		this.transform.localScale = new Vector3(Mathf.Abs(scalex), this.transform.localScale.y);
	}

	public float Y{
		get{
			return this.transform.position.y; 
		}
		set{
			this.transform.position = new Vector3 (this.transform.position.x, value, this.transform.position.z); 
		}
	}

	protected Vector3 _direction;
	public float direction{
		get{ 
			return Mathf.Atan2 (_direction.y, _direction.x) * 180 / Mathf.PI;
		}
		set{ 
			var _x = Mathf.Cos (value / 180 * Mathf.PI);
			var _y = Mathf.Sin (value / 180 * Mathf.PI);
			_direction = new Vector3 (_x, _y, 0);
		}
	}

	public float speed;

	public void SetDirection(Vector3 vec)
	{
		_direction = vec;
	}

	public void Move()
	{
		this.transform.position = this.transform.position + (_direction * speed);
	}
}
