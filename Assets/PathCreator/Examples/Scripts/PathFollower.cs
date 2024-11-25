using Dreamteck.Splines;
using UnityEngine;



    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {

        public SplineFollower splineFollower;
        public SplineComputer spline;
        public SplineUser splineUser;

    public void Start()
    {
        splineUser = GetComponent<SplineUser>();
    }
    public void Update()
        {
            if (splineUser.spline == null) 
            {
               splineUser.spline = GameObject.Find("Obstacles + Road").GetComponentInChildren<SplineComputer>();
            }
        }
    }
