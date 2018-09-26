switch (prvDir)
{
    case dirs.Left:
        if keyboard_check_pressed(ord("D"))
        {xSp = 0; ySp = -32; curDir = dirs.Up;}
        else if keyboard_check_pressed(ord("A"))
        {xSp = 0; ySp = 32; curDir = dirs.Down;}
        if view_angle[1] != 270
        {
            if view_angle[1] > 270||view_angle[1] < 90
            {view_angle[1] -= 5;}
            if view_angle[1] < 270 && view_angle[1] > 90
            {view_angle[1] += 5;}
        }
        if global.xRot != 0
        {global.xRot -= 1.8;}
        if global.yRot != 32.4
        {global.yRot += 1.8;}
        break;
    case dirs.Right:
        if keyboard_check_pressed(ord("A"))
        {xSp = 0; ySp = -32; curDir = dirs.Up;}
        else if keyboard_check_pressed(ord("D"))
        {xSp = 0; ySp = 32; curDir = dirs.Down;}
        if view_angle[1] != 90
        {
            if view_angle[1] > 90&&view_angle[1] < 270
            {view_angle[1] -= 5;}
            if view_angle[1] < 90 || view_angle[1] > 270
            {view_angle[1] += 5;}
        }
        if global.xRot != 32.4
        {global.xRot += 1.8;}
        if global.yRot != 0
        {global.yRot -= 1.8;}
        break;
    case dirs.Up:
        if keyboard_check_pressed(ord("A"))
        {xSp = -32; ySp = 0; curDir = dirs.Left;}
        else if keyboard_check_pressed(ord("D"))
        {xSp = 32; ySp = 0; curDir = dirs.Right;}
        if view_angle[1] != 0
        {
            if view_angle[1] > 0&&view_angle[1] < 180
            {view_angle[1] -= 5;}
            if view_angle[1] < 360 && view_angle[1] > 180
            {view_angle[1] += 5;}
        }
        if global.xRot != 0
        {global.xRot -= 1.8;}
        if global.yRot != 0
        {global.yRot -= 1.8;}
        break;
    case dirs.Down:
        if keyboard_check_pressed(ord("D"))
        {xSp = -32; ySp = 0; curDir = dirs.Left;}
        else if keyboard_check_pressed(ord("A"))
        {xSp = 32; ySp = 0; curDir = dirs.Right;}
        if view_angle[1] != 180
        {
            if view_angle[1] > 180&&view_angle[1] < 360
            {view_angle[1] -= 5;}
            if view_angle[1] < 180 && view_angle[1] > 0
            {view_angle[1] += 5;}
        }
        if global.xRot != 32.4
        {global.xRot += 1.8;}
        if global.yRot != 32.4
        {global.yRot += 1.8;}
        break;
}
if timer <= 0
{
    xPrevious = x;
    yPrevious = y;
    prvDir = curDir;
    x+=xSp;
    y+=ySp;
    timer = 10 - eaten/10;
    instance_create(xPrevious, yPrevious, obj_Snake_Tail);
}
timer--;
if place_meeting(x, y, obj_Snake_Tail)
{
    room_restart();
}
if place_meeting(x, y, obj_Food)
{
    eaten += global.difficulty;
    obj_Ui.playerScore += 50;
}
if x > room_width-global.xRot
{x = 96}
if x < 96 - global.xRot
{x = room_width-64 + global.xRot}
if y > room_height-global.yRot
{y = 32}
if y < 32 - global.yRot
{y = room_height-64 + global.yRot}
if view_angle[1] >360
{view_angle[1] = 5}
if view_angle[1] < 0
{view_angle[1] = 355}
