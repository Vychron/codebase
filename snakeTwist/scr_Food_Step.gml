randomize();
if (place_meeting(x, y, obj_NotEmpty)
    ||x < (96-global.xRot)
    ||y < (32-global.yRot)
    ||x >= (room_width-32)
    ||y >= (room_height-32)
    )
{
    x = (irandom_range(4,27)*32)+global.xRot;
    y = (irandom_range(1,25)*32)+global.yRot;
}
