using System;

namespace BattleShip.BLL.Requests
{
    public class Coordinate
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
       // we need to get an x and y cord before we use coordinate
        public Coordinate(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
        //will not use anything below
        public override bool Equals(object obj)
        {
            Coordinate otherCoordinate = obj as Coordinate;

            if (otherCoordinate == null)
                return false;

            return otherCoordinate.XCoordinate == this.XCoordinate &&
                   otherCoordinate.YCoordinate == this.YCoordinate;
        }
		
		public override int GetHashCode() 
        { 
            string uniqueHash = this.XCoordinate.ToString() + this.YCoordinate.ToString() + "00"; 
            return (Convert.ToInt32(uniqueHash)); 
        } 

    }
}
