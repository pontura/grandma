using System.Collections;
using UnityEngine;

namespace Tumba.Game.Characters
{
    public class Grabbable : MonoBehaviour
    {
        Transform target;
        float speed = 10;
        [SerializeField] types type;
        enum types
        {
            SOUL
        }

        public void OnGrab(Transform target)
        {
            this.target = target;
            StartCoroutine(OnGrabCoroutine());
        }
        IEnumerator OnGrabCoroutine()
        {
            Vector2 dest = target.position;
            Vector2 pos = transform.position;
            float dist = Vector2.Distance(dest, pos);
            while (dist > 0.5f)
            {
                dest = target.position;
                pos = transform.position;
                dist = Vector2.Distance(dest, pos);
                transform.position = Vector3.Lerp(pos, dest, Time.deltaTime* speed);
                yield return new WaitForEndOfFrame();
            }
            Events.OnSoulGrabbed(type.ToString());
            GameManager.Instance.pool.Pool(this.gameObject);
            yield return null;
        }
    }
}
