using Evertop.Soccer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UEPilkarzki
{
    public class Pilkarz : IPlayer
    {
        public string Name
        {
            get
            {
                return "rasiak";
            }
        }

        public Direction GetNextMove(Move[] historyMoves, Position ballPosition, Direction[] possibleMoves)
        {
            int bestDirectionValue = GetPositionValue(GetPositionAfterKick(ballPosition, possibleMoves[0]));
            Direction bestDirection = possibleMoves[0];
            for (int i=1;i<possibleMoves.Count();i++)
            {
                int currentDirectionValue = GetPositionValue(GetPositionAfterKick(ballPosition, possibleMoves[i]));
                if (currentDirectionValue<bestDirectionValue)
                {
                    bestDirectionValue = currentDirectionValue;
                    bestDirection = possibleMoves[i];
                }
            }

            return bestDirection;
        }

        public void StartMatch(FieldData field)
        {
        }

        public int GetPositionValue(Position position)
        {
            return position.X + Math.Abs(position.Y-5);
        }

        public Position GetPositionAfterKick(Position position, Direction direction)
        {
            switch(direction)
            {
                case Direction.Down:
                    return new Position(position.X, position.Y + 1);
                case Direction.DownAndLeft:
                    return new Position(position.X - 1, position.Y + 1);
                case Direction.Left:
                    return new Position(position.X - 1, position.Y);
                case Direction.LeftAndUp:
                    return new Position(position.X - 1, position.Y - 1);
                case Direction.Right:
                    return new Position(position.X + 1, position.Y);
                case Direction.RightAndDown:
                    return new Position(position.X + 1, position.Y + 1);
                case Direction.Up:
                    return new Position(position.X, position.Y - 1);
                case Direction.UpAndRight:
                    return new Position(position.X + 1, position.Y - 1);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
