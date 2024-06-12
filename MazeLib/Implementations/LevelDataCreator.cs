using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeLib
{
    public class LevelDataCreator<T>
    {
        private readonly int _stepSize;

        public LevelDataCreator(int stepSize)
        {
            _stepSize = stepSize;
        }

        public void LevelOneData(out AbstractPlayer<T> player, out List<AbstractBorder<T>> borders, out List<AbstractPickup<T>> pickups, out List<AbstractGhost<T>> ghosts)
        {
            player = new Player<T>(_stepSize, 2, new Point(_stepSize, _stepSize));

            borders = new List<AbstractBorder<T>>();

            var top = new Border<T>(new Point(0, 0), _stepSize, new Size(13 * _stepSize, _stepSize));
            var bottom = new Border<T>(new Point(0, 12 * _stepSize), _stepSize, new Size(13 * _stepSize, _stepSize));
            var left = new Border<T>(new Point(0, _stepSize), _stepSize, new Size(_stepSize, 11 * _stepSize));
            var right = new Border<T>(new Point(12 * _stepSize, _stepSize), _stepSize, new Size(_stepSize, 12 * _stepSize));

            var rec1 = new Border<T>(new Point(2 * _stepSize, 2 * _stepSize), _stepSize, new Size(4 * _stepSize, _stepSize));
            var rec2 = new Border<T>(new Point(7 * _stepSize, 2 * _stepSize), _stepSize, new Size(4 * _stepSize, _stepSize));
            var rec3 = new Border<T>(new Point(2 * _stepSize, 3 * _stepSize), _stepSize, new Size(_stepSize, 3 * _stepSize));
            var rec4 = new Border<T>(new Point(4 * _stepSize, 4 * _stepSize), _stepSize, new Size(5 * _stepSize, _stepSize));
            var rec5 = new Border<T>(new Point(10 * _stepSize, 3 * _stepSize), _stepSize, new Size(_stepSize, 3 * _stepSize));
            var rec6 = new Border<T>(new Point(4 * _stepSize, 5 * _stepSize), _stepSize, new Size(_stepSize, _stepSize * 3));
            var rec7 = new Border<T>(new Point(8 * _stepSize, 5 * _stepSize), _stepSize, new Size(_stepSize, _stepSize * 3));
            var rec8 = new Border<T>(new Point(2 * _stepSize, 7 * _stepSize), _stepSize, new Size(_stepSize, 3 * _stepSize));
            var rec9 = new Border<T>(new Point(4 * _stepSize, 8 * _stepSize), _stepSize, new Size(5 * _stepSize, _stepSize));
            var rec10 = new Border<T>(new Point(10 * _stepSize, 7 * _stepSize), _stepSize, new Size(_stepSize, 3 * _stepSize));
            var rec11 = new Border<T>(new Point(2 * _stepSize, 10 * _stepSize), _stepSize, new Size(4 * _stepSize, _stepSize));
            var rec12 = new Border<T>(new Point(7 * _stepSize, 10 * _stepSize), _stepSize, new Size(4 * _stepSize, _stepSize));
            var rec13 = new Border<T>(new Point(6 * _stepSize, 5 * _stepSize), _stepSize, new Size(_stepSize, 3 * _stepSize));

            borders.Add(right);
            borders.Add(top);
            borders.Add(left);
            borders.Add(bottom);

            borders.Add(rec1);
            borders.Add(rec2);
            borders.Add(rec3);
            borders.Add(rec4);
            borders.Add(rec5);
            borders.Add(rec6);
            borders.Add(rec7);
            borders.Add(rec8);
            borders.Add(rec9);
            borders.Add(rec10);
            borders.Add(rec11);
            borders.Add(rec12);
            borders.Add(rec13);

            pickups = new List<AbstractPickup<T>>();

            int normalPickupSize = _stepSize / 2;

            var p01_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p01_02 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 2.25)), normalPickupSize);
            var p01_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p01_04 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 4.25)), normalPickupSize);
            var p01_05 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 5.25)), normalPickupSize);
            var p01_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize);
            var p01_07 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 7.25)), normalPickupSize);
            var p01_08 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 8.25)), normalPickupSize);
            var p01_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p01_10 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 10.25)), normalPickupSize);
            var p01_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 1.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);

            var p02_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 2.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p03_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p04_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 4.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p05_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 5.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p06_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p07_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 7.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p08_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 8.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p09_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p10_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 10.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);
            var p11_01 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 1.25)), normalPickupSize);

            var p11_02 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 2.25)), normalPickupSize);
            var p11_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p11_04 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 4.25)), normalPickupSize);
            var p11_05 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 5.25)), normalPickupSize);
            var p11_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize);
            var p11_07 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 7.25)), normalPickupSize);
            var p11_08 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 8.25)), normalPickupSize);
            var p11_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p11_10 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 10.25)), normalPickupSize);
            var p11_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 11.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);

            var p02_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 2.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p03_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p04_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 4.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p05_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 5.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p06_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p07_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 7.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p08_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 8.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p09_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);
            var p10_11 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 10.25), Convert.ToInt32(_stepSize * 11.25)), normalPickupSize);

            var p03_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p03_04 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 4.25)), normalPickupSize);
            var p03_05 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 5.25)), normalPickupSize);
            var p03_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize);
            var p03_07 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 7.25)), normalPickupSize);
            var p03_08 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 8.25)), normalPickupSize);
            var p03_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            //var p03_10 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 3.25), Convert.ToInt32(_stepSize * 10.25)), normalPickupSize);

            var p04_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 4.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p05_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 5.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p06_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p07_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 7.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p08_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 8.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);
            var p09_03 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 3.25)), normalPickupSize);

            var p09_04 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 4.25)), normalPickupSize);
            var p09_05 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 5.25)), normalPickupSize);
            var p09_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize);
            var p09_07 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 7.25)), normalPickupSize);
            var p09_08 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 8.25)), normalPickupSize);
            var p09_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 9.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);

            var p04_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 4.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p05_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 5.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p06_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p07_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 7.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);
            var p08_09 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 8.25), Convert.ToInt32(_stepSize * 9.25)), normalPickupSize);

            var p02_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 2.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize) { IsFruit = true };
            var p06_02 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 2.25)), normalPickupSize) { IsFruit = true };
            var p10_06 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 10.25), Convert.ToInt32(_stepSize * 6.25)), normalPickupSize) { IsFruit = true };
            var p06_10 = new Pickup<T>(new Point(Convert.ToInt32(_stepSize * 6.25), Convert.ToInt32(_stepSize * 10.25)), normalPickupSize) { IsFruit = true };

            pickups.Add(p01_01);
            pickups.Add(p01_02);
            pickups.Add(p01_03);
            pickups.Add(p01_04);
            pickups.Add(p01_05);
            pickups.Add(p01_06);
            pickups.Add(p01_07);
            pickups.Add(p01_08);
            pickups.Add(p01_09);
            pickups.Add(p01_10);
            pickups.Add(p01_11);

            pickups.Add(p02_01);
            pickups.Add(p03_01);
            pickups.Add(p04_01);
            pickups.Add(p05_01);
            pickups.Add(p06_01);
            pickups.Add(p07_01);
            pickups.Add(p08_01);
            pickups.Add(p09_01);
            pickups.Add(p10_01);
            pickups.Add(p11_01);

            pickups.Add(p11_02);
            pickups.Add(p11_03);
            pickups.Add(p11_04);
            pickups.Add(p11_05);
            pickups.Add(p11_06);
            pickups.Add(p11_07);
            pickups.Add(p11_08);
            pickups.Add(p11_09);
            pickups.Add(p11_10);
            pickups.Add(p11_11);

            pickups.Add(p02_11);
            pickups.Add(p03_11);
            pickups.Add(p04_11);
            pickups.Add(p05_11);
            pickups.Add(p06_11);
            pickups.Add(p07_11);
            pickups.Add(p08_11);
            pickups.Add(p09_11);
            pickups.Add(p10_11);

            pickups.Add(p03_03);
            pickups.Add(p03_04);
            pickups.Add(p03_05);
            pickups.Add(p03_06);
            pickups.Add(p03_07);
            pickups.Add(p03_08);
            pickups.Add(p03_09);
            //pickups.Add(p03_10);

            pickups.Add(p04_03);
            pickups.Add(p05_03);
            pickups.Add(p06_03);
            pickups.Add(p07_03);
            pickups.Add(p08_03);
            pickups.Add(p09_03);

            pickups.Add(p09_04);
            pickups.Add(p09_05);
            pickups.Add(p09_06);
            pickups.Add(p09_07);
            pickups.Add(p09_08);
            pickups.Add(p09_09);

            pickups.Add(p04_09);
            pickups.Add(p05_09);
            pickups.Add(p06_09);
            pickups.Add(p07_09);
            pickups.Add(p08_09);

            pickups.Add(p02_06);
            pickups.Add(p06_02);
            pickups.Add(p10_06);
            pickups.Add(p06_10);

            ghosts = new List<AbstractGhost<T>>();
            ghosts.Add(new Ghost<T>(_stepSize, 1, new System.Drawing.Point(_stepSize * 3, _stepSize * 3)));
            ghosts.Add(new Ghost<T>(_stepSize, 2, new System.Drawing.Point(_stepSize * 9, _stepSize * 3)));
        }
    }
}
