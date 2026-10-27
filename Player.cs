using System;

// состояние игрока
enum State
{
    Winner,
    Loser,
    Playing,
    NotInGame
}

class Player
{
    public string name;                    // имя игрока
    public int location;                   // позиция на поле (клетки нумеруются с 1)
    public State state = State.NotInGame;  // состояние
    public int distanceTraveled = 0;       // пройденное расстояние

    private readonly int fieldSize;        // размер игрового поля N

    public Player(string name, int fieldSize)
    {
        this.name = name;
        this.fieldSize = fieldSize;
        this.location = -1; // не в игре
    }

    // Начальная позиция: это не ход, поэтому расстояние не увеличивается
    public void PlaceAt(int cell)
    {
        location = cell;
        state = State.Playing;
    }

    // Ход на steps клеток (может быть отрицательным).
    // Поле замкнуто в кольцо: за последней клеткой снова идёт первая.
    public void Move(int steps)
    {
        location = ((location - 1 + steps) % fieldSize + fieldSize) % fieldSize + 1;
        distanceTraveled += Math.Abs(steps);
    }
}
