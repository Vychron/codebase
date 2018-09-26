enum dirs
{
    Left,
    Right,
    Up,
    Down
}

curDir = dirs.Up;
prvDir = dirs.Up;

timer = 0;
eaten = 0;
xSp = 0;
ySp = -32;
xPrevious = x;
yPrevious = y;
view_angle[1] = 0;

rot = 32/360;
